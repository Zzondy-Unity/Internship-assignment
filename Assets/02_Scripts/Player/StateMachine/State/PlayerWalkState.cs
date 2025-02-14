public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(controller.playerAnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(controller.playerAnimationData.WalkParameterHash);
    }
}
