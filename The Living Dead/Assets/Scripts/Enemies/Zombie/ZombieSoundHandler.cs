using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles zombie sounds.
/// </summary>
public sealed class ZombieSoundHandler : MonoBehaviour
{
    [Header("Zombie Sound Settings")]
    [SerializeField]
    private List<AudioClip> zombieAttackClips;
    [SerializeField]
    private List<AudioClip> zombieFootstepClips;
    [SerializeField]
    private AudioSource audioSource;

    /// <summary>
    /// Try play random zound for a zombie audio source.
    /// </summary>
    /// <param name="zombieSoundType">ZombieSoundType to play.</param>
    public void TryPlayRandomSound(ZombieSoundType zombieSoundType)
    {
        if (audioSource.isPlaying)
        {
            return;
        }

        switch (zombieSoundType)
        {
            case ZombieSoundType.Attack:
                audioSource.clip = zombieAttackClips.GetRandomElementOrDefault();
                break;
            case ZombieSoundType.Footstep:
                audioSource.clip = zombieFootstepClips.GetRandomElementOrDefault();
                break;
        }
        audioSource.Play();
    }
}