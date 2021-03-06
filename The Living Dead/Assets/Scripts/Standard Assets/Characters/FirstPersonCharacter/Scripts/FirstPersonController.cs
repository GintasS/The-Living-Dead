using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;


namespace UnityStandardAssets.Characters.FirstPerson
{
    [RequireComponent(typeof (CharacterController))]
    public class FirstPersonController : MonoBehaviour
    {
        [Header("Walking Settings")]
        [SerializeField] 
        private float m_WalkSpeed;
        [SerializeField]
        private bool m_IsWalking;
        [Header("Running Settings")]
        [SerializeField] 
        private float m_RunSpeed;
        [Header("Jump Settings")]
        [SerializeField] 
        [Range(0f, 1f)] 
        private float m_RunstepLenghten;
        [SerializeField] 
        private float m_JumpSpeed;
        [SerializeField] 
        private float m_StickToGroundForce;
        [SerializeField] 
        private float m_GravityMultiplier;
        [Header("Mouse Look Settings")]
        [SerializeField] 
        private MouseLook m_MouseLook;
        [Header("FOV Settings")]
        [SerializeField] 
        private FOVKick m_FovKick = new FOVKick();
        [SerializeField]
        private bool m_UseFovKick;
        [Header("HeadBob Settings")]
        [SerializeField] 
        private CurveControlledBob m_HeadBob = new CurveControlledBob();
        [SerializeField] 
        private LerpControlledBob m_JumpBob = new LerpControlledBob();
        [SerializeField] 
        private float m_StepInterval;
        [SerializeField] 
        public bool isCameraFollowingMouseInput;
        [SerializeField]
        private bool m_UseHeadBob;
        [Header("Script References")]
        [SerializeField]
        private CharacterController m_CharacterController;
        [SerializeField]
        private PlayerSoundHandler playerSoundHandler;

        private Camera m_Camera;
        private bool m_Jump;
        private Vector2 m_Input;
        private Vector3 m_MoveDir = Vector3.zero;
        private CollisionFlags m_CollisionFlags;
        private bool m_PreviouslyGrounded;
        private Vector3 m_OriginalCameraPosition;
        private float m_StepCycle;
        private float m_NextStep;
        private bool m_Jumping;

        public MouseLook MouseLook
        {
            get
            {
                return m_MouseLook;
            }
        }

        void Start()
        {
            m_Camera = Camera.main;
            m_OriginalCameraPosition = m_Camera.transform.localPosition;
            m_FovKick.Setup(m_Camera);
            m_HeadBob.Setup(m_Camera, m_StepInterval);
            m_NextStep = m_StepCycle/2f;
			m_MouseLook.Init(transform , m_Camera.transform);
        }

        private void Update()
        {
            RotateView();
            // The jump state needs to read here to make sure it is not missed.
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
            {
                StartCoroutine(m_JumpBob.DoBobCycle());
                PlayLandingSound();
                m_MoveDir.y = 0f;
                m_Jumping = false;
            }
            if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded)
            {
                m_MoveDir.y = 0f;
            }

            m_PreviouslyGrounded = m_CharacterController.isGrounded;
        }

        private void PlayLandingSound()
        {
            playerSoundHandler.PlayRandomSound(PlayerSoundType.Land);
            m_NextStep = m_StepCycle + .5f;
        }

        private void FixedUpdate()
        {
            float speed;
            GetInput(out speed);
            // Always move along the camera forward as it is the direction that it being aimed at.
            Vector3 desiredMove = transform.forward*m_Input.y + transform.right*m_Input.x;

            // Get a normal for the surface that is being touched to move along it.
            RaycastHit hitInfo;
            Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                               m_CharacterController.height/2f);
            desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

            m_MoveDir.x = desiredMove.x*speed;
            m_MoveDir.z = desiredMove.z*speed;


