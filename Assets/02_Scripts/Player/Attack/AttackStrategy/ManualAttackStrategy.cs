using UnityEngine;public class ManualAttackStrategy : IAttackStrategy
{
    private PlayerAttackController _playerAttackController;

    public void Init(PlayerAttackController playerAttackController)
    {
        _playerAttackController = playerAttackController;
    }
    
    public void Attack(int damage)
    {
        
    }
}
