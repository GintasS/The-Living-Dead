using UnityEngine;

/// <summary>
/// Class that handles all the options for the Game scene.
/// </summary>
public sealed class GameSceneOptionsHandler: SceneOptionsHandler
{
    [Header("Video Options")]
    [SerializeField]
    private GameSceneVideoOptions gameSceneVideoOptions;
    [Header("Audio Options")]
    [SerializeField]
    private GameSceneAudioOptions gameSceneAudioOptions;
    [Header("Mouse Options")]
    [SerializeField]
    private GameSceneMouseOptions gameSceneMouseOptions;
    [Header("Game Options")]
    [SerializeField]
    private GameSceneGameOptions gameSceneGameOptions;

    public override void TryActivateOptions()
    {
        gameSceneVideoOptions.TrySetVideoOptions();
        gameSceneAudioOptions.TrySetAudioOptions();
        gameSceneMouseOptions.TrySetMouseOptions();
        gameSceneGameOptions.TrySetGameOptions();
    }
}