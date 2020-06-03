using UnityEngine;

public static class ColliderExtensions
{
    /// <summary>
    /// Is a collider a zombie one?
    /// </summary>
    /// <returns>Whether a collider is a zombie one or not.</returns>
    public static bool IsZombieCollider(this Collider collider)
    {
        return collider.gameObject.layer == Constants.Layer.Zombie;
    }

    /// <summary>
    /// Is a collider a shop one?
    /// </summary>
    /// <returns>Whether a collider is a shop one or not.</returns>
    public static bool IsShopCollider(this Collider collider)
    {
        return collider.gameObject.layer == Constants.Layer.Shop;
    }
}