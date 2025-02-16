using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Auto,
    Manual
}

public class PlayerAttackController : MonoBehaviour
{
    private Player _player;
    public ProjectileController projectileController;
    
    private AttackType curAttackType = AttackType.Auto;
    public Monster targetMonster { get; private set; }
    
    public int Damage { get { return _player.PlayerData.damage; } }

    private readonly Dictionary<AttackType, IAttackStrategy> AttackStrategies =
        new Dictionary<AttackType, IAttackStrategy>()
        {
            {AttackType.Auto, new AutoAttackStrategy()},
            {AttackType.Manual, new ManualAttackStrategy()},
        };
    
    public void Init(Player player)
    {
        _player = player;
        projectileController = GetComponent<ProjectileController>();
        projectileController.Init();
        
        ChangeAttackStrategy(AttackType.Auto);
    }

    public bool ChangeAttackStrategy(AttackType attackType)
    {
        if (curAttackType == attackType)
        {
            return false;
        }
        else
        {
            curAttackType = attackType;
            AttackStrategies[curAttackType].Init(_player);
            return true;
        }
    }

    public void SetTargetMonster(Monster monster)
    {
        targetMonster = monster;
    }

    public void ShootArrow()
    {
        Vector3 direction = (targetMonster.transform.position - transform.position).normalized;
        projectileController.Fire(direction, Damage);
    }
}
