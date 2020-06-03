using UnityEngine;

/// <summary>
/// Class that handles Game scene audio options.
/// </summary>
public sealed class GameSceneAudioOptions : MonoBehaviour
{
    public void TrySetAudioOptions()
    {
        AudioListener.volume = PlayerPrefsWrapper.TryGetFloat(Constants.AudioOptionsKey.GameAudio) ?? AudioListener.volume;

        var isGameAudioMuted = PlayerPrefsWrapper.TryGetBool(Constants.AudioOptionsKey.MuteGameAudio);
        AudioListener.volume = isGameAudioMuted.HasValue && isGameAudioMuted.Value ? 0 : AudioListener.volume;
    }
}
