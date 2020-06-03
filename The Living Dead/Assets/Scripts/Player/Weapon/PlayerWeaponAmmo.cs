using UnityEngine;

/// <summary>
/// Class that handles the ammunition part of a weapon.
/// </summary>
public sealed class PlayerWeaponAmmo : MonoBehaviour
{
    [Header("Weapon Ammo Settings")]
    [SerializeField]
    private int startingAmmo;
    [SerializeField]
    private int startingAmmoClips;
    [SerializeField]
    private int currentAmmo;
    [SerializeField]
    private int currentAmmoClips;
    [SerializeField]
    private int maxAmmoInClip;
    [SerializeField]
    private int maxAmmoClips;
    [Header("Weapon Ammo Type Settings")]
    [SerializeField]
    private AmmoType weaponAmmoType;

    /// <summary>
    /// Get starting ammo clips for this weapon.
    /// </summary>
    public int StartingAmmoClips
    {
        set
        {
            startingAmmoClips = value;
        }
    }

    /// <summary>
    /// Get current ammo for this weapon.
    /// </summary>
    public int CurrentAmmo
    {
        get
        {
            return currentAmmo;
        }
    }

    /// <summary>
    /// Get current ammo clips for this weapon.
    /// </summary>
    public int CurrentAmmoClips
    {
        get
        {
            return currentAmmoClips;
        }
    }

    /// <summary>
    /// Does the player has ammo to spend?
    /// </summary>
    public bool HasAmmo
    {
        get
        {
            return CurrentAmmo > 0;
        }
    }

    /// <summary>
    /// Does the player has ammo clips for a reload?
    /// </summary>
    public bool HasAmmoClips
    {
        get
        {
            return CurrentAmmoClips > 0;
        }
    }

    void Start()
    {
        currentAmmo = startingAmmo;
        currentAmmoClips = startingAmmoClips;
    }

    /// <summary>
    /// Reduce current ammo for this weapon by one unit.
    /// </summary>
    public void ReduceCurrentAmmoByOne()
    {
        currentAmmo--;
    }

    /// <summary>
    /// Reload ammo clip for this weapon, so a player could have ammo to shoot.
    /// </summary>
    public void ReloadAmmoClip()
    {
        if (currentAmmoClips > 0)
        {
            currentAmmo = maxAmmoInClip;
            currentAmmoClips--;
        }
    }

    /// <summary>
    /// Try to add ammo clips if the player has not yet reached max ammo clips.
    /// </summary>
    /// <param name="clipsToAdd">Ammo clips to add to the weapon.</param>
    /// <returns>Whether the operation has succeeded or not.</returns>
    public bool TryAddAmmoClips(int clipsToAdd)
    {
        if (HasSpaceToAddAmmoClips(clipsToAdd))
        {
            currentAmmoClips += clipsToAdd;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Check if it's possible to add more ammo clips to the weapon.
    /// </summary>
    /// <param name="clipsToAdd">Ammo clips to add</param>
    /// <returns>True if player has space, false if not.</returns>
    public bool HasSpaceToAddAmmoClips(int clipsToAdd)
    {
        return currentAmmoClips + clipsToAdd <= maxAmmoClips && clipsToAdd > 0;
    }

    /// <summary>
    /// Check whether the ammo type matches this weapon's ammo type.
    /// </summary>
    /// <param name="ammoType">Ammo type to check.</param>
    public bool IsWeaponAmmoTypeMatches(AmmoType ammoType)
    {
        return weaponAmmoType == ammoType;
    }
}