public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(controller.playerAnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(controller.playerAnimationData.IdleParameterHash);
    }
}
