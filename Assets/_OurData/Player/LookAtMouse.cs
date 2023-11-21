using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public float angle { get; private set; }
    [SerializeField] private Transform parent;

    private void Update()
    {
        HandleAimWeapon();
    }

    protected virtual void HandleAimWeapon()
    {
        Vector3 mousePos = InputManger.Instance.mousePostion;
        Vector2 lookDir = mousePos - transform.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.localEulerAngles = new Vector3(0, 0, angle);
        float _check = transform.eulerAngles.z;
        if (_check > 90 && _check < 270)
        {
            parent.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
            angle = (angle + 360) % 360;
            transform.localEulerAngles = new Vector3(0, 0, 180 - angle);
        }
        else
        {
            parent.localScale = new Vector3(.7f, .7f, .7f);
        }
    }
}
