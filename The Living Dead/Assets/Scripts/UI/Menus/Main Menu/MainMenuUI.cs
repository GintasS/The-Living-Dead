using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that handles menu buttons(such as play, exit) for the Main Menu scene.
/// </summary>
public sealed class MainMenuUI : MonoBehaviour
{
    [Header("About Window Settings")]
    [SerializeField]
    private AboutWindowUI aboutWindowUI;
    [Header("Options Window Settings")]
    [SerializeField]
    private OptionsWindowUI optionsWindowUI;
    [Header("Script References")]
    [SerializeField]
    private RandomBackgroundImageHandler randomBackgroundImageHandler;
    [SerializeField]
    private OptionsHandler optionsHandler;
    [SerializeField]
    private MainMenuSceneOptionsHandler mainMenuSceneOptionsHandler;

    void Awake()
    {
        optionsHandler.TryFillSavedOptions();
        mainMenuSceneOptionsHandler.TryActivateOptions();
        randomBackgroundImageHandler.SetRandomBackgroundImage();
    }

    /// <summary>
    /// Activate Game scene load logic on the play button click.
    /// </summary>
    public void PlayButtonClick()
    {
        if (!aboutWindowUI.IsWindowOpen && !optionsWindowUI.IsWindowOpen)
        {
            SceneManager.LoadSceneAsync(Constants.Scene.Loading);
        }
    }

    /// <summary>
    /// Activate about the game window logic on a about button click.
    /// </summary>
    public void AboutButtonClick()
    {
        if (!optionsWindowUI.IsWindowOpen)
        {
            aboutWindowUI.SetWindowActive();
        }
    }

    /// <summary>
    /// Activate options window logic on a options button click.
    /// </summary>
    public void OptionsButtonClick()
    {
        if (!aboutWindowUI.IsWindowOpen)
        {
            if (optionsWindowUI.IsWindowOpen)
            {
                optionsHandler.SaveOptions();
            }
            optionsWindowUI.SetWindowActive();
        }
    }

    /// <summary>
    /// Activate exit game logic on a exit button click.
    /// </summary>
    public void ExitButtonClick()
    {
        if (!aboutWindowUI.IsWindowOpen && !optionsWindowUI.IsWindowOpen)
        {
            Application.Quit();
        }
    }
}