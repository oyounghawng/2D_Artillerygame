using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health { get; set; }
    public int speed { get; set; }
    public int damage { get; set; }
    public int fuel { get; set; }
    public int maxHealth { get; set; }


    private Slider HP;

    private void Awake()
    {
        health = Managers.Data.status[0].Health;
        maxHealth = health;
        speed = Managers.Data.status[0].Speed;
        damage = Managers.Data.status[0].Damage;
        fuel = Managers.Data.status[0].Fuel;
    }

    private void Start()
    {
        HP = Util.FindChild<Slider>(this.gameObject, "HP", true);
        HP.value = 1;
    }

    private bool isDamage = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.EndLine))
        {
            TurnManager.instance.GameOver();
            return;
        }
        if (!collision.GetComponent<CircleCollider2D>()) return;

        if (!isDamage)
        {
            int damage = collision.GetComponentInParent<Bullet>().damage;
            Debug.Log(damage);
            StartCoroutine(OnDamage(damage));
        }
    }

    IEnumerator OnDamage(int damage)
    {
        isDamage = true;
        TransHealth(-damage);
        yield return new WaitForSeconds(0.5f);
        isDamage = false;
    }


    public void TransHealth(int _health)
    {
        health += _health;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        HP.value = (float)health / (float)maxHealth;
        if (health <= 0)
        {
            TurnManager.instance.GameOver();
        }
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
