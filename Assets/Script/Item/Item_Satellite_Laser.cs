using UnityEngine;

public class Item_Satellite_Laser : StautsItem//, IDamagable
{
    // public void TakeDamage(int damageAmount)
    // {

    // }
    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            testPlayer.TransHealth(Managers.Data.items[2].value);
        }
    }
}