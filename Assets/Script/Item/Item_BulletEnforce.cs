using UnityEngine;

public class Item_BulletEnforce : StautsItem
{
    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            testPlayer.TransDamage(Managers.Data.items[0].value);
        }
    }
}