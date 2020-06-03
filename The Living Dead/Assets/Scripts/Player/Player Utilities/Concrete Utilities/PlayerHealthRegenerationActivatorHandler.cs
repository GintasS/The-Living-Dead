using System.Collections;
using UnityEngine;

/// <summary>
/// Class that actually regenerates player health for the player health regenration utility.
/// </summary>
public sealed class PlayerHealthRegenerationActivatorHandler : PlayerUtility
{
    [Header("Player Health Regeneration Settings")]
    [SerializeField]
    private int healthAmountToRegenerateEveryCycle;
    [SerializeField]
    private int healthRegenerationTimer;
    [Header("Script References")]
    [SerializeField]
    private PlayerHealth playerHealth;

    /// <summary>
    /// Start the health regeneration process.
    /// </summary>
    public void StartRegeneratingHealth()
    {
        StartCoroutine(WaitAndRegeneratePlayerHealth());
    }

    /// <summary>
    /// Regenerate player health every X seconds.
    /// </summary>
    private IEnumerator WaitAndRegeneratePlayerHealth()
    {
        while(true)
        {
            yield return new WaitForSeconds(healthRegenerationTimer);
            playerHealth.TryAddHealth(healthAmountToRegenerateEveryCycle);

        }
    }
}