            if (m_CharacterController.isGrounded)
            {
                m_MoveDir.y = -m_StickToGroundForce;

                if (m_Jump)
                {
                    m_MoveDir.y = m_JumpSpeed;
                    PlayJumpSound();
                    m_Jump = false;
                    m_Jumping = true;
                }
            }
            else
            {
                m_MoveDir += Physics.gravity*m_GravityMultiplier*Time.fixedDeltaTime;
            }
            m_CollisionFlags = m_CharacterController.Move(m_MoveDir*Time.fixedDeltaTime);

            ProgressStepCycle(speed);
            UpdateCameraPosition(speed);
        }

        private void PlayJumpSound()
        {
            playerSoundHandler.PlayRandomSound(PlayerSoundType.Jump);
        }

        private void ProgressStepCycle(float speed)
        {
            if (m_CharacterController.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
            {
                m_StepCycle += (m_CharacterController.velocity.magnitude + (speed*(m_IsWalking ? 1f : m_RunstepLenghten)))*
                             Time.fixedDeltaTime;
            }

            if (!(m_StepCycle > m_NextStep))
            {
                return;
            }

            m_NextStep = m_StepCycle + m_StepInterval;

            PlayFootStepAudio();
        }

        private void PlayFootStepAudio()
        {
            if (!m_CharacterController.isGrounded)
            {
                return;
            }
            playerSoundHandler.PlayRandomSound(PlayerSoundType.Footstep);
        }

        private void UpdateCameraPosition(float speed)
        {
            Vector3 newCameraPosition;
            if (!m_UseHeadBob)
            {
                return;
            }

            if (m_CharacterController.velocity.magnitude > 0 && m_CharacterController.isGrounded)
            {
                m_Camera.transform.localPosition =
                    m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
                                      (speed*(m_IsWalking ? 1f : m_RunstepLenghten)));
                newCameraPosition = m_Camera.transform.localPosition;
                newCameraPosition.y = m_Camera.transform.localPosition.y - m_JumpBob.Offset();
            }
            else
            {
                newCameraPosition = m_Camera.transform.localPosition;
                newCameraPosition.y = m_OriginalCameraPosition.y - m_JumpBob.Offset();
            }
            m_Camera.transform.localPosition = newCameraPosition;
        }

        private void GetInput(out float speed)
        {
            // Read input.
            var horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            var vertical = CrossPlatformInputManager.GetAxis("Vertical");
            var waswalking = m_IsWalking;

            #if !MOBILE_INPUT
            // On standalone builds, walk/run speed is modified by a key press.
            // keep track of whether or not the character is walking or running.
            m_IsWalking = !Input.GetKey(KeyCode.LeftShift);
            #endif
            // Set the desired speed to be walking or running.
            speed = m_IsWalking ? m_WalkSpeed : m_RunSpeed;
            m_Input = new Vector2(horizontal, vertical);

            // Normalize input if it exceeds 1 in combined length:
            if (m_Input.sqrMagnitude > 1)
            {
                m_Input.Normalize();
            }

            // Handle speed change to give an fov kick.
            // Only if the player is going to a run, is running and the fovkick is to be used.
            if (m_IsWalking != waswalking && m_UseFovKick && m_CharacterController.velocity.sqrMagnitude > 0)
            {
                StopAllCoroutines();
                StartCoroutine(!m_IsWalking ? m_FovKick.FOVKickUp() : m_FovKick.FOVKickDown());
            }
        }

        private void RotateView()
        {
            if (isCameraFollowingMouseInput)
            {
                m_MouseLook.LookRotation(transform, m_Camera.transform);
            }
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            var body = hit.collider.attachedRigidbody;
            
            // Dont move the rigidbody if the character is on top of it.
            if (m_CollisionFlags == CollisionFlags.Below || body == null || body.isKinematic)
            {
                return;
            }

            body.AddForceAtPosition(m_CharacterController.velocity * 0.1f, hit.point, ForceMode.Impulse);
        }
    }
}