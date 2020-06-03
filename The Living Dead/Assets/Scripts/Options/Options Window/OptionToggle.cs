using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Option class that allows player to set option value via toggle.
/// </summary>
public sealed class OptionToggle : Option
{
    [Header("Option Configuration Settings")]
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private bool defaultValue;

    /// <summary>
    /// Save option value to player prefs.
    /// </summary>
    public override void SaveOption()
    {
        PlayerPrefsWrapper.SetBool(key, toggle.isOn);
    }

    /// <summary>
    /// Try fill saved option's value to the existing option toggle.
    /// </summary>
    public override void TryFillSavedOption()
    {
        toggle.isOn = PlayerPrefsWrapper.TryGetBool(key) ?? toggle.isOn;
    }

    public override void ResetOptionValueToDefault()
    {
        toggle.isOn = defaultValue;
    }
}