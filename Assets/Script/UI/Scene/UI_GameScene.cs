using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameScene : UI_Scene
{
    enum GameObjects
    {
        Gazer,
        Fuel
    }

    enum Images
    {
        WindImage
    }

    enum Texts
    {
        TurnText,
        WindPowerText
    }
    void Start()
    {
        Init();
    }

    public GameObject gazer;
    public GameObject fuel;
    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));


        gazer = GetObject((int)GameObjects.Gazer);
        fuel = GetObject((int)GameObjects.Fuel);

        TurnManager.instance.windDirectionUI = GetImage((int)Images.WindImage);
        TurnManager.instance.windPowerUI = GetText((int)Texts.WindPowerText);
        TurnManager.instance.turnText = GetText((int)Texts.TurnText);
    }
}
