using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private int health { get; set; }
    private int speed { get; set; }
    private int damage { get; set; }
    private int fuel { get; set; }

    private int maxHealth { get; set; }

    private Slider HP;

    private void Start()
    {
        health = Managers.Data.status[0].Health;
        maxHealth = health;
        speed = Managers.Data.status[0].Speed;
        damage = Managers.Data.status[0].Damage;
        fuel = Managers.Data.status[0].Fuel;

        HP = Util.FindChild<Slider>(this.gameObject, "HP", true);
        HP.value = 1;
    }

    private bool isDamage = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<CircleCollider2D>()) return;

        if (!isDamage)
        {
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        isDamage = true;
        TransHealth(-3);
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
            //PhotonNetwork.Destroy(this.gameObject);
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
