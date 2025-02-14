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

    private readonly Dictionary<AttackType, AttackStrategy> AttackStrategies =
        new Dictionary<AttackType, AttackStrategy>()
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
            AttackStrategies[curAttackType].Init(this);
            return true;
        }
    }

    /// <summary>
    /// 애니메이션 이벤트함수
    /// 투사체를 발사합니다.
    /// </summary>
    public void AutoAttack()
    {
        if (curAttackType == AttackType.Manual) return;
        
        AttackStrategies[curAttackType].Attack(Damage);
    }
}
