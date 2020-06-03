using System.Collections;
using UnityEngine;

/// <summary>
/// Class that handles weapon shooting part.
/// </summary>
public sealed class PlayerWeaponShoot : MonoBehaviour
{
    [Header("Weapon Fire Rate Settings")]
    [SerializeField]
    private float fireRateTimer;
    [SerializeField]
    private float defaultfireRateTimer;
    [Header("Weapon Particle Systems Settings")]
    [SerializeField]
    private GameObject weaponShootParticleSystem;
    [SerializeField]
    private GameObject weaponAimShootParticleSystem;

    public bool CanShoot
    {
        get
        {
            return fireRateTimer <= 0;
        }
    }

    void Start()
    {
        StartCoroutine(UpdateFireRateTimer());
    }

    /// <summary>
    /// Reduces fire rate timer to 0 and plays particle effects for a weapon.
    /// </summary>
    private IEnumerator UpdateFireRateTimer()
    {
        while(true)
        {
            if (fireRateTimer > 0)
            {
                fireRateTimer -= Time.deltaTime;
            }
            else
            {
                SetWeaponShootParticleSystemActive(false);
                SetWeaponAimShootParticleSystemActive(false);
            }
            yield return null;
        }
    }

    /// <summary>
    /// ActivatesDeactivates weapon shoot particle system.
    /// </summary>
    /// <param name="value">State value: false to deactivate, true to activate.</param>
    public void SetWeaponShootParticleSystemActive(bool value)
    {
        weaponShootParticleSystem.SetActive(value);
    }

    /// <summary>
    /// ActivatesDeactivates weapon aim shoot particle system.
    /// </summary>
    /// <param name="value">State value: false to deactivate, true to activate.</param>
    public void SetWeaponAimShootParticleSystemActive(bool value)
    {
        weaponAimShootParticleSystem.SetActive(value);
    }

    public void ResetFireRateTimer()
    {
        fireRateTimer = defaultfireRateTimer;
    }
}