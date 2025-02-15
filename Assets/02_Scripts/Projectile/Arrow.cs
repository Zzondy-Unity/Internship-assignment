using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    private int _damage;
    private int _speed = 10;
    
    public void Init(Vector3 direction, int damage)
    {
        rb = GetComponent<Rigidbody2D>();
        _damage = damage;
        
        rb.linearVelocity = direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.TryGetComponent(out Monster monster))
            {
                if (monster.TakeDamage(_damage))
                {
                    //공격성공 이펙트
                }
                // TODO :: 오브젝트풀로 반환
                Destroy(gameObject);
            }
        }
    }
}
