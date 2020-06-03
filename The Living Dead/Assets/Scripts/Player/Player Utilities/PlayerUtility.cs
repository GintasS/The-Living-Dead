using UnityEngine;

/// <summary>
/// Base class for all utility activator handlers.
/// </summary>
public abstract class PlayerUtility : MonoBehaviour
{
    [Header("Utility Settings")]
    [SerializeField]
    protected bool isActive;

    /// <summary>
    /// Whether a particular utility is already activated or not.
    /// </summary>
    public bool IsActive
    {
        get
        {
            return isActive;
        }
        set
        {
            isActive = value;
        }
    }
}