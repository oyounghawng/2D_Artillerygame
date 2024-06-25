using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{    protected override void Init()
    {
        base.Init();

        SceneType = Define.SceneType.GameScene;
        StartCoroutine(CoWaitLoad());
    }

    IEnumerator CoWaitLoad()
    {
        while (Managers.Data.Loaded() == false)
            yield return null;

        Managers.UI.ShowSceneUI<UI_GameScene>();
    }
    public override void Clear()
    {
    }
}
