using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera _mainCamera;
    private int _damage;
    private int _speed = 10;
    private bool isReleased = false;
    
    public void Init(Vector3 direction, int damage, Camera mainCamera)
    {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();
        if(_mainCamera == null)
            _mainCamera = mainCamera;
        
        rb.linearVelocity = direction * _speed;
        isReleased = false;
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 태그가 "Enemy"이고 화면 안에서 맞았을 경우에만 작동합니다.
        if (other.gameObject.CompareTag("Enemy") && IsVisibleOnScreen(other.transform.position))
        {
            // 몬스터가 살아있을 경우에만 작동합니다.
            if (other.gameObject.TryGetComponent(out Monster monster) && monster.isAlive)
            {
                if (monster.TakeDamage(_damage))
                {
                    //공격성공 이펙트
                }
                ReleaseToPool();
            }
        }
    }
    
    /// <summary>
    /// 화면 밖으로 나갈 시 사라집니다.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            ReleaseToPool();
        }
    }
    
    private bool IsVisibleOnScreen(Vector3 transformPosition)
    {
        if (_mainCamera == null) return false;
        
        Vector3 viewPoint = _mainCamera.WorldToViewportPoint(transformPosition);
        return viewPoint.x >= 0 && viewPoint.x <= 1 && viewPoint.y >= 0 && viewPoint.y <= 1;
    }

    private void ReleaseToPool()
    {
        if (!isReleased)
        {
            isReleased = true;
            Managers.ObjectPool.ReturnToPool(typeof(Arrow), gameObject);
        }
    }
}
