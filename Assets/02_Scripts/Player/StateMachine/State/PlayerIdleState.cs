using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private float detectionWidth = 6f;
    private float detectionHeight = 8f;
    private float detectionOffsetX = 14f;
    private float detectionOffsetY = 2.5f;
    
    private Vector2 _boxCenter;
    private Vector2 _boxSize;
    
    public PlayerIdleState(PlayerController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(controller.playerAnimationData.IdleParameterHash);
         
        _boxCenter = new Vector2(controller.transform.position.x + detectionOffsetX, controller.transform.position.y + detectionOffsetY);
        _boxSize   = new Vector2(detectionWidth, detectionHeight);
    }

    public override void Update()
    {
        base.Update();
        if (CheckMonster(out Monster monster))
        {
            PlayerAutoAttackState attackState = controller.playerStateMachine.ChangeState<PlayerAutoAttackState>() as PlayerAutoAttackState;
            attackState.SetTarget(monster);
        }
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(controller.playerAnimationData.IdleParameterHash);
    }
    
    private bool CheckMonster(out Monster monster)
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(_boxCenter, _boxSize, 0, controller.GetMonsterLayerMask());
        if (hits.Length > 0)
        {
            foreach (Collider2D hit in hits)
            {
                if (hit.TryGetComponent<Monster>(out monster) && monster.isAlive)
                {
                    return true;
                }
            }
        }

        monster = null;
        return false;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 boxCenter = new Vector2(controller.transform.position.x + detectionOffsetX, controller.transform.position.y + detectionOffsetY);
        Vector2 boxSize = new Vector2(detectionWidth, detectionHeight);
        
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
}
