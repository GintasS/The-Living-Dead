/// <summary>
/// Class that saves and retrieves zombie round statistics data for the GameOver scene.
/// </summary>
public static class ZombieRoundStatisticsHandler
{
    /// <summary>
    /// How many zombie rounds has the player survived
    /// </summary>
    private static int zombieRoundsSurvived;

    /// <summary>
    /// Save value to the zombie round statistics.
    /// </summary>
    /// <param name="zombieRoundStatisticsType">Type of statistics to save.</param>
    /// <param name="value">Value to save.</param>
    public static void SaveStatistics(ZombieRoundStatisticsType zombieRoundStatisticsType, dynamic value)
    {
        switch (zombieRoundStatisticsType)
        {
            case ZombieRoundStatisticsType.ZombieRoundsSurvived:
                zombieRoundsSurvived = (int)(object)value;
                break;
        }
    }

    /// <summary>
    /// Get value by the statistics type.
    /// </summary>
    /// <param name="zombieRoundStatisticsType">Type of statistics to get.</param>
    /// <returns>A statistics value.</returns>
    public static dynamic GetStatistics(ZombieRoundStatisticsType zombieRoundStatisticsType)
    {
        switch (zombieRoundStatisticsType)
        {
            case ZombieRoundStatisticsType.ZombieRoundsSurvived:
                return zombieRoundsSurvived;
        }
        return new object();
    }
}