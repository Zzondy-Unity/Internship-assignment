using System.Collections.Generic;

/// <summary>
/// 전역적으로 사용될 수 있는 값들을 저장합니다.
/// </summary>
public static class Constants
{
    public const string MonsterDataPath = "CSVs/MonsterData/";
    public const string arrowPrefabPath = "Prefabs/Projectile/Arrow";
    public const string MonsterPrefabPath = "Prefabs/Entity/Enemy";
    public static readonly Dictionary<string, Grade> GradeMapping = new Dictionary<string, Grade>()
    {
        {"일반", Grade.Normal},
        {"레어", Grade.Rare},
        {"매직", Grade.Magic},
        {"전설", Grade.Legendary},
        {"영웅", Grade.Heroic}
    };
}
