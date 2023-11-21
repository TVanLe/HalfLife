using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    private Transform player;

    [SerializeField] private float threshold;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        HanldCameraFollow();
    }

    protected virtual void HanldCameraFollow()
    {
        Vector3 target = (player.position + InputManger.Instance.mousePostion) / 2;
        target.x = Mathf.Clamp(target.x, -threshold + player.position.x, threshold + player.position.x);
        target.y = Mathf.Clamp(target.y, -threshold + player.position.y, threshold + player.position.y);
        transform.position = target;
    }
}