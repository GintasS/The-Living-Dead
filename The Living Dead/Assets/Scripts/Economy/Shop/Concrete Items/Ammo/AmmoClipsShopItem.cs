using UnityEngine;

/// <summary>
/// Shop item for ammo clips.
/// </summary>
public sealed class AmmoClipsShopItem : StackableShopItem
{
    [Header("AmmoClips Settings")]
    [SerializeField]
    private AmmoType ammoType;
    [Header("Script References")]
    [SerializeField]
    private PlayerWeaponEquipHandler playerWeaponEquipHandler;

    public AmmoType AmmoType
    {
        get
        {
            return ammoType;
        }
    }

    public override bool IsShopItemCanBeEquiped
    {
        get
        {
            var playerWeaponAmmo = playerWeaponEquipHandler.EquipedWeapon.WeaponAmmo;
            return playerWeaponAmmo.IsWeaponAmmoTypeMatches(ammoType) &&
                    playerWeaponAmmo.HasSpaceToAddAmmoClips(buyAmount);
        }
    }

    public override void EquipItem()
    {
        playerWeaponEquipHandler.EquipedWeapon.WeaponAmmo.TryAddAmmoClips(buyAmount);
    }
}