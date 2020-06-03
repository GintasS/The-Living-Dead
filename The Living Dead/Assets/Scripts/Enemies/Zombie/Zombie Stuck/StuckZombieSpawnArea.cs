using UnityEngine;

public sealed class StuckZombieSpawnArea : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField]
    private StuckZombiesAtSpawnHandler stuckZombiesAtSpawnHandler;

    /// <summary>
    /// While zombie stays in a spawn area, increment zombieStuckTime.
    /// </summary>
    void OnTriggerStay(Collider collider)
    {
        if (collider.IsZombieCollider() && collider.GetComponent<ZombieStateHandler>().IsRunning)
        {
            var zombie = new StuckZombie
            {
                zombie = collider.gameObject,
                zombieStuckTime = Time.deltaTime,
            };

            stuckZombiesAtSpawnHandler.StuckZombiesCollection.TryAddNewStuckZombieOrUpdate(zombie);
        }
    }

    /// <summary>
    /// If zombie manages to exit the spawn area, remove it from the stuckZombieCollection.
    /// </summary>
    void OnTriggerExit(Collider collider)
    {
        if (collider.IsZombieCollider())
        {
            stuckZombiesAtSpawnHandler.StuckZombiesCollection.RemoveStuckZombieFromCollection(collider.gameObject);
        }
    }
}