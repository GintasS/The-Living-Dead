using UnityEngine;

/// <summary>
/// A class that reloads a weapon on a animation end state.
/// </summary>
public sealed class ReloadWeaponOnAnimationEnd : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetCurrentAnimatorStateInfo(Constants.CustomValue.Zero).IsName(Constants.AnimationState.Idle))
        {
            return;
        }

        var playerWeaponsHandler = animator.gameObject.transform.root.GetComponent<PlayerWeaponEquipHandler>();
        playerWeaponsHandler.EquipedWeapon.WeaponAmmo.ReloadAmmoClip();
    }
}