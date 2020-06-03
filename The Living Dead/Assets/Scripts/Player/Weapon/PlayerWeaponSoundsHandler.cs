using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles weapon sounds part.
/// </summary>
public sealed class PlayerWeaponSoundsHandler : MonoBehaviour
{
    [Header("Weapon Sounds Settings")]
    [SerializeField]
    private List<AudioClip> weaponShootSounds;
    [SerializeField]
    private AudioClip weaponReloadSound;
    [SerializeField]
    private AudioClip weaponEmptyClipSound;
    [SerializeField]
    private AudioSource weaponAudioSource;

    /// <summary>
    /// Play weapon sound.
    /// </summary>
    /// <param name="playerWeaponSoundType">PlayerWeaponSoundType to play.</param>
    public void PlaySound(PlayerWeaponSoundType playerWeaponSoundType)
    {
        switch(playerWeaponSoundType)
        {
            case PlayerWeaponSoundType.Shoot:
                weaponAudioSource.clip = weaponShootSounds.GetRandomElementOrDefault();
                break;
            case PlayerWeaponSoundType.Reload:
                weaponAudioSource.clip = weaponReloadSound;
                break;
            case PlayerWeaponSoundType.Empty:
                weaponAudioSource.clip = weaponEmptyClipSound;
                break;
        }
        weaponAudioSource.Play();
    }
}