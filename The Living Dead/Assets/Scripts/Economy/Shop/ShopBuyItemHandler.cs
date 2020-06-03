using UnityEngine;

/// <summary>
/// Class that is responsible for managing the buying aspect for the shop.
/// </summary>
public sealed class ShopBuyItemHandler : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField]
    private PlayerMoney playerMoney;
    [SerializeField]
    private ShopUI shopUI;

    /// <summary>
    /// Whether currently selected item can be bought.
    /// </summary>
    public bool IsSelectedItemCanBeBought
    {
        get
        {
            return shopUI.SelectedShop != null && 
                shopUI.SelectedShop.ShopItems.SelectedItem.IsShopItemCanBeEquiped &&
                CanPlayerAffordSelectedItem;
        }
    }

    /// <summary>
    /// Whether the player can afford currently selected item.
    /// </summary>
    public bool CanPlayerAffordSelectedItem
    {
        get
        {
            var shopItem = shopUI.SelectedShop.ShopItems.SelectedItem;
            return playerMoney.CanAffordPurchase(shopItem.buyCost);
        }
    }

    /// <summary>
    /// Try to buy and equip user selected item.
    /// </summary>
    /// <param name="selectedItem">Shop item to buy and equip.</param>
    public void TryBuyAndEquipItem(ShopItem selectedItem)
    {
        if (!IsSelectedItemCanBeBought)
        {
            return;
        }

        selectedItem.EquipItem();
        playerMoney.TrySubtractMoney(selectedItem.buyCost);
    }
}