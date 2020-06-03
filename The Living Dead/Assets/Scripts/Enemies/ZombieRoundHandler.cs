using UnityEngine;
using MonsterLove.StateMachine;
using System.Collections;

/// <summary>
/// Class that manages all zombie rounds, starts them, ends them.
/// </summary>
public sealed class ZombieRoundHandler : MonoBehaviour
{
    private enum States
    {
        RoundStart,
        RoundEnd
    }

    [Header("Zombie Round Settings")]
    [SerializeField]
    private int currentRound;
    [SerializeField]
    private int roundPauseTimer;
    [SerializeField]
    private int defaultRoundPauseTimer;
    [Header("Script References")]
    [SerializeField]
    private ZombieSpawnHandler zombieSpawnHandler;
    [SerializeField]
    private PlayerMoney playerMoney;
    [SerializeField]
    private PlayerHUDHandler playerHUDHandler;
    [SerializeField]
    private MaxZombiesInSpecificRoundNumberHandler maxZombiesInSpecificRoundNumberHandler;
    private StateMachine<States> stateMachine;

    public int CurrentRound
    {
        get
        {
            return currentRound;
        }
    }

    /// <summary>
    /// Round pause timer text for player HUD.
    /// </summary>
    public string RoundPauseTimer
    {
        get
        {
            return roundPauseTimer.ToString() + Constants.UnitText.SpaceSecond;
        }
    }

    void Start()
    {
        roundPauseTimer = defaultRoundPauseTimer;
        stateMachine = StateMachine<States>.Initialize(this);
        stateMachine.ChangeState(States.RoundStart);
    }

    // Round start state.

    void RoundStart_Enter()
    {
        currentRound++;
        maxZombiesInSpecificRoundNumberHandler.SetMaximumZombieNumberForSpecificRound(currentRound);

        zombieSpawnHandler.StartSpawningZombies();
    }

    void RoundStart_Update()
    {
        if (zombieSpawnHandler.ActiveZombies == 0 && !zombieSpawnHandler.IsSpawningZombies)
        {
            stateMachine.ChangeState(States.RoundEnd);
        }
    }

    // Round end state.

    private IEnumerator RoundEnd_Enter()
    {
        playerMoney.TryAddMoneyForZombiesKilled(maxZombiesInSpecificRoundNumberHandler.MaxZombiesInCurrentRound);
        playerHUDHandler.SetRoundPauseWindowActive(true);

        while (roundPauseTimer >= 0)
        {
            yield return new WaitForSeconds(Constants.Unit.Second);
            roundPauseTimer--;
        }
        stateMachine.ChangeState(States.RoundStart);
    }

    void RoundEnd_Exit()
    {
        roundPauseTimer = defaultRoundPauseTimer;
        playerHUDHandler.SetRoundPauseWindowActive(false);
    }
}