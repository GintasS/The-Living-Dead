using UnityEngine;

/// <summary>
/// Class that deals with weapon's flashlight capability.
/// </summary>
public sealed class PlayerWeaponFlashlight : MonoBehaviour
{
    [Header("Weapon Flashlight Settings")]
    [SerializeField]
    private Light weaponFlashlight;
    [SerializeField]
    private bool isWeaponFlashlightActive;
    [SerializeField]
    private bool weaponHasFlashlight;

    /// <summary>
    /// Try set weapon flashlight off or on.
    /// </summary>
    public void TrySetWeaponFlashlightActive()
    {
        if (!weaponHasFlashlight)
        {
            return;
        }

        weaponFlashlight.enabled = !isWeaponFlashlightActive;
        isWeaponFlashlightActive = !isWeaponFlashlightActive;
    }
}