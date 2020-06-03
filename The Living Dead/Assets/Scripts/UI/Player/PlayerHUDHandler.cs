using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// Class that handles Player HUD(such as money, health).
/// </summary>
public sealed class PlayerHUDHandler : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField]
    private Text healthText;
    [Header("Money Settings")]
    [SerializeField]
    private Text moneyText;
    [Header("Ammo Settings")]
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Text ammoClipsText;
    [Header("Utility Settings")]
    [SerializeField]
    private Text shopRadarText;
    [SerializeField]
    private Text zombieCounterText;
    [Header("Round Settings")]
    [SerializeField]
    private GameObject roundPauseWindow;
    [SerializeField]
    private Text roundPauseTimerText;
    [SerializeField]
    private Text currentRoundNumberText;
    [Header("Misc Settings")]
    [SerializeField]
    private GameObject playerAdditionalHUD;
    [SerializeField]
    private bool isPlayerAdditionalHUDActive;
    [Header("Script References")]
    [SerializeField]
    private PlayerWeaponEquipHandler playerWeaponEquipHandler;
    [SerializeField]
    private FirstPersonController firstPersonController;
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField] 
    private PlayerMoney playerMoney;
    [SerializeField]
    private ZombieRoundHandler zombieRoundHandler;
    [SerializeField]
    private ShopRadarUtilityActivatorHandler shopRadarUtilityActivatorHandler;
    [SerializeField]
    private ZombieCounterUtilityActivatorHandler zombieCounterUtilityActivatorHandler;
    [SerializeField]
    private ShopUI shopUI;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        DisplayAllHuds();
    }

    /// <summary>
    /// Display all available huds(health, ammo, round) and more.
    /// </summary>
    private void DisplayAllHuds()
    {
        DisplayText(healthText, playerHealth.CurrentHealth.ToString());
        DisplayText(ammoText, playerWeaponEquipHandler.EquipedWeapon.WeaponAmmo.CurrentAmmo.ToString());
        DisplayText(ammoClipsText, playerWeaponEquipHandler.EquipedWeapon.WeaponAmmo.CurrentAmmoClips.ToString());
        DisplayText(moneyText, playerMoney.CurrentMoney.ToString());
        DisplayText(currentRoundNumberText, zombieRoundHandler.CurrentRound.ToString());
        DisplayText(shopRadarText, shopRadarUtilityActivatorHandler.ShopDistance);
        DisplayText(zombieCounterText, zombieCounterUtilityActivatorHandler.ActiveZombies);
        DisplayText(roundPauseTimerText, zombieRoundHandler.RoundPauseTimer);
    }

    /// <summary>
    /// Display text value for a specific Text component.
    /// </summary>
    /// <param name="textUI">Text component to display into.</param>
    /// <param name="value">Text value to display.</param>
    private void DisplayText(Text textUI, string value)
    {
        textUI.text = value;
    }

    /// <summary>
    /// ActivatesDeactivates the round pause window, based on the value passed.
    /// </summary>
    /// <param name="value">State value: false is deactivated, true is activated.</param>
    public void SetRoundPauseWindowActive(bool value)
    {
        roundPauseWindow.SetActive(value);
    }

    /// <summary>
    /// ActivatesDeactivates player additional HUD, based on if it's already open or not.
    /// </summary>
    public void SetPlayerAddionalHUDActive()
    {
        playerAdditionalHUD.SetActive(!isPlayerAdditionalHUDActive);
        isPlayerAdditionalHUDActive = !isPlayerAdditionalHUDActive;
    }
      
    /// <summary>
    /// ActivatesDeactivates player shop mode UI, based on if it's already active or not.
    /// </summary>
    public void SetPlayerShopModeActive()
    {
        Cursor.lockState = !shopUI.IsShopWindowActive ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = shopUI.IsShopWindowActive;
        firstPersonController.isCameraFollowingMouseInput = !shopUI.IsShopWindowActive;
    }
}