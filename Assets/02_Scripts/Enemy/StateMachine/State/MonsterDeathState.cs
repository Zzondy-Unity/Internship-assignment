public class MonsterDeathState : MonsterBaseState
{
    public MonsterDeathState(MonsterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(controller.monsterAnimationData.DeathParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(controller.monsterAnimationData.DeathParameterHash);
    }
}
