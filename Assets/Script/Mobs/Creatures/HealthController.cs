    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : CreatureComponent
{
    public Resource Health;
    public float RegenerationPercent = 10;
    public float OxygenUpkeep = 3;
    public float OxygenDamage = 5;

    public override void Awake()
    {
        base.Awake();
        Health = new Resource(parent, 100, "Health", false, true);
        Health.OnValueChanged.AddListener(() =>
        {
            CheckAliveState();
        });
    }
    void CheckAliveState()
    {
        if (Health.GetPercentage() <= 0)
        {
            parent.Kill();
        }
    }
    private void Update()
    {
        HandleMetabolism();
    }
    void HandleMetabolism()
    {
        if (parent.IsInside())
            Health.GiveValue(RegenerationPercent * Time.deltaTime);
        if (AtmosphereController.oxygen.GetPercentage() == 0)
            Health.SubstractValue(OxygenDamage * Time.deltaTime);
        else
            AtmosphereController.oxygen.SubstractValue(OxygenUpkeep * Time.deltaTime);
            
    }
}