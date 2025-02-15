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
    
    //TODO :: 3초 이후 투명화 및 콜라이더 제거
}
