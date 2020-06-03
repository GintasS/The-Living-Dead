using UnityEngine;

/// <summary>
/// Class that handles the animation part of a weapon.
/// </summary>
public sealed class PlayerWeaponAnimation : MonoBehaviour
{
    [Header("Weapon Animation Settings")]
    [SerializeField]
    private Animator weaponAnimator;

    /// <summary>
    /// Is the player weapon aim walk animation playing.
    /// </summary>
    public bool IsAimWalking
    {
        get
        {
            return weaponAnimator.GetBool(Constants.AnimationParameter.IsAimWalking);
        }
        private set
        {
            weaponAnimator.SetBool(Constants.AnimationParameter.IsAimWalking, value);
        }
    }

    /// <summary>
    /// Is the player weapon hidden animation playing.
    /// </summary>
    public bool IsWeaponHidden
    {
        get
        {
            return weaponAnimator.GetBool(Constants.AnimationParameter.IsWeaponHidden);
        }
        private set
        {
            weaponAnimator.SetBool(Constants.AnimationParameter.IsWeaponHidden, value);
        }
    }

    /// <summary>
    /// Is the player weapon running animation playing.
    /// </summary>
    private bool IsRunning
    {
        get
        {
            return weaponAnimator.GetBool(Constants.AnimationParameter.IsRunning);
        }
        set
        {
            weaponAnimator.SetBool(Constants.AnimationParameter.IsRunning, value);
        }
    }

    public void PlayWeaponFireAnimation()
    {
        weaponAnimator.Play(Constants.AnimationState.Shot);
    }

    public void PlayWeaponAimFireAnimation()
    {
        weaponAnimator.Play(Constants.AnimationState.AimShot);
    }

    /// <summary>
    /// ActivatesDeactivates weapon aim walk animation, based on if it's already active or not.
    /// </summary>
    public void SetWeaponAimWalkAnimationState()
    {
        if (!IsAimWalking)
        {
            weaponAnimator.Play(Constants.AnimationState.AimWalk);
        }
        IsAimWalking = !IsAimWalking;
    }

    public void PlayWeaponReloadAnimation()
    {
        weaponAnimator.Play(Constants.AnimationState.Reload);
    }

    public void PlayWeaponRunAnimation()
    {
        weaponAnimator.Play(Constants.AnimationState.Run);
        IsRunning = true;
    }

    public void StopWeaponRunAnimation()
    {
        IsRunning = false;
    }

    public void PlayWeaponSwitchAnimation()
    {
        weaponAnimator.Play(Constants.AnimationState.SwitchWeapon);
    }

    /// <summary>
    /// ActivatesDeactivates weapon hide animation, based on if it's already active or not.
    /// Will play weapon reveal animation to come out from weapon hide animation.
    /// </summary>
    public void SetWeaponHideAnimationState()
    {
        if (!IsWeaponHidden)
        {
            weaponAnimator.Play(Constants.AnimationState.HideWeapon);
        }
        else
        {
            weaponAnimator.Play(Constants.AnimationState.RevealWeapon);
        }
        IsWeaponHidden = !IsWeaponHidden;
    }
}