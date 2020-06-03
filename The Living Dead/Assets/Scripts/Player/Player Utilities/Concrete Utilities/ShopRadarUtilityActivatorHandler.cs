using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Class that actually calculates the distance to the nearest shop.
/// </summary>
public sealed class ShopRadarUtilityActivatorHandler : PlayerUtility
{
    [Header("Shop Radar Settings")]
    [SerializeField]
    private List<GameObject> allShops;
    [SerializeField]
    private GameObject player; 

    /// <summary>
    /// Returns distance to the nearest shop as a text or "-" if the utility is not bought.
    /// </summary>
    public string ShopDistance
    {
        get
        {
            return IsActive ? GetDistanceToNearestShop().ToString() + Constants.UnitText.SpaceMetre : 
                Constants.Character.Minus;
        }
    }

    /// <summary>
    /// Calculate distance to the nearest shop.
    /// </summary>
    /// <returns>Distance to the nearest shop.</returns>
    private int GetDistanceToNearestShop()
    {
        return allShops.Select(x => (int)Vector3.Distance(player.transform.position, x.transform.position))
            .OrderBy(x => x)
            .FirstOrDefault();
    }
}