using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that displays shop item to the shop UI.
/// </summary>
public sealed class ShopDisplayItemUI : MonoBehaviour
{
    [Header("Shop Item Placeholder Settings")]
    [SerializeField]
    private Text shopItemNamePlaceholder;
    [SerializeField]
    private Image shopItemIconPlaceholder;
    [SerializeField]
    private Text shopItemDescriptionPlaceholder;
    [SerializeField]
    private Text shopItemBuyCostPlaceholder;
    [Header("Script References")]
    [SerializeField]
    private ShopBuyItemHandler shopBuyItemHandler;

    private Color ShopItemColor
    {
        get
        {
            return shopBuyItemHandler.CanPlayerAffordSelectedItem ? Color.green : Color.red;
        }
    }

    /// <summary>
    /// Display ShopItem to the shop UI through the placeholders.
    /// </summary>
    /// <param name="shopItem">ShopItem to display.</param>
    public void DisplayItem(ShopItem shopItem)
    {
        shopItemNamePlaceholder.text = shopItem.name;
        shopItemDescriptionPlaceholder.text = shopItem.description;
        shopItemIconPlaceholder.sprite = shopItem.icon;
        shopItemBuyCostPlaceholder.text = shopItem.buyCost.ToString();
        shopItemBuyCostPlaceholder.color = ShopItemColor;
    }
}