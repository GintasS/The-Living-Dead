using UnityEngine;

/// <summary>
/// A class that plays a sound on a animation enter state.
/// </summary>
public sealed class PlaySoundOnAnimationEnter : StateMachineBehaviour
{
    [SerializeField]
    private string audioSourceGameObjectName;
    [SerializeField]
    private AudioClip audioClip;
    [SerializeField]
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GameObject.Find(audioSourceGameObjectName).GetComponent<AudioSource>();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}