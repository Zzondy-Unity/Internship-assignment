using System.Collections.Generic;

public class SpawnManager  : IManager
{
    private List<Monster> monsters = new List<Monster>();
    public Monster curMonster;

    public void Init()
    {
        List<MonsterDataSO> datas = Managers.Data.GetMonsterDataSOs();
        foreach (var data in datas)
        {
            //TODO :: 각 몬스터마다 맞는 SO를 생성해서 넣어줌
        }
    }

    public void SpawnMonsters()
    {
        //TODO :: 모든 몬스터 가지고있음
        
        //TODO :: 몬스터를 차례대로 소환
    }
    
    //TODO :: 코루틴 매니저로 코루틴돌려주기
}
