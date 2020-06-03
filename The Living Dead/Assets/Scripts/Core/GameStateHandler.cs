using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that handles the game, by ending the game, pausing it.
/// </summary>
public sealed class GameStateHandler : MonoBehaviour
{
    [Header("Game State Settings")]
    [SerializeField]
    private bool isGamePaused;
    [Header("Script References")]
    [SerializeField]
    private PauseMenuUI pauseMenuUI;
    [SerializeField]
    private GameSceneOptionsHandler gameSceneOptionsHandler;
    [SerializeField]
    private ZombieRoundHandler zombieRoundHandler;

    public bool IsGamePaused
    {
        get
        {
            return isGamePaused;
        }
        set
        {
            isGamePaused = value;
        }
    }

    void Start()
    {
        gameSceneOptionsHandler.TryActivateOptions();
    }

    /// <summary>
    /// End the game by loading a Game Over scene.
    /// </summary>
    public void EndGame()
    {
        ZombieRoundStatisticsHandler.SaveStatistics(ZombieRoundStatisticsType.ZombieRoundsSurvived, zombieRoundHandler.CurrentRound - 1);
        SceneManager.LoadScene(Constants.Scene.GameOver);
    }

    /// <summary>
    /// ActivatesDeactivates pause menu UI, based if it's already active or not.
    /// </summary>
    public void SetPauseGameState()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? Constants.TimeScale.PausedTimeScale : Constants.TimeScale.DefaultTimeScale;
        Cursor.lockState = isGamePaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isGamePaused;
        pauseMenuUI.SetPauseWindowActive();
    }

    public void ResetTimeScale()
    {
        Time.timeScale = Constants.TimeScale.DefaultTimeScale;
    }
}