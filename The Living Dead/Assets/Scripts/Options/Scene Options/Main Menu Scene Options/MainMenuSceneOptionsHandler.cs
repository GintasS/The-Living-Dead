using UnityEngine;

/// <summary>
/// Class that handles all the options for the Main Menu scene.
/// </summary>
public sealed class MainMenuSceneOptionsHandler : SceneOptionsHandler
{
    [Header("Main Menu Audio Options")]
    [SerializeField]
    private MainMenuSceneAudioOptions mainMenuSceneAudioOptions;

    public override void TryActivateOptions()
    {
        mainMenuSceneAudioOptions.TryActivateAudioOptions();
    }
}