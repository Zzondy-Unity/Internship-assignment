using UnityEngine;

public abstract class AttackStrategy
{
    protected PlayerAttackController _attackController;

    public virtual void Init(PlayerAttackController attackController)
    {
        _attackController = _attackController;
    }

    public virtual void Attack(int damage)
    {
        Managers.Character.player.projectileController.Fire(FindTarget(), _attackController.Damage);
    }
    
    protected Vector3 FindTarget()
    {
        return Managers.Spawner.curMonster.transform.position;
    }
}