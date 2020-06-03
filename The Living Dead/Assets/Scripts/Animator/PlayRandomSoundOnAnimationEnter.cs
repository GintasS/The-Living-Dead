using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that plays a random sound from audio clip collection on a animation enter state.
/// </summary>
public sealed class PlayRandomSoundOnAnimationEnter : StateMachineBehaviour
{
    [SerializeField]
    private List<AudioClip> audioClips;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var audioSource = animator.gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClips.GetRandomElementOrDefault();
        audioSource.Play();
    }
}