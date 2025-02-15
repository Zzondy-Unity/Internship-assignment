public class PlayerAutoAttackState : PlayerBaseState
{
    public PlayerAutoAttackState(PlayerController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();
        EventManager.Subscribe(GameEventType.OnShoot, Attack);
        StartAnimation(controller.playerAnimationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (!CheckMonster(out Monster monster))
        {
            controller.playerStateMachine.ChangeState<PlayerIdleState>();
        }
    }

    public override void Exit()
    {
        base.Exit();
        EventManager.UnSubscribe(GameEventType.OnShoot, Attack);
        StopAnimation(controller.playerAnimationData.AttackParameterHash);
    }

    public void SetTarget(Monster monster)
    {
        controller.attackController.SetTargetMonster(monster);
    }
    
    private void Attack(object args)
    {
        controller.attackController.ShootArrow();
    }
}
