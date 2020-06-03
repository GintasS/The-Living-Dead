using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// <summary>
/// Class for generating pseudo-random background image.
/// </summary>
public sealed class RandomBackgroundImageHandler : MonoBehaviour
{
    [Header("Random Background Image Settings")]
    [SerializeField]
    private Image backgroundImagePlaceholder;
    [SerializeField]
    private List<Sprite> backgroundImages;

    /// <summary>
    /// Return and set a random background image from the list.
    /// </summary>
    public void SetRandomBackgroundImage()
    {
        backgroundImagePlaceholder.sprite = backgroundImages.GetRandomElementOrDefault();
    }
}