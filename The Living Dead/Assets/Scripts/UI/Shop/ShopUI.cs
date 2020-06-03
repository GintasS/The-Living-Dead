using UnityEngine;

/// <summary>
/// Class that activates or deactivates shop window to display items.
/// </summary>
public sealed class ShopUI : MonoBehaviour
{
    [Header("Main Shop Settings")]
    [SerializeField]
    private GameObject shopWindow;
    [SerializeField]
    private bool isShopWindowOpen;
    [Header("Selected Shop Settings")]
    [SerializeField]
    private Shop selectedShop;

    /// <summary>
    /// Get currently selected shop instance.
    /// </summary>
    public Shop SelectedShop
    {
        get
        {
            return selectedShop;
        }
        set
        {
            selectedShop = value;
        }
    }

    /// <summary>
    /// Gets a state of shop window being active or not.
    /// </summary>
    public bool IsShopWindowActive
    {
        get
        {
            return isShopWindowOpen;
        }
    }

    /// <summary>
    /// ActivatesDeactivates shop window for a player to see.
    /// </summary>
    public void SetShopWindowActive()
    {
        shopWindow.SetActive(!isShopWindowOpen);
        isShopWindowOpen = !isShopWindowOpen;
    }
}