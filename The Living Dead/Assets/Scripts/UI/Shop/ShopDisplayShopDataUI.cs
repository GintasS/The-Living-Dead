using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that displays a particular shop's data, such as name or something else.
/// </summary>
public sealed class ShopDisplayShopDataUI : MonoBehaviour
{
    [Header("Display Shop Data Settings")]
    [SerializeField]
    private Text shopNamePlaceholder;

    /// <summary>
    /// Display shop name for a particular shop.
    /// </summary>
    /// <param name="shop">Shop instance for which to display a name.</param>
    public void DisplayShopName(Shop shop)
    {
        shopNamePlaceholder.text = shop.ShopName;
    }
}