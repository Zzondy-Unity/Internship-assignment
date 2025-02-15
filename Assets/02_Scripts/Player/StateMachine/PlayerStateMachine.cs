using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player _player { get; }
    
    private Dictionary<Type, PlayerBaseState> states;
    
    public PlayerStateMachine(Player player)
    {
        _player = player;

        states = new Dictionary<Type, PlayerBaseState>()
        {
            { typeof(PlayerIdleState), new PlayerIdleState(_player.playerController) },
            { typeof(PlayerAutoAttackState), new PlayerAutoAttackState(_player.playerController) },
            { typeof(PlayerManualAttackState), new PlayerManualAttackState(_player.playerController) },
            { typeof(PlayerWalkState), new PlayerWalkState(_player.playerController) },

        };
    }

    public PlayerBaseState ChangeState<T>() where T : PlayerBaseState
    {
        if (states.TryGetValue(typeof(T), out var state))
        {
            ChangeState(state);
            Debug.Log($"Player state changed to {typeof(T).Name}");
            return state;
        }
        return null;
    }
}
