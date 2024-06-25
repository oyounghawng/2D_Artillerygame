using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ItemManager
{

    public List<Action> UseFuncItem = new List<Action>();

    public ItemManager()
    {
        Init();
    }
    public void Init()
    {

    }
    public void UseItem(int idx)
    {
        UseFuncItem[idx]?.Invoke();
    }
}