using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    int ClickCount = 0;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.SceneType.GameScene;
        StartCoroutine(CoWaitLoad());
    }

    IEnumerator CoWaitLoad()
    {
        while (Managers.Data.Loaded() == false)
            yield return null;
    }
    public override void Clear()
    {
    }
}
