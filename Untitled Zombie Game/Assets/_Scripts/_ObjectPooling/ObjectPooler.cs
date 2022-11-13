using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;

    public List<Pool> pools;

    Queue<GameObject> objectPool;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake() {
        if(!instance)
        {
            instance = this;
        }
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist!");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
    //public GameObject GetEnemyFromPool(string tag)
    //{
    //    if (poolEnemy.Count > 0)
    //    {
    //        GameObject enemy = poolEnemy[tag].Dequeue();
    //        enemy.SetActive(true);
    //        return enemy;
    //    }
    //    else
    //    {
    //        Debug.Log("What happen??? Debug ERROR");
    //        return null;
    //    }
    //}

    //public void ReturnEnemyToPool(string tag, GameObject enemy)
    //{
    //    poolEnemy[tag].Enqueue(enemy);
    //    enemy.SetActive(false);
    //}
}
