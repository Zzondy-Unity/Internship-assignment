using System.Collections.Generic;
using UnityEngine;

public class SpawnManager  : MonoBehaviour, IManager
{
    public Monster curMonster;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform walkPoint;

    private int curIndex = 0;
    private Dictionary<int, Monster> monsterDatas = new Dictionary<int, Monster>();
    private Dictionary<int, Monster> deadMonsters = new Dictionary<int, Monster>();

    public void Init()
    {
        var Monsters = Resources.LoadAll<Monster>(Constants.MonsterPrefabPath);
        for (int i = 0; i < Monsters.Length; i++)
        {
            monsterDatas.Add(int.Parse(Monsters[i].name), Monsters[i]);
        }
        
        EventManager.Subscribe(GameEventType.OnMonsterDead, OnMonsterDead);
    }

    private void OnDestroy()
    {
        EventManager.UnSubscribe(GameEventType.OnMonsterDead, OnMonsterDead);
    }

    public void SpawnMonsters()
    {
        if (curMonster != null && curMonster.isAlive) return;
        curIndex = 1000 + (curIndex++ % 5);
        Debug.Log($"curIndex: {curIndex}");

        if (deadMonsters.ContainsKey(curIndex))
        {
            curMonster.monsterController.SetWalkPoint(walkPoint);
            curMonster = deadMonsters[curIndex].Revive(spawnPoint);
        }
        else
        {
            curMonster = Instantiate(monsterDatas[curIndex]);
            curMonster.transform.position = spawnPoint.position;
            
            curMonster.SetWalkPoint(walkPoint);
            curMonster.Initialize(Managers.Data.GetMonsterDataById(curIndex));
        }
    }

    public void OnMonsterDead(object arg)
    {
        if (arg is Monster monster)
        {
            if (monster == null) return;
            if (monster.isAlive) return;
            
            int monsterID = monster.GetMonsterIDOfThis();
            if (!deadMonsters.ContainsKey(monsterID))
            {
                deadMonsters.Add(monsterID, monster);
            }
            SpawnMonsters();
            
        }
    }
}
