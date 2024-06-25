using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum SceneType
    {
        Unknown,
        LobbyScene,
        GameScene,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        PointerDown,
        PointerUp,
        BeginDrag,
        Drag,
        EndDrag
    }
}

public class Tags
{
    public const string Player = "Player";
    public const string Ground = "Ground";
    public const string EndLine = "EndLine";
}
