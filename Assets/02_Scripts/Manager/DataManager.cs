using UnityEngine;
using System.Collections.Generic;

public class DataManager
{
    public List<MonsterDataSO> monsterDataSOs = new();
    
    public void Init()
    {
        ReadSampleMonster();
    }
    
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
            string[] words = lines[i].Split(',');
            if (words.Length < 4)
            {
                Debug.Log($"Line {i} has wrong format!");
                continue;
            }
            
            MonsterDataSO monsterDataSo = ScriptableObject.CreateInstance<MonsterDataSO>();

            monsterDataSo.monsterName = words[0].Trim();
            monsterDataSo.grade = Constants.GradeMapping[words[1].Trim()];
            monsterDataSo.speed = float.Parse(words[2].Trim());
            monsterDataSo.health = int.Parse(words[3].Trim());  
            
            monsterDataSOs.Add(monsterDataSo);
        }
    }
}
