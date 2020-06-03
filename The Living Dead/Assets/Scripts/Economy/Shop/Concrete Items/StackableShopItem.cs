using UnityEngine;

/// <summary>
/// Class that represents an item that can be stacked, i.e the item that can be added to the pile of an already
/// existing items.
/// </summary>
public abstract class StackableShopItem : ShopItem
{
    [Header("Stackable Item Settings")]
    [SerializeField]
    [Min(0)]
    protected int buyAmount;

    public int BuyAmount
    {
        get
        {
            return buyAmount;
        }
    }
}