using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// A class that loads a Game scene asynchronosly, so that we could display the progress.
/// </summary>
public sealed class SceneLoaderHandler : MonoBehaviour
{
    [Header("Scene Loader Settings")]
    [SerializeField]
    private Slider progressBarSlider;

    void Start()
    {
        LoadScene(Constants.Scene.Game);
    }

    /// <summary>
    /// Load a scene.
    /// </summary>
    /// <param name="sceneName">Scene name to load.</param>
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsynchronosly(sceneName));
    }

    /// <summary>
    /// Load a scene asynchronosly.
    /// </summary>
    /// <param name="sceneName">Scene name to load.</param>
    private IEnumerator LoadSceneAsynchronosly(string sceneName)
    {
        var operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            progressBarSlider.value = Mathf.Clamp01(operation.progress / Constants.CustomValue.PointNine);
            yield return null;
        }
    }
}