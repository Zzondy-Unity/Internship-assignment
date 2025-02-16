
/// <summary>
/// 자동공격 Strategy입니다.
/// Manual은 개발하지 않았습니다.
/// </summary>
public class AutoAttackStrategy : IAttackStrategy
{
    private Player _player;
    
    public void Init(Player player)
    {
        _player = player;
        _player.playerController.playerStateMachine.ChangeState<PlayerAutoAttackState>();
    }
}
