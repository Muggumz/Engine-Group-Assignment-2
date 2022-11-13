using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabEnemies : MonoBehaviour
{
    public Transform LocationPoint;
    public int enemyCount;

    //void Start()
    //{
    //    Debug.Log("Starting Summon");
    //    StartCoroutine(EnemyDrop());
    //}
    void Awake()
    {
        Debug.Log("Starting Summon");
        StartCoroutine(EnemyDrop());
    }
    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            Debug.Log("Starting!!");
            //GameObject Enemy1 = ObjectPooler.instance.Enemys("Enemy1", new Vector3(Random.Range(1, 30), 2, Random.Range(1, 10)), Quaternion.identity);
            //Enemy1 = ObjectPooler.instance.GetEnemyFromPool("Enemy1");
            //Enemy1.transform.position = new Vector3(Random.Range(1, 30), 2, Random.Range(1, 10));
            Debug.Log("Spawning One Enemy");
            Rigidbody Enemy = ObjectPooler.instance.SpawnFromPool("Enemy1", LocationPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //Enemy.transform.position = new Vector3(Random.Range(1, 30), 2, Random.Range(1, 10));
            //new Vector3(Random.Range(1, 30), 2, Random.Range(1, 10))
            Debug.Log("Spawn Enemy");
           // GameObject Enemy2 = ObjectPooler.instance.Enemys2("Enemy2", new Vector3(Random.Range(1, 30), 2, Random.Range(1, 10)), Quaternion.identity);
            //Instantiate(Enemy1, new Vector3(Random.Range(1, 30), 2, Random.Range(1, 10)), Quaternion.identity);
            //Instantiate(Enemy2, new Vector3(Random.Range(1, 30), 3, Random.Range(1, 10)), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 2;
        }

    }
}
