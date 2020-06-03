using UnityEngine;

/// <summary>
/// Shop item for zombie counter utility.
/// </summary>
public sealed class ZombieCounterShopUtilityItem : UniqueShopItem
{
    [Header("Script References")]
    [SerializeField]
    private ZombieCounterUtilityActivatorHandler zombieCounterUtilityActivatorHandler;

    public override void EquipItem()
    {
        isUniqueItemBought = true;
        zombieCounterUtilityActivatorHandler.IsActive = true;
    }
}