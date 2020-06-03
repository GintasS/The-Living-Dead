using UnityEngine;

/// <summary>
/// Class that handles all(mouse, keyboard) input from the player.
/// </summary>
public sealed class KeyboardMouseInput : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField]
    private PlayerAttack playerAttack;
    [SerializeField]
    private PlayerWeaponEquipHandler playerWeaponEquipHandler;
    [SerializeField]
    private PlayerHUDHandler playerHUDHandler;
    [SerializeField]
    private UISoundHandler UISoundHandler;
    [SerializeField]
    private GameStateHandler gameStateHandler;
    [SerializeField]
    private ShopUI shopUI;

    /// <summary>
    /// Currently equiped weeapon.
    /// </summary>
    private PlayerWeapon EquipedWeapon
    {
        get
        {
            return playerWeaponEquipHandler.EquipedWeapon;
        }
    }

    /// <summary>
    /// Currently equiped weapon's weapon animation module.
    /// </summary>
    private PlayerWeaponAnimation PlayerWeaponAnimation
    {
        get
        {
            return EquipedWeapon.WeaponAnimation;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Esc button press.

            UISoundHandler.PlayButtonClickSound();
            gameStateHandler.SetPauseGameState();
        }
        else if (!gameStateHandler.IsGamePaused)
        {                  
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // Z button press.

                PlayerWeaponAnimation.SetWeaponHideAnimationState();
            }
            else if (Input.GetKeyDown(KeyCode.Tab))
            {
                // Tab button press.

                playerHUDHandler.SetPlayerAddionalHUDActive();
            }
            else if (!PlayerWeaponAnimation.IsWeaponHidden && !shopUI.IsShopWindowActive)
            {
                if ((Input.GetButton(Constants.Input.Fire1) || Input.GetButtonDown(Constants.Input.Fire1)) && EquipedWeapon.WeaponShoot.CanShoot)
                {
                    // Primary mouse button press or hold.

                    if (!EquipedWeapon.WeaponAmmo.HasAmmo)
                    {
                        EquipedWeapon.WeaponSoundsHandler.PlaySound(PlayerWeaponSoundType.Empty);
                        return;
                    }

                    if (PlayerWeaponAnimation.IsAimWalking)
                    {
                        EquipedWeapon.WeaponShoot.SetWeaponAimShootParticleSystemActive(true);
                        PlayerWeaponAnimation.PlayWeaponAimFireAnimation();
                    }
                    else
                    {
                        EquipedWeapon.WeaponShoot.SetWeaponShootParticleSystemActive(true);
                        PlayerWeaponAnimation.PlayWeaponFireAnimation();
                    }

                    EquipedWeapon.WeaponSoundsHandler.PlaySound(PlayerWeaponSoundType.Shoot);
                    playerAttack.Attack();
                    EquipedWeapon.WeaponShoot.ResetFireRateTimer();
                }
                else if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    // Secondary mouse button press.

                    PlayerWeaponAnimation.SetWeaponAimWalkAnimationState();
                }
                else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift))
                {
                    // W or A or S or D button press + left shift key hold.

                    PlayerWeaponAnimation.PlayWeaponRunAnimation();
                }
                else if (Input.GetKeyDown(KeyCode.R) && EquipedWeapon.WeaponAmmo.HasAmmoClips)
                {
                    // R button press.

                    PlayerWeaponAnimation.PlayWeaponReloadAnimation();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
                {
                    // Alphanumeric '1' or '2' key press.

                    var weaponIndex = Input.GetKeyDown(KeyCode.Alpha1) ? 
                        Constants.WeaponIndex.Weapon0 : Constants.WeaponIndex.Weapon1;

                    playerWeaponEquipHandler.UnequipPreviousWeapon();
                    playerWeaponEquipHandler.EquipWeapon(weaponIndex);
                    PlayerWeaponAnimation.PlayWeaponSwitchAnimation();
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    // F key press.

                    EquipedWeapon.WeaponFlashlight.TrySetWeaponFlashlightActive();
                }
                else
                {
                    // If player is not pressing anything, stop run animation.

                    PlayerWeaponAnimation.StopWeaponRunAnimation();
                }
            }
            else
            {
                // If player is not pressing anything, stop run animation.

                PlayerWeaponAnimation.StopWeaponRunAnimation();
            }
        }
    }
}