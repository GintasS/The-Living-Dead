using UnityEngine;

/// <summary>
/// Shop item for player health regeneration utility.
/// </summary>
public sealed class PlayerHealthRegenerationShopUtilityItem : UniqueShopItem
{
    [Header("Script References")]
    [SerializeField]
    private PlayerHealthRegenerationActivatorHandler playerHealthRegenerationActivatorHandler;

    public override void EquipItem()
    {
        isUniqueItemBought = true;
        playerHealthRegenerationActivatorHandler.StartRegeneratingHealth();
    }
}