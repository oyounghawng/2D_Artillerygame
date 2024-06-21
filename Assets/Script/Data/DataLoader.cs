using System;
using System.Collections.Generic;
using System.Diagnostics;

[Serializable]
public class LevelExpData
{
    public int Game_Lv;
    public int Game_Lv_Exp;
}

[Serializable]
public class LevelExpDataLoader : ILoader<int, LevelExpData>
{
    public List<LevelExpData> levelExps = new List<LevelExpData>();

    public Dictionary<int, LevelExpData> MakeDict()
    {
        Dictionary<int, LevelExpData> dic = new Dictionary<int, LevelExpData>();

        foreach (LevelExpData levelExp in levelExps)
            dic.Add(levelExp.Game_Lv, levelExp);

        return dic;
    }
}



[Serializable]
public class ItemDataLoader : ILoader<int, ItemData>
{
    public List<ItemData> items = new List<ItemData>();

    public Dictionary<int, ItemData> MakeDict()
    {
        Dictionary<int, ItemData> dic = new Dictionary<int, ItemData>();

        foreach (ItemData items in items)
            dic.Add(items.idx, items);

        return dic;
    }
}

[Serializable]
public class PlayerDataLoader : ILoader<int, PlayerData>
{
    public List<PlayerData> status = new List<PlayerData>();
    public Dictionary<int, PlayerData> MakeDict()
    {
        Dictionary<int, PlayerData> dic = new Dictionary<int, PlayerData>();

        foreach (PlayerData status in status)
            dic.Add(status.Idx, status);

        return dic;
    }
}


