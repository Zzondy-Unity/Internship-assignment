using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터의 스폰을 관리하는 매니저입니다.
/// </summary>
public class SpawnManager  : MonoBehaviour, IManager
{
    public Monster curMonster;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform walkPoint;

    private int curIndex = 0;
    private Dictionary<int, Monster> monsterDatas = new Dictionary<int, Monster>();
    private Dictionary<int, Monster> deadMonsters = new Dictionary<int, Monster>();

    /// <summary>
    /// 몬스터 프리팹을 읽고 이를 딕셔너리에 저장합니다.
    /// </summary>
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
    
    /// <summary>
    /// 몬스터를 순서에 맞게 소환합니다.
    /// 다만, 이미 죽은 몬스터는 재활용합니다.
    /// </summary>
    public void SpawnMonsters()
    {
        if (curMonster != null && curMonster.isAlive) return;
        int monsterIndex = 1000 + curIndex;
        
        Debug.Log($"monsterIndex: {monsterIndex}");
        if (deadMonsters.ContainsKey(monsterIndex))
        {
            curMonster.monsterController.SetWalkPoint(walkPoint);
            curMonster = deadMonsters[monsterIndex].Revive(spawnPoint);
        }
        else
        {
            curMonster = Instantiate(monsterDatas[monsterIndex]);
            curMonster.transform.position = spawnPoint.position;
            
            curMonster.SetWalkPoint(walkPoint);
            curMonster.Initialize(Managers.Data.GetMonsterDataById(monsterIndex));
        }

        curIndex = (curIndex + 1) % 5;
    }

    /// <summary>
    /// 몬스터가 죽을때 딕셔너리에 저장하고 새로운 몬스터를 소환합니다.
    /// </summary>
    /// <param name="arg"></param>
    private void OnMonsterDead(object arg)
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
