using UnityEngine;

public class ManualAttackStrategy : IAttackStrategy
{
    private Player _player;
    
    public void Init(Player player)
    {
        _player = player;
        //ChangeState to manualAttackState
    }
}
