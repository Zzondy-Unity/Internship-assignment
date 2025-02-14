using UnityEngine;

public class AutoAttackStrategy : IAttackStrategy
{
    private PlayerAttackController _attackController;
    
    private Coroutine attackCoroutine;

    public void Init(PlayerAttackController playerAttackController)
    {
        _attackController = playerAttackController;
        Attack(_attackController.Damage);
    }
    
    public void Attack(int damage)
    {
        //TODO :: 1초마다 반복되는 애니메이션의 이벤트에 공격이 실행됨 (bool값을 조절해서할까?)
    }

    
}
