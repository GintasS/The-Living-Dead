using UnityEngine;

/// <summary>
/// Class that is responsible for dealing with player's health.
/// </summary>
public sealed class PlayerHealth : Damageable
{
    [Header("Script References")]
    [SerializeField]
    private PlayerSoundHandler playerSoundHandler;
    [SerializeField]
    private PlayerHealthDamageFlash playerHealthDamageFlash;
    [SerializeField]
    private GameStateHandler gameStateHandler;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (IsDead)
        {
            gameStateHandler.EndGame();
        }
    }

    /// <summary>
    /// Try to add health to the player's current health.
    /// </summary>
    /// <param name="healthAmount">Health amount to add.</param>
    /// <returns>Whether the operation succeeded or not.</returns>
    public bool TryAddHealth(int healthAmount)
    {
        if (currentHealth + healthAmount <= maxHealth && healthAmount > 0)
        {
            currentHealth += healthAmount;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Try to reduce player health via taking a certain amount of damage.
    /// </summary>
    /// <param name="damage">Damage to inflict to the player's health.</param>
    public override bool TryTakeDamage(int damage)
    {
        if (base.TryTakeDamage(damage))
        {
            playerHealthDamageFlash.PlayDamageFlash();
            playerSoundHandler.PlayRandomSound(PlayerSoundType.Hurt);

            return true;
        }
        return false;
    }
}