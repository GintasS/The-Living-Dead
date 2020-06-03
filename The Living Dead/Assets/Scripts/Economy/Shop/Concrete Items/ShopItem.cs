using System;
using UnityEngine;

/// <summary>
/// Base class for all shop items, be it a shop stackable item, shop unique item.
/// </summary>
[Serializable]
public abstract class ShopItem : MonoBehaviour
{
    [Header("Shop Item Information")]
    public new string name; 
    [TextArea]
    public string description;
    public Sprite icon;
    [Header("Shop Item Characteristics")]
    [Min(0)]
    public int buyCost;

    /// <summary>
    /// Whether a particular item can be added/equiped.
    /// </summary>
    public abstract bool IsShopItemCanBeEquiped { get; }

    /// <summary>
    /// Equip an item when a player buys it.
    /// </summary>
    public abstract void EquipItem();
}