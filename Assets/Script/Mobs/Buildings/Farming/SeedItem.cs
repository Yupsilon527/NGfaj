using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedItem : ItemMob
{
    public PlantData Plant;
    public override void OnActivate(PlayerMob user)
    {
        if (user.farmer.FarmingSpot != null && user.farmer.FarmingSpot.TryPlant(Plant))
        {
            Kill();
            return;
        }
        base.OnActivate(user);
    }
    public override string GetMobName()
    {
        if (Plant == null)
            return "Dead Seed";
        return Plant.PlantName+" Seed";
    }
}