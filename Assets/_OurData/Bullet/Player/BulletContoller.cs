using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContoller : MonoBehaviour
{
    public DamageSender _damageSender;
    private void Awake()
    {
        LoadDamageSender();
    }

    protected virtual void LoadDamageSender()
    {
        _damageSender = transform.GetComponentInChildren<DamageSender>();
    }
}
