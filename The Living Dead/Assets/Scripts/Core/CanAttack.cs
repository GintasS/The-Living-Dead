using UnityEngine;

/// <summary>
/// A base class for all objects that can attack other objects.
/// </summary>
public abstract class CanAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [Range(1, 20)]
    [SerializeField]
    protected int attackRange;

    public int AttackRange
    {
        get
        {
            return attackRange;
        }
    }

    /// <summary>
    /// Attack an object by reducing it's health.
    /// </summary>
    public abstract void Attack();
}