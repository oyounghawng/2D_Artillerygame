using UnityEngine;


public interface IDamagable
{
    void TakeDamage(int damageAmount);
}
public interface IGetItem
{
    void GetItem(int itemIdx);
    /*
    아이템 인덱스 받으면 해당 아이템 정보의 밸류를 각각에 맞춰서 플레이어에 넣기 혹은
    아이템 스크립트에 효과 작성하고, 그 함수 실행시키기
    아마 아이템 획득이 주체가 플레이어 일거라서 보통 플레이어 스크립트에 있을 것 같음
    인터페이스 활용해서 그러면 아이템 획득 및 효과를 플레이어 위에 띄우면 되니까 편할듯 아마도 ㅇㅇ;
    */
}

public class TestPlayer : MonoBehaviour
{
    private int health { get; set; }
    private int speed { get; set; }
    private int damage { get; set; }
    private int fuel { get; set; }

    private void Start()
    {
        health = Managers.Data.status[0].Health;
        speed = Managers.Data.status[0].Speed;
        damage = Managers.Data.status[0].Damage;
        fuel = Managers.Data.status[0].Fuel;
        Debug.Log($"{health}, {speed}, {damage}, {fuel}");
    }

    public void TransHealth(int _health)
    {
        health += _health;
    }

    public void TransSpeed(int _speed)
    {
        speed += _speed;
    }
    public void TransDamage(int _damage)
    {
        damage += _damage;
    }
}