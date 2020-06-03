using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for a UI component that combines default Unity Slider component with Input Field.
/// </summary>
public sealed class SliderWithInputFieldUI : MonoBehaviour
{
    [Header("Slider With Input Field Settings")]
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private InputField sliderInputField;
    [SerializeField]
    private string textFormat;

    void Awake()
    {
        OnSliderValueChanged(slider.value);
        OnInputFieldEndEdit(slider.value.ToString());
    }

    /// <summary>
    /// Activate event subscription logic when the attached GameObject is toggled on.
    /// </summary>
    void OnEnable()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        sliderInputField.onEndEdit.AddListener(OnInputFieldEndEdit);
    }

    /// <summary>
    /// Activate event unsubscription logic when the attached GameObject is toggled off.
    /// </summary>
    void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
        sliderInputField.onEndEdit.RemoveAllListeners();
    }

    /// <summary>
    /// Update Input Field with the Slider's value.
    /// </summary>
    /// <param name="value">Slider value</param>
    private void OnSliderValueChanged(float value)
    {
        sliderInputField.text = value.ToString(textFormat);
    }

    /// <summary>
    /// Update Slider value with the parsed text from the Input Field.
    /// </summary>
    /// <param name="text">Input Field text.</param>
    private void OnInputFieldEndEdit(string text)
    {
        if (float.TryParse(text, out var result) && slider.maxValue >= result 
            && slider.minValue <= result)
        {
            slider.value = result;
        }
        sliderInputField.text = slider.value.ToString(textFormat);
    }
}