public class MonsterIdleState : MonsterBaseState
{
    public MonsterIdleState(MonsterController controller) : base(controller)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(controller.monsterAnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(controller.monsterAnimationData.IdleParameterHash);
    }
}
