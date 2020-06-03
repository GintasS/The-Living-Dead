using UnityEngine;

/// <summary>
/// Class that generates a maximum zombies in a specific round number.
/// </summary>
public sealed class MaxZombiesInSpecificRoundNumberHandler : MonoBehaviour
{
    [Header("Max Zombies In X Round")]
    [SerializeField]
    private int maxZombiesInCurrentRound;

    /// <summary>
    /// How many zombies can be in a specific round.
    /// </summary>
    public int MaxZombiesInCurrentRound
    {
        get
        {
            return maxZombiesInCurrentRound;
        }
    }

    /// <summary>
    /// Generate maximum zombie number for this partciular round.
    /// </summary>
    /// <param name="roundNumber">Current zombie round number.</param>
    public void SetMaximumZombieNumberForSpecificRound(int roundNumber)
    {
        maxZombiesInCurrentRound = RandomNumberGenerator.GenerateZombieNumberForSpecificRound(roundNumber);
    }
}