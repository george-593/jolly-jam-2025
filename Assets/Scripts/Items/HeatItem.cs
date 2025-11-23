using UnityEngine;

public class HeatItem : Item
{
    public float warmthAmount = 20f;

    protected override void ApplyEffect(PlayerController player)
    {
        player.AddWarmth(warmthAmount);
    }
}