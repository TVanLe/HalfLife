using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class BulletImpart : MonoBehaviour
{
    [SerializeField] private BulletContoller bulletCtrl;

    private void Awake()
    {
        LoadBulletCotroller();
    }

    protected virtual void LoadBulletCotroller()
    {
        bulletCtrl = transform.parent.GetComponent<BulletContoller>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("va cham" + other.name);
        bulletCtrl._damageSender.Send(other.transform);
    }
}
