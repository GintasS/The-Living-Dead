using UnityEngine;

/// <summary>
/// Base class for specific scene's options handler.
/// </summary>
public abstract class SceneOptionsHandler : MonoBehaviour
{
    /// <summary>
    /// Try to activate all the options for a specific scene.
    /// </summary>
    public abstract void TryActivateOptions();
}