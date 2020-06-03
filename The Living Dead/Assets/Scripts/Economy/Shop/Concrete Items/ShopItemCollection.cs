using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A collection class to hold all the shop items for a particular shop.
/// </summary>
public sealed class ShopItemCollection : MonoBehaviour
{
    [SerializeField]
    private List<ShopItem> shopItems;
    [SerializeField]
    private int selectedItemIndex;

    /// <summary>
    /// Return next item(current index + 1) or the first item if the index is going to be out of bounds.
    /// </summary>
    public ShopItem NextItemOrFirst
    {
        get
        {
            selectedItemIndex = selectedItemIndex + 1 >= shopItems.Count ? 0 : selectedItemIndex + 1;
            return shopItems[selectedItemIndex];
        }
    }

    /// <summary>
    /// Return previous item(current index - 1) or the first item if the index is going to be out of bounds.
    /// </summary>
    public ShopItem PreviousItemOrFirst
    {
        get
        {
            selectedItemIndex = selectedItemIndex - 1 < 0 ? shopItems.Count - 1 : selectedItemIndex - 1;
            return shopItems[selectedItemIndex];
        }
    }

    /// <summary>
    /// Return currently selected item(current index).
    /// </summary>
    public ShopItem SelectedItem
    {
        get
        {
            return shopItems[selectedItemIndex];
        }
    }
}