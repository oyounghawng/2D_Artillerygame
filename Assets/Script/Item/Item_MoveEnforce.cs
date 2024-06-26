using UnityEngine;

public class Item_MoveEnforce : StautsItem
{
    public override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
    }
    public override void UseItem(Collision2D other)
    {
        base.UseItem(other);
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
        PlayerStatsUI playerStatsUI = other.gameObject.GetComponent<PlayerStatsUI>();
        player.TransSpeed(Managers.Data.items[1].value);
        playerStatsUI.PrintTransStats(Managers.Data.items[1].desc);
    }
}