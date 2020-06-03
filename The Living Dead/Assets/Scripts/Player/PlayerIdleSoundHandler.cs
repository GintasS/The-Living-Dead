using System.Collections;
using UnityEngine;

/// <summary>
/// Class that plays player idle sounds.
/// </summary>
public sealed class PlayerIdleSoundHandler : MonoBehaviour
{
    [Header("Player Idle Sound Settings")]
    [SerializeField]
    private float soundInitiationTimeMin;
    [SerializeField]
    private float soundInitiationTimeMax;
    [SerializeField]
    private float soundTimer;
    [Header("Script References")]
    [SerializeField]
    private PlayerSoundHandler playerSoundHandler;

    void Start()
    {
        StartCoroutine(PlayRandomIdleSoundAndWait());
    }
    
    /// <summary>
    /// Play a random idle sound and wait for X seconds before playing another one.
    /// </summary>
    private IEnumerator PlayRandomIdleSoundAndWait()
    {
        while(true)
        {
            playerSoundHandler.PlayRandomSound(PlayerSoundType.Idle);

            soundTimer = RandomNumberGenerator.Generate(soundInitiationTimeMin, soundInitiationTimeMax);
            yield return new WaitForSeconds(soundTimer);
        }
    }
}