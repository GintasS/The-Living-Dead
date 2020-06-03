using UnityEngine;

/// <summary>
/// Class that manages player money: gains and expenditures.
/// </summary>
public sealed class PlayerMoney : MonoBehaviour
{
    [Header("Money Settings")]
    [SerializeField]
    private int maxMoney;
    [SerializeField]
    private int startingMoney;
    [SerializeField]
    private int currentMoney;
    [Header("Money Award Per Zombie Kill Settings")]
    [SerializeField]
    [Range(1, 10000)]
    private int moneyAwardPerZombieKill;

    /// <summary>
    /// Get or set player starting money.
    /// </summary>
    public int StartingMoney
    {
        get
        {
            return startingMoney;
        }

        set
        {
            startingMoney = value;
        }
    }

    /// <summary>
    /// Get or set money award per zombie kill.
    /// </summary>
    public int MoneyAwardPerZombieKill
    {
        get
        {
            return moneyAwardPerZombieKill;
        }
        set
        {
            moneyAwardPerZombieKill = value;
        }
    }

    /// <summary>
    /// Get current player money.
    /// </summary>
    public int CurrentMoney
    {
        get
        {
            return currentMoney;
        }
    }

    void Start()
    {
        currentMoney = startingMoney;
    }

    /// <summary>
    /// Try to add money to the player's current money balance.
    /// </summary>
    /// <param name="amount">A positive amount of money to add.</param>
    /// <returns>Whether the addition operation succeeded or not.</returns>
    private bool TryAddMoney(int amount)
    {
        if (currentMoney + amount <= maxMoney && amount >= 0)
        {
            currentMoney += amount;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Try to add money to the player's current money for every zombie killed.
    /// </summary>
    /// <param name="zombiesKilled">Number of zombies killed</param>
    public void TryAddMoneyForZombiesKilled(int zombiesKilled)
    {
        TryAddMoney(zombiesKilled * moneyAwardPerZombieKill);
    }

    /// <summary>
    /// Try to subtract money from player's current money balance.
    /// </summary>
    /// <param name="amount">Money to subtract.</param>
    /// <returns>Whether the subtraction operation succeeded or not.</returns>
    public bool TrySubtractMoney(int amount)
    {
        if (CanAffordPurchase(amount))
        {
            currentMoney -= amount;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Check if a player can afford a purchase.
    /// </summary>
    /// <param name="purchaseAmount">An amount to check.</param>
    /// <returns>Can a player afford a purchase or not.</returns>
    public bool CanAffordPurchase(int purchaseAmount)
    {
        return currentMoney - purchaseAmount >= 0 && purchaseAmount >= 0;
    }
}