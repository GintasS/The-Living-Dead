using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Option class that allows player to set option value via slider.
/// </summary>
[ExecuteInEditMode]
public sealed class OptionSlider : Option
{
    [Header("Option Configuration Settings")]
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private OptionSaveType optionSaveType;
    [SerializeField]
    private float defaultValue;

    /// <summary>
    /// Save option value to player prefs.
    /// </summary>
    public override void SaveOption()
    {
        switch (optionSaveType)
        {
            case OptionSaveType.Float:
                PlayerPrefsWrapper.SetFloat(key, slider.value);
                break;
            case OptionSaveType.Int:
                PlayerPrefsWrapper.SetInt(key, (int)slider.value);
                break;
        }
    }

    /// <summary>
    /// Try fill saved option's value to the existing option slider.
    /// </summary>
    public override void TryFillSavedOption()
    {
        switch (optionSaveType)
        {
            case OptionSaveType.Float:
                slider.value = PlayerPrefsWrapper.TryGetFloat(key) ?? slider.value;
                break;
            case OptionSaveType.Int:
                slider.value = PlayerPrefsWrapper.TryGetInt(key) ?? slider.value;
                break;
        }
    }

    public override void ResetOptionValueToDefault()
    {
        slider.value = defaultValue;
    }
}