using UnityEngine;

/// <summary>
/// Class for generating pseudo-random data.
/// </summary>
public static class RandomNumberGenerator
{
    /// <summary>
    /// Return a random integer number between min [inclusive] and max [exclusive].
    /// </summary>
    /// <returns>A pseudo-random number.</returns>
    public static int Generate(int min, int max)
    {
        return Random.Range(min, max);
    }

    /// <summary>
    /// Return a random float number between min [inclusive] and max [exclusive].
    /// </summary>
    /// <returns>A pseudo-random number.</returns>
    public static float Generate(float min, float max)
    {
        return Random.Range(min, max);
    }

    /// <summary>
    /// Return a random int number from attack strength instance.
    /// </summary>
    /// <param name="attackStrength">AttackStrength instance to generate from.</param>
    /// <returns>A pseudo-random number.</returns>
    public static int Generate(AttackStrength attackStrength)
    {
        return Random.Range(attackStrength.AttackStrengthMin, attackStrength.AttackStrengthMax);
    }

    /// <summary>
    /// Return a random zombie number for a specific round with a help of special zombie math functions.
    /// </summary>
    /// <param name="roundNumber">Current zombie round number.</param>
    /// <returns>A pseudo-random number.</returns>
    public static int GenerateZombieNumberForSpecificRound(int roundNumber)
    {
        var min = ZombieMath.GetMinimumZombieNumberForSpecificRound(roundNumber);
        var max = ZombieMath.GetMaximumZombieNumberForSpecificRound(roundNumber);

        return Generate(min, max);
    }
}