public class GameManager : IManager
{
    public void Init()
    {
        GameStart();
    }

    private void GameStart()
    {
        Managers.Instance._spawnManager.SpawnMonsters();
    }
}
