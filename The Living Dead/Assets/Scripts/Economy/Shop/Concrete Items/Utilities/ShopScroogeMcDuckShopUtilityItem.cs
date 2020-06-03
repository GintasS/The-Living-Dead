using UnityEngine;

/// <summary>
/// Shop item for scrooge mc duck utility.
/// </summary>
public sealed class ShopScroogeMcDuckShopUtilityItem : UniqueShopItem
{
    [Header("Script References")]
    [SerializeField]
    private ScroogeMcDuckUtilityActivatorHandler scroogeMcDuckUtilityActivatorHandler;

    public override void EquipItem()
    {
        isUniqueItemBought = true;
        scroogeMcDuckUtilityActivatorHandler.IncreaseMoneyAwardPerZombieKill();
    }
}