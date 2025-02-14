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
    private AttackType curAttackType = AttackType.Auto;

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

    public void ShootArrow()
    {
        _player.projectileController.Fire(GetTargetPosition(), _player.PlayerData.damage);
    }

    private Vector3 GetTargetPosition()
    {
        return Managers.Spawner.curMonster.transform.position;
    }
}
