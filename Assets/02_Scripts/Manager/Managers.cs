using UnityEngine;

public class Managers : SingletonDontDestroy<Managers>
{
    public DataManager _dataManager;

    protected override void Awake()
    {
        base.Awake();
        
        CreateManagers();
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        _dataManager.Init();
    }

    private void CreateManagers()
    {
        _dataManager = new DataManager();
    }
}
