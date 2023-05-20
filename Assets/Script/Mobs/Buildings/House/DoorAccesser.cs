using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAccesser : PlayerComponent
{
    public CompartimentComponent HouseInRange;
    private void Update()
    {
        if (Input.GetButtonDown("Enter"))
        {
            if (parent.IsInside())
            {
                ExitHouse();
            }
            else if (HouseInRange != null)
            {
                EnterHouse();
            }
        }
        if (Input.GetButtonDown("Dig"))
        {
            if (parent.IsInside())
            {
                parent.backpack.TransferItem( parent.indoor.GetComponent<InventoryComponent>());
            }
        }
    }
    void EnterHouse()
    {
        parent.menu.OpenIndoorsMenu((HouseMob)HouseInRange.Owner);
        HouseInRange.LoadMob(parent);
    }
    void ExitHouse()
    {
        parent.menu.CloseMenu();
        parent.ExitBuilding();
    }
}
