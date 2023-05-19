using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMob : CreatureMob
{

    public AnimalWanderComponent ai;
    public AnimalHungerComponent hunger;
    protected override void Awake()
    {
        base.Awake();

        ai = GetComponent<AnimalWanderComponent>();
        hunger = GetComponent<AnimalHungerComponent>();

    }
    public override void Register()
    {
        base.Register();
        hunger.Hunger.SetPercentage(1);
    }
}
