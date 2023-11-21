using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    public static PlayerParticle Instance { get; private set; }
    [SerializeField] protected ParticleSystem shell;
    private void Awake()
    {
        if (PlayerParticle.Instance != null)
        {
            Debug.LogError("Onlly 1 InputManger allow to exist");
        }

        else
        {
            PlayerParticle.Instance = this;
        }
    }

    private void Start()
    {
        transform.parent = null;
    }

    public void PlayShellParticle(Transform newPos)
    {
        transform.localScale = newPos.localScale;
        transform.position = newPos.position;
        shell.Play();
    }

}
