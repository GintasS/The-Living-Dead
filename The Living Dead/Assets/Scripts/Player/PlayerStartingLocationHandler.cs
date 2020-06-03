using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that sets a random starting location for the player.
/// </summary>
public sealed class PlayerStartingLocationHandler : MonoBehaviour
{
    [Header("Player Starting Location Settings")]
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private List<GameObject> spawnLocations;
    [Header("Script References")]
    [SerializeField]
    private CharacterController characterController;

    void Awake()
    {
        SetCharacterControllerActive(false);
        SetRandomPlayerStartingPosition();
        SetCharacterControllerActive(true);
    }

    /// <summary>
    /// ActivatesDeactivates character controller, based on if it's already open or not.
    /// </summary>
    /// <param name="value">State value: false to deactivate, true to activate.</param>
    private void SetCharacterControllerActive(bool value)
    {
        characterController.enabled = value;
    }

    /// <summary>
    /// Set random player starting position.
    /// </summary>
    public void SetRandomPlayerStartingPosition()
    {
        var randomIndex = RandomNumberGenerator.Generate(0, spawnLocations.Count);
        player.transform.position = spawnLocations[randomIndex].transform.position;
    }
}