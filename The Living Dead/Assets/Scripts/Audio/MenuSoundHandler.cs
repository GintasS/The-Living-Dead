using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Class that plays sequential menu music for Main Menu.
/// </summary>
public sealed class MenuSoundHandler : MonoBehaviour
{
    [Header("Menu Sound Settings")]
    [SerializeField]
    private List<AudioClip> audioClips;
    [SerializeField]
    private AudioSource audioSource;

    void Awake()
    {
        RandomizeAudioClips();
        StartCoroutine(PlaySequentialAudioClips());
    }

    private void RandomizeAudioClips()
    {
        audioClips = audioClips.RandomizeOrDefault()
            .ToList();
    }

    /// <summary>
    /// Play audio sequentially, wait for one to finish and start another one.
    /// </summary>
    private IEnumerator PlaySequentialAudioClips()
    {
        var i = 0;
        while(true)
        {
            if (i == audioClips.Count)
            {
                i =  0;
            }
            audioSource.clip = audioClips[i];
            audioSource.Play();

            while (audioSource.isPlaying)
            {
                yield return null;
            }
            i++;
        }
    }
}