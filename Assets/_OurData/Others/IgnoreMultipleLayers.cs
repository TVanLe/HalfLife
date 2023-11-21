using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreMultipleLayers : MonoBehaviour
{
    public string ignoredLayer = "Player"; 
    public  string otherLayersToIgnore = "Enemy";

    private void Start()
    {
        InoreCollisons();
    }

    protected virtual void InoreCollisons()
    {
        int ignoredLayerID = LayerMask.NameToLayer(ignoredLayer);
        int otherLayerID = LayerMask.NameToLayer(otherLayersToIgnore);
        
        Physics2D.IgnoreLayerCollision(ignoredLayerID, otherLayerID, true);
    }
}
