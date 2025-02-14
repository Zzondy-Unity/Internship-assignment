public class GameManager : IManager
{
    public void Init()
    {
        GameStart();
    }

    private void GameStart()
    {
        Managers.Spawner.SpawnMonsters();
    }
}
