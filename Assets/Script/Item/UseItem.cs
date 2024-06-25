using Photon.Pun.Demo.Cockpit;
using UnityEngine;


public interface IUseHaveItem
{
    //public UseItem(int idx);
}
public class UseItem : MonoBehaviour
{
    public static void UsingFuncItem(int idx)
    {
        Managers.Item.UseItem(idx);
    }

    //플레이어 쪽에 인터페이스로 받아주면될듯?
}