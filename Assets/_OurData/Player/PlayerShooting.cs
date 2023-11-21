using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform bulletPos;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeDelay;
    private float timeCounter = 0;
    private CameraShake _cameraShake;

    private void Awake()
    {
        timeCounter = timeDelay;
        _cameraShake = FindObjectOfType<CameraShake>();
    }

    private void Update()
    {
        HandleShooting();
    }

    protected virtual void HandleShooting()
    {
        timeCounter += Time.deltaTime;
        if (InputManger.Instance.shoot && timeCounter >= timeDelay)
        {
            Shooting();
            PlayerParticle.Instance.PlayShellParticle(transform.parent);
            _cameraShake.ShakeCamera(.5f);
            animator.SetTrigger("Shoot");
            timeCounter = 0;
        }
    }

    protected virtual void Shooting()
    {
        LookAtMouse lookAtMouse = FindObjectOfType<LookAtMouse>();
        Quaternion rotation = Quaternion.Euler(0,0, lookAtMouse.angle);
        BulletSpawner.Instance.Spawn(BulletSpawner.bulletPrefab, bulletPos.position, rotation);
    }
}
