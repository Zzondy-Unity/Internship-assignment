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
    private bool isAutoAttack = true;
    private AttackType curAttackType = AttackType.Auto;

    public int Damage
    {
        get
        {
            return _player.playerData.damage;
        }
    }

    private readonly Dictionary<AttackType, IAttackStrategy> AttackStrategies =
        new Dictionary<AttackType, IAttackStrategy>()
        {
             
        };
    
    public void Init(Player player)
    {
        _player = player;
        
        isAutoAttack = true;
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
}
