using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles all important things related to opions, retrieving, saving, filling, resetting.
/// </summary>
public sealed class OptionsHandler : MonoBehaviour
{
    [Header("Option Settings")]
    [SerializeField]
    private List<Option> videoOptions;
    [SerializeField]
    private List<Option> audioOptions;
    [SerializeField]
    private List<Option> mouseOptions;
    [SerializeField]
    private List<Option> gameOptions;

    /// <summary>
    /// Save options to player prefs.
    /// </summary>
    public void SaveOptions()
    {
        PerformActionOnOptions((x) => x.SaveOption());
    }
    
    /// <summary>
    /// Try fill existing options to the Options window.
    /// </summary>
    public void TryFillSavedOptions()
    {
        PerformActionOnOptions((x) => x.TryFillSavedOption());
    }

    /// <summary>
    /// Reset option values to their default values.
    /// </summary>
    public void ResetOptions()
    {
        PerformActionOnOptions((x) => x.ResetOptionValueToDefault());
    }

    /// <summary>
    /// Perform a specific action on a every type of options.
    /// </summary>
    /// <param name="action">Action to perform</param>
    private void PerformActionOnOptions(Action<Option> action)
    {
        videoOptions.ForEach(action);
        audioOptions.ForEach(action);
        mouseOptions.ForEach(action);
        gameOptions.ForEach(action);
    }
}