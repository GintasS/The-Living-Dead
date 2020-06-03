using UnityEngine;

/// <summary>
/// Class that handles player ability to deal damage to other objects.
/// </summary>
public sealed class PlayerAttack : CanAttack
{
    [Header("Raycast Settings")]
    [SerializeField]
    private new Camera camera;
    [Header("Script References")]
    [SerializeField]
    private PlayerWeaponEquipHandler playerWeaponEquipHandler;

    /// <summary>
    /// <summary>
    /// Attack a zombie GameObject via shooting a raycast and checking if it hit a zombie.
    /// </summary>
    public override void Attack()
    {
        var equipedWeapon = playerWeaponEquipHandler.EquipedWeapon;
        var raycastHit = ShootRaycast();
        var hitCollider = raycastHit.collider;

        if (hitCollider != null && hitCollider.IsZombieCollider() && equipedWeapon.WeaponAmmo.HasAmmo)
        {
            var damage = RandomNumberGenerator.Generate(equipedWeapon.WeaponAttackStrength);
            var health = raycastHit.collider.transform.GetComponent<ZombieHealth>();
            health.TryTakeDamage(damage);  
        }

        playerWeaponEquipHandler.EquipedWeapon.WeaponAmmo.ReduceCurrentAmmoByOne();
    }

    /// <summary>
    /// Shoots a raycast. 
    /// </summary>
    /// <returns>RacaystHit instance</returns>
    private RaycastHit ShootRaycast()
    {
        var rayOrigin = camera.ViewportToWorldPoint(Constants.Camera.Center);
        Physics.Raycast(rayOrigin, camera.transform.forward, out var hit, attackRange);

        return hit;
    }
}