using UnityEngine;

/// <summary>
/// Class that handles stuck zombies from different spawn locations.
/// </summary>
public sealed class StuckZombiesAtSpawnHandler : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField]
    private StuckZombiesCollection stuckZombiesCollection;

    public StuckZombiesCollection StuckZombiesCollection
    {
        get
        {
            return stuckZombiesCollection;
        }
    }

    void Update()
    {
        stuckZombiesCollection.RemoveStuckZombies();
    }
}