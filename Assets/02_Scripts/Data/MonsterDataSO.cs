using UnityEngine;

public class MonsterDataSO : ScriptableObject
{
    public string monsterName;
    public Grade grade;
    public float speed;
    public int health;
}

public enum Grade
{
    Normal,
    Rare,
    Magic,
    Legendary,
    Heroic,
}