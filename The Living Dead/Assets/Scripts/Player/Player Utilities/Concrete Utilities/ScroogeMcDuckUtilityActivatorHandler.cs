using UnityEngine;

/// <summary>
/// Class that actually increases the money award per zombie killed.
/// </summary>
public sealed class ScroogeMcDuckUtilityActivatorHandler : PlayerUtility
{
    [Header("ScroogeMcDuck Utility Settings")]
    [SerializeField]
    private int additionalMoneyAwardPerZombieKill;
    [Header("Script References")]
    [SerializeField]
    private PlayerMoney playerMoney;

    /// <summary>
    /// Increase money award given per zombie kill by the amount set.
    /// </summary>
    public void IncreaseMoneyAwardPerZombieKill()
    {
        playerMoney.MoneyAwardPerZombieKill += additionalMoneyAwardPerZombieKill;
    }
}