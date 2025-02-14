using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData PlayerData;
    public PlayerAttackController attackController;
    public ProjectileController projectileController;
    
    public void Init()
    {
        PlayerData = new PlayerData();
        attackController = GetComponent<PlayerAttackController>();
        projectileController = GetComponent<ProjectileController>();
        
        projectileController.Init();
        attackController.Init(this);
    }
}
