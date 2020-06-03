using UnityEngine;

/// <summary>
/// Class that actually returns the active zombies for the player.
/// </summary>
public sealed class ZombieCounterUtilityActivatorHandler : PlayerUtility
{
    [Header("Script References")]
    [SerializeField]
    private ZombieSpawnHandler zombieSpawnHandler;

    /// <summary>
    /// Get active zombies or "-" if the utility is not bought.
    /// </summary>
    public string ActiveZombies
    {
        get
        {
            return IsActive ? zombieSpawnHandler.ActiveZombies.ToString() : 
                Constants.Character.Minus;
        }
    }
}