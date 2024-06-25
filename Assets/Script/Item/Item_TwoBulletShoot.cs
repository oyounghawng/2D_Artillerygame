using UnityEngine;


public class Item_TwoBulletShoot : FuncItem
{
    int shootCount = 0;
    private void Start()
    {
        itemIdx = 3;
    }
    public override void ItemFunction()
    {
        //ani on
        // 플레이어 공격 횟수 2회 혹은 대포알 2발로
        shootCount += Managers.Data.items[itemIdx].value;

        Controller controller;

        controller = GetComponentInParent<Controller>();

        for (int i = 0; i < shootCount; i++)
        {
            controller.CallFireEvent();
        }

        Debug.Log(Managers.Data.items[itemIdx].value);
    }
}