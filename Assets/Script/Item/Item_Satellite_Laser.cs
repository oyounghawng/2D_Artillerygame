using Unity.VisualScripting;
using UnityEngine;
public class Item_Satellite_Laser : FuncItem//, IDamagable
{
    private void Start()
    {
        itemIdx = 2;
    }
    // public void TakeDamage(int damageAmount)
    // {

    // }
    // public override void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
    //         
    //     }
    //     base.OnCollisionEnter2D(other);
    //player.TransHealth(-Managers.Data.items[2].value);
    // }

    public override void ItemFunction()
    {
        //ani on
        player.TransHealth(Managers.Data.items[itemIdx].value);
        Debug.Log(Managers.Data.items[itemIdx].value);
    }

}