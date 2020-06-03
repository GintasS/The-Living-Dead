using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles weapon equip process when player switches weapons.
/// </summary>
public sealed class PlayerWeaponEquipHandler : MonoBehaviour
{
    [Header("Player Equip Weapon Settings")]
    [SerializeField]
    private List<PlayerWeapon> playerWeapons;
    [SerializeField]
    private PlayerWeapon equipedWeapon;

    /// <summary>
    /// Get currently equiped weapon by the player(the one the player is holding).
    /// </summary>
    public PlayerWeapon EquipedWeapon
    {
        get
        {
            return equipedWeapon;
        }
    }

    /// <summary>
    /// Get all possible weapons to equip.
    /// </summary>
    public List<PlayerWeapon> PlayerWeapons
    {
        get
        {
            return playerWeapons;
        }
    }

    /// <summary>
    /// Equip a weapon.
    /// </summary>
    /// <param name="weaponIndex">Index of a weapon to equip.</param>
    public void EquipWeapon(int weaponIndex)
    {
        equipedWeapon = playerWeapons[weaponIndex];
        equipedWeapon.SetWeaponObjectActive(true);
    }

    /// <summary>
    /// Unequips previously equiped weapon.
    /// </summary>
    public void UnequipPreviousWeapon()
    {
        equipedWeapon.SetWeaponObjectActive(false);
    }
}