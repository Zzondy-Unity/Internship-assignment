using UnityEngine;

public class AutoAttackStrategy : IAttackStrategy
{
    private Player _player;
    
    public void Init(Player player)
    {
        _player = player;
        _player.playerController.playerStateMachine.ChangeState<PlayerAutoAttackState>();
    }
}
