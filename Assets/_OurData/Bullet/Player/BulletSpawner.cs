using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    public static BulletSpawner Instance { get; private set; }

    public static string bulletPrefab = "Bullet_1";
    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.Instance != null)
        {
            Debug.LogError("Onlly 1 InputManger allow to exist");
        }
        
        else
        {
            BulletSpawner.Instance = this;
        }
        
    } 
}
