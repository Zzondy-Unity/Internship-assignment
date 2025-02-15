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
        targetPosition = controller.walkPoint.position;
        StartAnimation(controller.monsterAnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(controller.monsterAnimationData.WalkParameterHash);
        Stop();
    }

    public override void Update()
    {
        base.Update();
        if (CheckMoving())
        {
            controller.stateMachine.ChangeState<MonsterIdleState>();
        }
        else
        {
            if(controller.isGrounded)
                Move();
            else
            {
                Fall();
            }
        }
    }

    private void Fall()
    {
        Vector2 newPosition = (Vector2)controller.transform.position + 9.8f * Time.fixedDeltaTime * Vector2.down;
        controller.rb2D.MovePosition(newPosition);
    }

    private void Move()
    {
        Vector2 direction = (targetPosition - controller.transform.position).normalized;
        float   speed = controller.monster.data.speed;

        Vector2 newPosition = (Vector2)controller.transform.position + Time.fixedDeltaTime * speed * direction;
        newPosition.y = controller.transform.position.y;
        controller.rb2D.MovePosition(newPosition);
    }

    private void Stop()
    {
        controller.rb2D.linearVelocity = Vector2.zero;
    }

    private bool CheckMoving()
    {
         float sqrDistance = Vector3.SqrMagnitude(targetPosition - controller.transform.position);
         return sqrDistance < controller.breakDistance * controller.breakDistance;
    }
}
