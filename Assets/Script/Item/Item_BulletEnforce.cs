using UnityEngine;

public class Item_BulletEnforce : StautsItem
{

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(Managers.Data.items[0].value);
            testPlayer.TransDamage(Managers.Data.items[0].value);
        }
        base.OnCollisionEnter2D(other);
    }
}