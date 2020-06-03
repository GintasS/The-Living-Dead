using UnityEngine;

/// <summary>
/// Class that is responsible for managing particular zombie's animations.
/// </summary>
public sealed class ZombieAnimation : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField]
    private Animator animator;

    /// <summary>
    /// Is the zombie running animation playing.
    /// </summary>
    private bool IsRunning
    {
        get
        {
            return animator.GetBool(Constants.AnimationParameter.IsRunning);
        }
        set
        {
            animator.SetBool(Constants.AnimationParameter.IsRunning, value);
        }
    }

    public void PlayZombieRunAnimation()
    {
        IsRunning = true;
    }

    public void PlayZombieAttackAnimation()
    {
        IsRunning = false;
    }

    public void PlayZombieDieAnimation()
    {
        animator.Play(Constants.AnimationState.Die);
    }
}