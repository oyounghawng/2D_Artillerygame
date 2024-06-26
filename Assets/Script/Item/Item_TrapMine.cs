using UnityEngine;

public class Item_TrapMine : StautsItem
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
        ParticleSystem particleSystem = this.GetComponent<ParticleSystem>();

        particleSystem.Play();
        player.TransHealth(-Managers.Data.items[3].value);
        playerStatsUI.PrintTransStats(Managers.Data.items[3].desc);
    }

}