using UnityEngine;

public class MonsterDataSO : ScriptableObject
{
    public string monsterName;
    public Grade grade;
    public float speed;
    public int health;
    public int id;
}

public enum Grade
{
    Normal,
    Rare,
    Magic,
    Legendary,
    Heroic,
}