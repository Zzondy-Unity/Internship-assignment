using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player _player { get; }
    
    private Dictionary<Type, PlayerBaseState> states; // Type을 키로, 상태를 값으로 가지는 딕셔너리
    
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

    /// <summary>
    /// 상태를 전환합니다.
    /// </summary>
    /// <typeparam name="T">전환하고자하는 상태</typeparam>
    /// <returns>해당 상태를 반환합니다.</returns>
    public PlayerBaseState ChangeState<T>() where T : PlayerBaseState
    {
        if (states.TryGetValue(typeof(T), out var state))
        {
            ChangeState(state);
            return state;
        }
        return null;
    }
}
