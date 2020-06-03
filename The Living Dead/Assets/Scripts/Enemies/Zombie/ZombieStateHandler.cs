using UnityEngine;
using MonsterLove.StateMachine;
using Pathfinding;

/// <summary>
/// Class that handles all the available zombie states(attack, run).
/// </summary>
public sealed class ZombieStateHandler : MonoBehaviour
{
    private enum States
    {
        Default,
        Run,
        Attack,
        Die
    }

    [Header("Script References")]
    [SerializeField]
    private ZombieHealth zombieHealth;
    [SerializeField]
    private ZombieAttack zombieAttack;
    [SerializeField]
    private ZombieSoundHandler zombieSoundHandler;
    [SerializeField]
    private ZombieAnimation zombieAnimation;
    [SerializeField]
    private AIPath aiPath;
    private GameObject player;
    private StateMachine<States> stateMachine;

    public bool IsRunning
    {
        get
        {
            return stateMachine.State == States.Run;
        }
    }

    void Awake()
    {
        stateMachine = StateMachine<States>.Initialize(this);
        stateMachine.ChangeState(States.Default);
        player = GameObject.Find(Constants.GameObject.Player);
    }

    void Update()
    {
        StateHandler();
    }

    /// <summary>
    /// Handle all available zombie states.
    /// </summary>
    private void StateHandler()
    {
        aiPath.destination = player.transform.position;
        var playerDistance = Vector3.Distance(player.transform.position, transform.position);

        if (zombieHealth.IsDead)
        {
            stateMachine.ChangeState(States.Die);
        }
        else if (zombieAttack.AttackRange >= playerDistance)
        {
            stateMachine.ChangeState(States.Attack);
        }
        else
        {
            stateMachine.ChangeState(States.Run);
        }
    }

    // Run state
    private void Run_Enter()
    {
        aiPath.canMove = true;
    }

    private void Run_Update()
    {
        zombieSoundHandler.TryPlayRandomSound(ZombieSoundType.Footstep);
        zombieAnimation.PlayZombieRunAnimation();
    }

    // Attack state
    private void Attack_Enter()
    {
        aiPath.canMove = false;
        zombieAttack.StartAttack();
    }

    private void Attack_Update()
    {
        zombieAnimation.PlayZombieAttackAnimation();
    }

    private void Attack_Exit()
    {
        zombieAttack.IsAttackModeActive = false;
    }

    // Die state
    private void Die_Enter()
    {
        zombieAnimation.PlayZombieDieAnimation();
        aiPath.canMove = false;
    }
}