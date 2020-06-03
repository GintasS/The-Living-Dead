using UnityEngine;

/// <summary>
/// Shop item for shop radar utility.
/// </summary>
public sealed class ShopRadarShopUtilityItem : UniqueShopItem
{
    [Header("Script References")]
    [SerializeField]
    private ShopRadarUtilityActivatorHandler shopRadarUtilityActivatorHandler;

    public override void EquipItem()
    {
        isUniqueItemBought = true;
        shopRadarUtilityActivatorHandler.IsActive = true;
    }
}