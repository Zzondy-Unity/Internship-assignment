using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData PlayerData;
    public PlayerAttackController attackController;
    public ProjectileController projectileController;
    public PlayerController playerController;
    
    public void Init()
    {
        PlayerData = new PlayerData();
        attackController = GetComponent<PlayerAttackController>();
        projectileController = GetComponent<ProjectileController>();
        playerController = GetComponent<PlayerController>();
        
        playerController.Init(this);
        projectileController.Init();
        attackController.Init(this);
    }
}
