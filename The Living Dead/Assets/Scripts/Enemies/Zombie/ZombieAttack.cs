using System.Collections;
using UnityEngine;

/// <summary>
/// Class that handles zombie's attack part.
/// </summary>
public sealed class ZombieAttack : CanAttack
{
    [Header("Main Attack Settings")]
    [SerializeField]
    private bool isAttackModeActive;
    [Header("Attack Timer Settings")]
    [SerializeField]
    private float attackTimer;
    [SerializeField]
    private float defaultAttackTimer;
    [Header("Script References")]
    [SerializeField]
    private ZombieSoundHandler zombieSoundHandler;
    [SerializeField]
    private ZombieAttackStrength zombieAttackStrength;

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GameObject.Find(Constants.GameObject.Player).GetComponent<PlayerHealth>();
    }

    /// <summary>
    /// Is zombie currently attacking someone.
    /// </summary>
    public bool IsAttackModeActive
    {
        set
        {
            isAttackModeActive = value;
        }
    }

    /// <summary>
    /// Start the attack coroutine.
    /// </summary>
    public void StartAttack()
    {
        StartCoroutine(AttackAndWaitCoroutine());
    }

    /// <summary>
    /// Attack and wait for a certain amount of time.
    /// </summary>
    private IEnumerator AttackAndWaitCoroutine()
    {
        isAttackModeActive = true;

        while (isAttackModeActive)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                Attack();
                attackTimer = defaultAttackTimer;
            }
            yield return null;
        }
    }

    /// <summary>
    /// Attack a player.
    /// </summary>
    public override void Attack()
    {
        var damage = RandomNumberGenerator.Generate(zombieAttackStrength);

        if (playerHealth.TryTakeDamage(damage))
        {
            zombieSoundHandler.TryPlayRandomSound(ZombieSoundType.Attack);
        }
    }
}