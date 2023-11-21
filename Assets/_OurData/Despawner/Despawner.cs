using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawner : MonoBehaviour
{
    private void Update()
    {
        Despawning();
    }

    protected virtual void Despawning()
    {
        if(!CanDespawn()) return;
        DespawnObject();
    }

    protected virtual bool CanDespawn()
    {
        //For Override
        return false;
    }

    protected virtual void DespawnObject()
    {
        //For Override
    }
    
}
