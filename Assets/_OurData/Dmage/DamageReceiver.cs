using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float hpMax;

    private void OnEnable()
    {
        hp = hpMax;
    }

    public virtual void Deduct(float amount)
    {
        if (IsDead()) return;
        
        hp -= amount;
        if (hp <= 0) hp = 0;
    }

    protected virtual bool IsDead()
    {
        return hp <= 0;
    }

    protected virtual void OnDead()
    {
        //For Override
    }
}
