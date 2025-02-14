using System.Collections.Generic;


public static class Constants
{
    public const string MonsterDataPath = "CSVs/MonsterData/";
    public static readonly Dictionary<string, Grade> GradeMapping = new Dictionary<string, Grade>()
    {
        {"일반", Grade.Normal},
        {"레어", Grade.Rare},
        {"매직", Grade.Magic},
        {"전설", Grade.Legendary},
        {"영웅", Grade.Heroic}
    };
}
