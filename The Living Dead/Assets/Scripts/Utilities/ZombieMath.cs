/// <summary>
/// Class that handles various zombie math methods.
/// </summary>
public static class ZombieMath
{
    /// <summary>
    /// Get the minimum zombie number for this specific round.
    /// Function signature is: y = 2 * roundNumber + 3.
    /// </summary>
    /// <param name="roundNumber">Current zombie round number.</param>
    /// <returns>Minimum number.</returns>
    public static int GetMinimumZombieNumberForSpecificRound(int roundNumber)
    {
        return 2 * roundNumber + 3;
    }

    /// <summary>
    /// Get the maximum zombie number for this specific round.
    /// Function signature is: y = 5 * roundNumber + 5.
    /// </summary>
    /// <param name="roundNumber">Current zombie round number.</param>
    /// <returns>Maximum number.</returns>
    public static int GetMaximumZombieNumberForSpecificRound(int roundNumber)
    {
        return 5 * roundNumber + 5;
    }
}