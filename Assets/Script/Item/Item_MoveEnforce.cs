using UnityEngine;

public class Item_MoveEnforce : StautsItem
{
    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TestPlayer testPlayer = other.gameObject.GetComponent<TestPlayer>();
            testPlayer.TransSpeed(Managers.Data.items[1].value);
        }
        base.OnCollisionEnter2D(other);
    }
}