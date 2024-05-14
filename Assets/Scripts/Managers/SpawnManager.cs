using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] List<Transform> spawnLocations = new List<Transform>();
    bool enemyActive = false;
    static public GameObject monster;
    static public Monster monsterSc;
    private float maxWaiTime = 10f;

    private static SpawnManager instance;

    private void Awake()
    {
        instance = this;
        monster = Instantiate(EnemyPrefab, transform);
        monster.transform.position = new Vector3(0, -50f, 0);
        monsterSc = monster.GetComponent<Monster>();
    }

    public static void SetMonsterSpawn()
    {
        if (monsterSc.isAlive)
        {
            int randompoint = Random.Range(0, instance.spawnLocations.Count);
            monsterSc.navMesh.Warp(instance.spawnLocations[randompoint].position);
        }
    }

}
