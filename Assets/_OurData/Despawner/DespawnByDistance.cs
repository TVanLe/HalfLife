using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawner
{
    [SerializeField] protected float disLimit;
    private Camera mainCam;
    

    private void Awake()
    {
        mainCam = FindObjectOfType<Camera>();
    }

    protected override bool CanDespawn()
    {
        if (Vector3.Distance(transform.parent.position, mainCam.transform.position) > disLimit)
        {
            return true;
        }

        return false;
    }
}
