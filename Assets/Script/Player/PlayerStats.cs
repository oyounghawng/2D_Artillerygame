using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
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
        InvokeRepeating("debuglog", 0f, 10f);
    }
    public void debuglog()
    {
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
