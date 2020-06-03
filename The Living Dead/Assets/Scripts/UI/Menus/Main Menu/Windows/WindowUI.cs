using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Base class for all UI windows. 
/// </summary>
public abstract class WindowUI : MonoBehaviour
{
    [Header("Window Settings")]
    [SerializeField]
    protected GameObject windowObject;
    [SerializeField]
    protected Scrollbar scrollbar;
    [SerializeField]
    protected bool isWindowOpen;

    /// <summary>
    /// Gets a state of UI window being active or not.
    /// </summary>
    public bool IsWindowOpen
    {
        get
        {
            return isWindowOpen;
        }
    }

    /// <summary>
    /// ActivatesDeactivates window, based on if it's already open or not.
    /// </summary>
    public void SetWindowActive()
    {
        windowObject.SetActive(!isWindowOpen);
        isWindowOpen = !isWindowOpen;
    }

    /// <summary>
    /// Resets scrollbar value for the window.
    /// </summary>
    /// <remarks>
    /// This is done so that the player would see window's content from the starting position
    /// instead of the window's last position when the player has left.
    /// </remarks>
    public void ResetWindowScrollbarValue()
    {
        scrollbar.value = Constants.CustomValue.SliderMaxValue;
    }
}