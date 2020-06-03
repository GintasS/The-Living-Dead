using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles various player sounds.
/// </summary>
public sealed class PlayerSoundHandler : MonoBehaviour
{
    [Header("Player Sound Settings")]
    [SerializeField]
    private List<AudioClip> playerHurtClips;
    [SerializeField]
    private List<AudioClip> playerIdleClips;
    [SerializeField]
    private List<AudioClip> playerJumpClips;
    [SerializeField]
    private List<AudioClip> playerLandClips;
    [SerializeField]
    private List<AudioClip> playerFootstepClips;
    [SerializeField]
    private AudioSource audioSource;

    /// <summary>
    /// Play random player sound.
    /// </summary>
    /// <param name="playerSoundType">PlayerSoundType to play.</param>
    public void PlayRandomSound(PlayerSoundType playerSoundType)
    {
        switch(playerSoundType)
        {
            case PlayerSoundType.Hurt:
                audioSource.clip = playerHurtClips.GetRandomElementOrDefault();
                break;
            case PlayerSoundType.Idle:
                audioSource.clip = playerIdleClips.GetRandomElementOrDefault();
                break;
            case PlayerSoundType.Jump:
                audioSource.clip = playerJumpClips.GetRandomElementOrDefault();
                break;
            case PlayerSoundType.Land:
                audioSource.clip = playerLandClips.GetRandomElementOrDefault();
                break;
            case PlayerSoundType.Footstep:
                audioSource.clip = playerFootstepClips.GetRandomElementOrDefault();
                break;
        }
        audioSource.Play();
    }
}