using UnityEngine;

/// <summary>
/// Class that handles Game scene game options.
/// </summary>
public sealed class GameSceneGameOptions : MonoBehaviour
{
    [Header("Game Options")]
    [SerializeField]
    private PlayerWeaponEquipHandler playerWeaponEquipHandler;
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private PlayerMoney playerMoney;

    public void TrySetGameOptions()
    {
        playerHealth.StartingHealth = PlayerPrefsWrapper.TryGetInt(Constants.GameOptionsKey.StartingHealth) ?? playerHealth.StartingHealth;
        SetStartingAmmoClipsForAllWeapons(PlayerPrefsWrapper.TryGetInt(Constants.GameOptionsKey.StartingAmmoClips));
        playerMoney.StartingMoney = PlayerPrefsWrapper.TryGetInt(Constants.GameOptionsKey.StartingMoney) ?? playerMoney.StartingMoney;
    }

    private void SetStartingAmmoClipsForAllWeapons(int? startingAmmoClips)
    {
        if (!startingAmmoClips.HasValue)
        {
            return;
        }

        var playerWeapons = playerWeaponEquipHandler.PlayerWeapons;
        foreach (var weapon in playerWeapons)
        {
            weapon.WeaponAmmo.StartingAmmoClips = startingAmmoClips.Value;
        }
    }
}