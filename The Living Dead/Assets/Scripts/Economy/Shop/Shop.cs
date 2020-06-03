using UnityEngine;

/// <summary>
/// A class for a single shop instance with shop items that a player can buy.
/// It also displays, hides shop UI with this shop's data.
/// </summary>
public sealed class Shop : MonoBehaviour
{
    [Header("Shop General Settings")]
    [SerializeField]
    private new string name;
    [Header("Shop Items Available To Buy")]
    [SerializeField]
    private ShopItemCollection shopItems;
    [Header("Script References")]
    [SerializeField]
    private ShopUI shopUI;
    [SerializeField]
    private ShopButtonsUI shopButtonsUI;
    [SerializeField]
    private ShopDisplayItemUI shopDisplayItemUI;
    [SerializeField]
    private ShopDisplayShopDataUI shopDisplayShopDataUI;
    [SerializeField]
    private PlayerHUDHandler playerHUDHandler;

    public string ShopName
    {
        get
        {
            return name;
        }
    }

    /// <summary>
    /// Available shop items to buy for this particular shop.
    /// </summary>
    public ShopItemCollection ShopItems
    {
        get
        {
            return shopItems;
        }
    }

    /// <summary>
    /// Activate particular shop's logic on a trigger enter.
    /// </summary>
    void OnTriggerEnter(Collider collider)
    {
        if (collider.IsShopCollider())
        {
            shopUI.SelectedShop = this;
            shopDisplayShopDataUI.DisplayShopName(this);
            shopDisplayItemUI.DisplayItem(shopItems.SelectedItem);
            shopUI.SetShopWindowActive();
            shopButtonsUI.TryUpdateBuyItemButtonState();
            shopButtonsUI.TryUpdateAlreadyBoughtButtonState();
            playerHUDHandler.SetPlayerShopModeActive();
        }
    }

    /// <summary>
    /// Try to update shop logic while player is browsing the shop.
    /// </summary>
    void OnTriggerStay(Collider collider)
    {
        if (collider.IsShopCollider())
        {
            shopButtonsUI.TryUpdateBuyItemButtonState();
            shopButtonsUI.TryUpdateAlreadyBoughtButtonState();
            shopDisplayItemUI.DisplayItem(shopItems.SelectedItem);
        }
    }

    /// <summary>
    /// Deactivate shop's logic on a trigger exit.
    /// </summary>
    void OnTriggerExit(Collider collider)
    {
        if (collider.IsShopCollider())
        {
            shopUI.SetShopWindowActive();
            playerHUDHandler.SetPlayerShopModeActive();
        }
    }
}