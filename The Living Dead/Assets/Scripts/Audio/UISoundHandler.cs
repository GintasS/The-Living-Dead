using UnityEngine;

/// <summary>
/// Class that plays UI sounds.
/// </summary>
public sealed class UISoundHandler : MonoBehaviour
{
    [Header("UI Sound Settings")]
    [SerializeField]
    private AudioClip buttonClick;
    [SerializeField]
    private AudioClip buttonBuyClick;
    [SerializeField]
    private AudioSource audioSource;

    public void PlayButtonClickSound()
    {
        audioSource.clip = buttonClick;
        audioSource.Play();
    }

    public void PlayButtonBuyClickSound()
    {
        audioSource.clip = buttonBuyClick;
        audioSource.Play();
    }
}