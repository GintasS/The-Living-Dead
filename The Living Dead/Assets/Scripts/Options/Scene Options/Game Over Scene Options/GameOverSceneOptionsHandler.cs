using UnityEngine;

/// <summary>
/// Class that handles all the options for the GameOver scene.
/// </summary>
public sealed class GameOverSceneOptionsHandler : SceneOptionsHandler
{
    [Header("Game Over Audio Options")]
    [SerializeField]
    private GameOverSceneAudioOptions gameOverSceneAudioOptions;

    public override void TryActivateOptions()
    {
        gameOverSceneAudioOptions.TryActivateAudioOptions();
    }
}