using UnityEngine;

/// <summary>
/// Class that represents an item that can only be bought once, i.e unique.
/// </summary>
public abstract class UniqueShopItem : ShopItem
{
    [Header("Unique Item Settings")]
    [SerializeField]
    protected bool isUniqueItemBought;

    public override bool IsShopItemCanBeEquiped
    {
        get
        {
            return !isUniqueItemBought;
        }
    }
}