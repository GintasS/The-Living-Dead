using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that plays random sounds, to create the immersive scene.
/// </summary>
public sealed class RandomSoundHandler : MonoBehaviour
{
    [Header("Random Sound Settings")]
    [SerializeField]
    private List<AudioClip> audioClips;
    [SerializeField]
    private AudioSource audioSource;
    [Header("Random Sound Timer Settings")]
    [SerializeField]
    private float soundTimerMin;
    [SerializeField]
    private float soundTimerMax;
    [SerializeField]
    private float soundTimer;

    void Start()
    {
        StartCoroutine(WaitAndPlayRandomSound());
    }

    /// <summary>
    /// Play a random sound and wait for X seconds before playing another one.
    /// </summary>
    private IEnumerator WaitAndPlayRandomSound()
    {
        while (true)
        {
            soundTimer = RandomNumberGenerator.Generate(soundTimerMin, soundTimerMax);
            yield return new WaitForSeconds(soundTimer);

            PlayRandomSound();
        }
    }

    private void PlayRandomSound()
    {
        audioSource.clip = audioClips.GetRandomElementOrDefault();
        audioSource.Play();
    }
}