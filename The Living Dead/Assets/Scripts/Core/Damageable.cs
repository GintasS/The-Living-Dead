using UnityEngine;

/// <summary>
/// A base class for all objects that can be damaged.
/// </summary>
public abstract class Damageable : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField]
    [Range(1, 100)]
    protected int maxHealth;
    [Range(1, 100)]
    [SerializeField]
    protected int startingHealth;
    [SerializeField]
    protected int currentHealth;

    public bool IsDead
    {
        get 
        { 
            return currentHealth <= 0f; 
        }
    }

    public bool IsAtMaxHealth
    {
        get
        {
            return currentHealth == maxHealth;
        }
    }

    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    /// <summary>
    /// Get or set starting health.
    /// </summary>
    public int StartingHealth
    {
        get
        {
            return startingHealth;
        }
        set
        {
            startingHealth = value;
        }
    }

    /// <summary>
    /// Initialize starting values for health.
    /// </summary>
    protected void Init()
    {
        currentHealth = startingHealth;
    }

    /// <summary>
    /// Reduce object's health by a certain amount.
    /// </summary>
    /// <param name="damage">Amount to reduce</param>
    public virtual bool TryTakeDamage(int damage)
    {
        if (!IsDead && damage > 0)
        {
            currentHealth -= damage;
            return true;
        }
        return false;
    }
}