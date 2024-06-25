using UnityEngine;

public class Item_HealUp : StautsItem
{
    public override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
    }
    public override void UseItem(Collision2D other)
    {
        base.UseItem(other);
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
        player.TransHealth(Managers.Data.items[2].value);
    }
}