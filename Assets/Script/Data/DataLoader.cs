using System;
using System.Collections.Generic;

[Serializable]
public class ItemData
{
    public int idx;
    public string name;
    public string desc;
    public int value;
    public string prefabPath;

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
public class PlayerData
{
    public int Idx;
    public int Health;
    public int Speed;
    public int Damage;
    public int Fuel;
    public int FireSize;
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


