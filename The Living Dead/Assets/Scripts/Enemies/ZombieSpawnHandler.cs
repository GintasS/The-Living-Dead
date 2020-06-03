using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

/// <summary>
/// Class that is responsible for spawning all the zombies to the map.
/// </summary>
public sealed class ZombieSpawnHandler : MonoBehaviour
{
    [Header("Main Zombie Settings")]
    [SerializeField]
    private GameObject zombiePrefab;
    [SerializeField]
    private GameObject zombieInstancesParent;
    [SerializeField]
    private List<GameObject> zombieSpawnPoints;
    [Header("Zombie Spawn Settings")]
    [SerializeField]
    private List<GameObject> zombies;
    [SerializeField]
    private bool isSpawningZombies;
    [Header("Zombie Spawn Timer Settings")]
    [SerializeField]
    private float zombieInstantiatorTimer;
    [SerializeField]
    private float defaultZombieInstantiatorTimer;
    [Header("Script References")]
    [SerializeField]
    private MaxZombiesInSpecificRoundNumberHandler maxZombiesInSpecificRoundNumberHandler;

    /// <summary>
    /// Get active zombies count on the map.
    /// </summary>
    public int ActiveZombies
    {
        get
        {
            return zombies.Count(x => x != null);
        }
    }

    /// <summary>
    /// Whether the zombie spawn handler is currently spawning zombies.
    /// </summary>
    public bool IsSpawningZombies
    {
        get
        {
            return isSpawningZombies;
        }
    }

    /// <summary>
    /// Start the zombie spawn coroutine.
    /// </summary>
    public void StartSpawningZombies()
    {
        StartCoroutine(WaitAndSpawnZombies());
    }

    /// <summary>
    /// Waits and spawn zombies until a max zombie count is met.
    /// </summary>
    private IEnumerator WaitAndSpawnZombies()
    {
        zombies = new List<GameObject>();
        isSpawningZombies = true;

        while (zombies.Count < maxZombiesInSpecificRoundNumberHandler.MaxZombiesInCurrentRound)
        {
            if (zombieInstantiatorTimer > 0)
            {
                zombieInstantiatorTimer -= Time.deltaTime;
            }
            else
            {
                InstantiateZombie();
                zombieInstantiatorTimer = defaultZombieInstantiatorTimer;
            }

            yield return null;
        }

        isSpawningZombies = false;
    }

    /// <summary>
    /// Create an instance of a single zombie at a specific location.
    /// </summary>
    private void InstantiateZombie()
    {
        var spawnPositionIndex = RandomNumberGenerator.Generate(0, zombieSpawnPoints.Count);
        var newZombie = Instantiate(zombiePrefab, zombieSpawnPoints[spawnPositionIndex].transform.position, Quaternion.identity, zombieInstancesParent.transform);
        newZombie.name = Constants.GameObject.ZombieWithSpace + (zombies.Count + 1);

        zombies.Add(newZombie);
    }
}