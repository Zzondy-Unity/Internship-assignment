using System;
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

    [SerializeField] private LayerMask monsterLayer;
    [SerializeField] private float detectionWidth = 6f;
    [SerializeField] private float detectionHeight = 8f;
    [SerializeField] private float detectionOffsetX = 14f;
    [SerializeField] private float detectionOffsetY = 2.5f;

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
        Vector3? target = GetTargetPosition();
        if (target != null)
        {
            _player.projectileController.Fire(target.Value, _player.PlayerData.damage);
        }
    }

    private Vector3? GetTargetPosition()
    {
        Vector2 boxCenter = new Vector2(transform.position.x + detectionOffsetX, transform.position.y + detectionOffsetY);
        Vector2 boxSize = new Vector2(detectionWidth, detectionHeight);

        Collider2D[] hits = Physics2D.OverlapBoxAll(boxCenter, boxSize, 0, monsterLayer);
        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out Monster monster) && monster.isAlive)
                {
                    return monster.transform.position;
                    break;
                }
            }
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 boxCenter = new Vector2(transform.position.x + detectionOffsetX, transform.position.y + detectionOffsetY);
        Vector2 boxSize = new Vector2(detectionWidth, detectionHeight);
        
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
}
