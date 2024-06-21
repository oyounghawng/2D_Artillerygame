using UnityEngine;


public interface IDamagable
{
    void TakeDamage(int damageAmount);
}

public class TestPlayer : MonoBehaviour
{
    private int health;
    private int speed;
    private int damage;
    private int fuel;

    private void Start()
    {
        health = Managers.Data.status[0].Health;
        speed = Managers.Data.status[0].Speed;
        damage = Managers.Data.status[0].Damage;
        fuel = Managers.Data.status[0].Fuel;
    }

    public void TransHealth(int _health)
    {
        health += health;
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