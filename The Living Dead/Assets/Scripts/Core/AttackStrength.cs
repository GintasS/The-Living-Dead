using UnityEngine;

/// <summary>
/// Base class for all attack strengths, player and zombie.
/// </summary>
public abstract class AttackStrength : MonoBehaviour
{
    [Header("Attack Strength Settings")]
    [SerializeField]
    protected int attackStrengthMin;
    [SerializeField]
    protected int attackStrengthMax;

    /// <summary>
    /// Get attack strength min value.
    /// </summary>
    public int AttackStrengthMin
    {
        get
        {
            return attackStrengthMin;
        }
    }

    /// <summary>
    /// Get attack strength max value.
    /// </summary>
    public int AttackStrengthMax
    {
        get
        {
            return attackStrengthMax;
        }
    }
}