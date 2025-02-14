using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public PlayerData playerData = new PlayerData();
    public PlayerAttackController AttackController;
    
    public void Init()
    {
        AttackController = GetComponent<PlayerAttackController>();
        AttackController.Init(this);
    }
}
