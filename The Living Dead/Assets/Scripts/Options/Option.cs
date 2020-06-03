using UnityEngine;

/// <summary>
/// A base class for individual option.
/// </summary>
public abstract class Option : MonoBehaviour
{
    [SerializeField]
    protected string key;

    /// <summary>
    /// Save this particular option.
    /// </summary>
    public abstract void SaveOption();

    /// <summary>
    /// Try fill existing option.
    /// </summary>
    public abstract void TryFillSavedOption();

    /// <summary>
    /// Reset option value to the default one.
    /// </summary>
    public abstract void ResetOptionValueToDefault();
}