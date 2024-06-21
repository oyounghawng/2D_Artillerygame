using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}
public class DataManager
{

    //�̴ϰ��� ������
    //public Dictionary<int, LevelExpData> LevelExps { get; private set; } = new Dictionary<int, LevelExpData>();
    public Dictionary<int, ItemData> items { get; private set; } = new Dictionary<int, ItemData>();

    public void Init()
    {
        //LevelExps = LoadJson<LevelExpDataLoader, int, LevelExpData>("LevelExpData").MakeDict();
        items = LoadJson<ItemDataLoader, int, ItemData>("ItemData").MakeDict();
    }

    public bool Loaded()
    {
        return true;
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/Json/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}