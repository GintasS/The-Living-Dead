using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A collection of stuck zombie classes and methods to manage it.
/// </summary>
public sealed class StuckZombiesCollection : MonoBehaviour
{
    [Header("Stuck Zombies Settings")]
    [SerializeField]
    private List<StuckZombie> stuckZombies;
    [Header("Time Settings")]
    [SerializeField]
    private float minimumTimeStuckToDestroy;

    /// <summary>
    /// Try add a stuck zombie instance if not exists in collection, or update existing one.
    /// </summary>
    /// <param name="stuckZombie">StuckZombie instance to add or update.</param>
    public void TryAddNewStuckZombieOrUpdate(StuckZombie stuckZombie)
    {
        var zombie = stuckZombies.SingleOrDefault(
            x => x.zombie != null && 
            x.zombie.name == stuckZombie.zombie.name
        );

        if (zombie != null)
        {
            zombie.zombieStuckTime += stuckZombie.zombieStuckTime;
            return;
        }
        stuckZombies.Add(stuckZombie);
    }

    /// <summary>
    /// Destroy all stuck zombies gameobjects and remove them from the list.
    /// </summary>
    public void RemoveStuckZombies()
    {
        stuckZombies.Where(x => x.zombie != null && x.zombieStuckTime >= minimumTimeStuckToDestroy)
            .ToList()
            .ForEach(x => {
                stuckZombies.Remove(x);
                Destroy(x.zombie);
            });
    }

    /// <summary>
    /// Removes stuck zombie by gameobject's name.
    /// </summary>
    /// <param name="zombie">Zombie GameObject to remove.</param>
    public void RemoveStuckZombieFromCollection(GameObject zombie)
    {
        stuckZombies.RemoveAll(x => x.zombie.name == zombie.name);
    }
}