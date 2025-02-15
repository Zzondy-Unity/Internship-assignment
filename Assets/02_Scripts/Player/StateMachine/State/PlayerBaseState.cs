using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerController controller;
    private float detectionWidth = 6f;
    private float detectionHeight = 8f;
    private float detectionOffsetX = 14f;
    private float detectionOffsetY = 2.5f;
    
    private Vector2 _boxCenter;
    private Vector2 _boxSize;
    
    public PlayerBaseState(PlayerController controller)
    {
        this.controller = controller;
        _boxCenter = new Vector2(controller.transform.position.x + detectionOffsetX, controller.transform.position.y + detectionOffsetY);
        _boxSize   = new Vector2(detectionWidth, detectionHeight);
    }
    
    public virtual void Enter()
    {
        
    }

    public virtual void Update()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    protected void StartAnimation(int animationHash)
    {
        controller.animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        controller.animator.SetBool(animationHash, false);
    }
    
    protected bool CheckMonster(out Monster monster)
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
}
