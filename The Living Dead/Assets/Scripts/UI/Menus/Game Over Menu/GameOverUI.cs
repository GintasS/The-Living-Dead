using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that handles GameOver scene's UI.
/// </summary>
public sealed class GameOverUI : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField]
    private RandomBackgroundImageHandler randomBackgroundImageHandler;
    [SerializeField]
    private GameOverSceneOptionsHandler gameOverSceneOptionsHandler;

    void Awake()
    {
        gameOverSceneOptionsHandler.TryActivateOptions();
        randomBackgroundImageHandler.SetRandomBackgroundImage();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Activate MainMenu scene load logic on a main menu button click.
    /// </summary>
    public void MainMenuButtonClick()
    {
        SceneManager.LoadScene(Constants.Scene.MainMenu);
    }

    /// <summary>
    /// Activate Game scene load logic on the restart the game button click.
    /// </summary>
    public void RestartButtonClick()
    {
        SceneManager.LoadSceneAsync(Constants.Scene.Loading);
    }
}