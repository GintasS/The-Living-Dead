using UnityEngine;

/// <summary>
/// Class that handles Game scene video options.
/// </summary>
public sealed class GameSceneVideoOptions : MonoBehaviour
{
    [Header("Video Options")]
    [SerializeField]
    private new Camera camera;

    public void TrySetVideoOptions()
    {
        camera.fieldOfView = PlayerPrefsWrapper.TryGetFloat(Constants.VideoOptionsKey.FieldOfView) ?? camera.fieldOfView;
        camera.farClipPlane = PlayerPrefsWrapper.TryGetFloat(Constants.VideoOptionsKey.DrawDistance) ?? camera.farClipPlane;
    }
}