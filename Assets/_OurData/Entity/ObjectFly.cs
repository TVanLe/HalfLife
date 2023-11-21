using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFly : MonoBehaviour
{
    [SerializeField] protected float speedFly;
    [SerializeField] protected Vector3 direction = Vector3.right;

    private void Update()
    {
        Fly();
    }

    protected virtual void Fly()
    {
        transform.parent.Translate(direction * speedFly * Time.deltaTime);
    }
}
