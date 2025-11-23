using UnityEngine;

public class HealthItem : Item
{
    public float healAmount = 20f;

    protected override void ApplyEffect(PlayerController player)
    {
        player.AddHealth(healAmount);
    }
}