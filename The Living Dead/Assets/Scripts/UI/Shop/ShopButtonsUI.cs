using UnityEngine;

/// <summary>
/// Class that handles shop buttons(previous, next, buy).
/// </summary>
public sealed class ShopButtonsUI : MonoBehaviour
{
    [Header("Button Settings")]
    [SerializeField]
    private GameObject shopBuyButton;
    [SerializeField]
    private GameObject shopAlreadyBoughtButton;
    [Header("Script References")]
    [SerializeField]
    private ShopDisplayItemUI shopDisplayItemUI;
    [SerializeField]
    private ShopBuyItemHandler shopBuyItemHandler;
    [SerializeField]
    private ShopUI shopUI;

    /// <summary>
    /// Activate buy logic on a buy button click.
    /// </summary>
    public void BuyItemButtonClick()
    {
        shopBuyItemHandler.TryBuyAndEquipItem(shopUI.SelectedShop.ShopItems.SelectedItem);
    }

    /// <summary>
    /// Activate previous item logic on a previous item button click.
    /// </summary>
    public void DisplayPreviousItemButtonClick()
    {
        shopDisplayItemUI.DisplayItem(shopUI.SelectedShop.ShopItems.PreviousItemOrFirst);
    }

    /// <summary>
    /// Activate next item logic on a next item button click.
    /// </summary>
    public void DisplayNextItemButtonClick()
    {
        shopDisplayItemUI.DisplayItem(shopUI.SelectedShop.ShopItems.NextItemOrFirst);
    }

    /// <summary>
    /// Try to update the buy button enabled state.
    /// The buy button state is determined by the currently selected item.
    /// </summary>
    public void TryUpdateBuyItemButtonState()
    {
        shopBuyButton.SetActive(shopBuyItemHandler.IsSelectedItemCanBeBought);
    }

    /// <summary>
    /// Try to update already bought button enabled state for unique items.
    /// </summary>
    public void TryUpdateAlreadyBoughtButtonState()
    {
        var selectedItem = shopUI.SelectedShop.ShopItems.SelectedItem;
        shopAlreadyBoughtButton.SetActive(
            selectedItem is UniqueShopItem uniqueShopItem && 
            !uniqueShopItem.IsShopItemCanBeEquiped
        );
    }
}