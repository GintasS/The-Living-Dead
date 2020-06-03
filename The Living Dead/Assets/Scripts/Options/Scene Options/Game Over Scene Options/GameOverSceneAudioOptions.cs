using UnityEngine;

/// <summary>
/// Class that handles GameOver scene audio options.
/// </summary>
public sealed class GameOverSceneAudioOptions : MonoBehaviour
{
    public void TryActivateAudioOptions()
    {
        AudioListener.volume = PlayerPrefsWrapper.TryGetFloat(Constants.AudioOptionsKey.MenuAudio) ?? AudioListener.volume;

        var isMenuAudioMuted = PlayerPrefsWrapper.TryGetBool(Constants.AudioOptionsKey.MuteMenuAudio);
        AudioListener.volume = isMenuAudioMuted.HasValue && isMenuAudioMuted.Value ? 0 : AudioListener.volume;
    }
}