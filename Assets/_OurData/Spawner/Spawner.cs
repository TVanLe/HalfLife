using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    protected virtual void Awake()
    {
        LoadHolder();
        LoadPrefabs();
    }

    protected virtual void LoadHolder()
    {
        holder = transform.Find("Holder");
    }

    protected virtual void LoadPrefabs()
    {
        Transform prefabsObjects = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsObjects)
        {
            prefabs.Add(prefab);
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found" + prefabName);
            return null;
        }

        return Spawn(prefab, spawnPos, rotation);
    }
    
    public virtual Transform Spawn(Transform obj, Vector3 spawnPos, Quaternion rotation)
    {
       

        Transform newPrefab = GetObjectFromPool(obj);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.parent = this.holder;
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }
    
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in poolObjs)
        {
            if (poolObj == null) continue;
            if (prefab.name == poolObj.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform pre in prefabs)
        {
            if (pre.name == prefabName) return pre;
        }

        return null;
    }
    
    public virtual void Despawn(Transform obj)
    {
        poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
    
    
}
