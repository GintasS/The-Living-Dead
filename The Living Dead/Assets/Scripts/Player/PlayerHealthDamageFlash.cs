using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that is responsible for displaying a flash when player takes damage.
/// </summary>
public sealed class PlayerHealthDamageFlash : MonoBehaviour
{
    [Header("Damage Flash Settings")]
    [SerializeField]
    private Image damageFlash;
    [SerializeField]
    private float damageFlashDuration;

    /// <summary>
    /// Play a quick damage flash.
    /// </summary>
    public void PlayDamageFlash()
    {
        StartCoroutine(DamageFlash());
    }

    /// <summary>
    /// Flash, wait X seconds and stop the flash.
    /// </summary>
    private IEnumerator DamageFlash()
    {
        damageFlash.enabled = true;
        yield return new WaitForSeconds(damageFlashDuration);
        damageFlash.enabled = false;
    }
}