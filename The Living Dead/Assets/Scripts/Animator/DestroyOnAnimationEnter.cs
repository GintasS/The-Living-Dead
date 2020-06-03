using UnityEngine;

/// <summary>
/// A class that destroys the gameobject on a animation enter state.
/// </summary>
public sealed class DestroyOnAnimationEnter : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, stateInfo.length);
    }
}