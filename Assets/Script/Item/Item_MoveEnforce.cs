using UnityEngine;

public class Item_MoveEnforce : StautsItem
{
    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            testPlayer.TransSpeed(Managers.Data.items[1].value);
        }
    }
}