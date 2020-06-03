using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// Class that handles Game scene mouse options.
/// </summary>
public sealed class GameSceneMouseOptions : MonoBehaviour
{
    [Header("Mouse Options")]
    [SerializeField]
    private MouseLook mouseLook;

    public void TrySetMouseOptions()
    {
        mouseLook.XSensitivity = PlayerPrefsWrapper.TryGetFloat(Constants.MouseOptionsKey.MouseSensitivityX) ?? mouseLook.XSensitivity;
        mouseLook.YSensitivity = PlayerPrefsWrapper.TryGetFloat(Constants.MouseOptionsKey.MouseSensitivityY) ?? mouseLook.YSensitivity;
        mouseLook.InvertMouse(PlayerPrefsWrapper.TryGetBool(Constants.MouseOptionsKey.InvertMouse));
    }
}