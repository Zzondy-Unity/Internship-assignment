using System;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera _mainCamera;
    private int _damage;
    private int _speed = 10;
    
    public void Init(Vector3 direction, int damage, Camera mainCamera)
    {
        rb = GetComponent<Rigidbody2D>();
        _damage = damage;
        _mainCamera = mainCamera;
        
        rb.linearVelocity = direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && IsVisibleOnScreen(other.transform.position))
        {
            if (other.gameObject.TryGetComponent(out Monster monster) && monster.isAlive)
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
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    
    private bool IsVisibleOnScreen(Vector3 transformPosition)
    {
        if (_mainCamera == null) return false;
        
        Vector3 viewPoint = _mainCamera.WorldToViewportPoint(transformPosition);
        return viewPoint.x >= 0 && viewPoint.x <= 1 && viewPoint.y >= 0 && viewPoint.y <= 1;
    }
}
