using Unity.VisualScripting;
using UnityEngine;

public class Item_Satellite_Laser : StautsItem//, IDamagable
{
    // public void TakeDamage(int damageAmount)
    // {

    // }
    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TestPlayer testPlayer = other.gameObject.GetComponent<TestPlayer>();
            testPlayer.TransHealth(-Managers.Data.items[2].value);
        }
        base.OnCollisionEnter2D(other);
    }

}