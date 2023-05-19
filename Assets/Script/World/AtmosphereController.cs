using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereController : MonoBehaviour
{
    public static Resource oxygen;

    public float TotalValue = 100;

    private void Awake()
    {
        oxygen = new Resource(null, TotalValue, "Atmosphere",false,false );
    }
}
