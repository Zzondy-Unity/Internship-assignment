using System.Collections.Generic;
using UnityEngine;

public class SpawnManager  : MonoBehaviour, IManager
{
    public Monster curMonster;

    private int curIndex = 0;
    private Dictionary<int, Monster> monsterDatas = new Dictionary<int, Monster>();

    public void Init()
    {
        var Monsters = Resources.LoadAll<Monster>(Constants.MonsterPrefabPath);
        for (int i = 0; i < Monsters.Length; i++)
        {
            monsterDatas.Add(int.Parse(Monsters[i].name), Monsters[i]);
        }
    }

    public void SpawnMonsters()
    {
        curIndex = 1000 + (curIndex++ % 5);
        Debug.Log($"curIndex: {curIndex}");
        
        curMonster = Instantiate(monsterDatas[curIndex]);
        curMonster.Initialize(Managers.Data.GetMonsterDataById(curIndex));
    }
}
