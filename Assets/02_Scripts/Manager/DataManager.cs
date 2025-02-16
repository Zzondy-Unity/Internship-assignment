using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 데이터를 파싱하는 클래스입니다.
/// </summary>
public class DataManager : IManager
{
    private Dictionary<int, MonsterDataSO> monsterDatas = new();
    
    public void Init()
    {
        ReadSampleMonster();
    }

    public MonsterDataSO GetMonsterDataById(int id)
    {
        return monsterDatas[id];
    }
    
    /// <summary>
    /// SampleMonsterCSV파일을 읽어옵니다.
    /// </summary>
    private void ReadSampleMonster()
    {
        string path = Constants.MonsterDataPath + "sampleMonster";
        TextAsset sampleMonsterTextAsset = Resources.Load<TextAsset>(path);

        if (sampleMonsterTextAsset == null)
        {
            Debug.Log($"File in {path} does not exist!");
        }
        
        string[] lines = sampleMonsterTextAsset.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;
            
            string[] words = lines[i].Split(',');
            if (words.Length != 5)
            {
                Debug.Log($"Line {i} has wrong format!");
                continue;
            }
            
            try
            {
                MonsterDataSO monsterDataSo = ScriptableObject.CreateInstance<MonsterDataSO>();
                monsterDataSo.monsterName = words[0].Trim();
                monsterDataSo.grade = Constants.GradeMapping[words[1].Trim()];
                monsterDataSo.speed = float.Parse(words[2].Trim());
                monsterDataSo.health = int.Parse(words[3].Trim());
                monsterDataSo.id = int.Parse(words[4].Trim());

                monsterDatas.Add(monsterDataSo.id, monsterDataSo);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error parsing line {i + 1}: {line}. Exception: {e.Message}");
            }
        }
    }
}
