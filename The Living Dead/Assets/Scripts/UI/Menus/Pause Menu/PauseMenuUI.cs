using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that handles pause menu buttons(such as resume, restart) for the Pause Menu window.
/// </summary>
public sealed class PauseMenuUI : MonoBehaviour
{
    [Header("Pause Menu Settings")]
    [SerializeField]
    private GameObject pauseWindow;
    [Header("Script References")]
    [SerializeField]
    private RandomBackgroundImageHandler randomBackgroundImageHandler;
    [SerializeField]
    private GameStateHandler gameStateHandler;

    void Awake()
    {
        randomBackgroundImageHandler.SetRandomBackgroundImage();
    }

    /// <summary>
    /// ActivatesDeactivates pause window, based on if it's already open or not.
    /// </summary>
    public void SetPauseWindowActive()
    {
        pauseWindow.SetActive(gameStateHandler.IsGamePaused);
    }

    /// <summary>
    /// Activate resume game logic on a resume button click.
    /// </summary>
    public void ResumeButtonClick()
    {
        gameStateHandler.SetPauseGameState();
    }

    /// <summary>
    /// Activate Game scene load logic on the play button click.
    /// </summary>
    public void RestartGameButtonClick()
    {
        gameStateHandler.ResetTimeScale();
        SceneManager.LoadSceneAsync(Constants.Scene.Loading);
    }

    /// <summary>
    /// Activate MainMenu scene load logic on a main menu button click.
    /// </summary>
    public void MainMenuButtonClick()
    {
        gameStateHandler.ResetTimeScale();
        SceneManager.LoadScene(Constants.Scene.MainMenu);
    }

    /// <summary>
    /// Activate exit game logic on a exit button click.
    /// </summary>
    public void ExitButtonClick()
    {
        Application.Quit();
    }
}