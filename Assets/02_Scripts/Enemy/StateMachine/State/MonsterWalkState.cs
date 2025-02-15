using UnityEngine;

public class MonsterWalkState : MonsterBaseState
{
    private Vector3 targetPosition;
    
    public MonsterWalkState(MonsterController controller) : base(controller)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        StartAnimation(controller.monsterAnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(controller.monsterAnimationData.WalkParameterHash);
    }

    
}
