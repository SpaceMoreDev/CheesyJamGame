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
        monsterSc = monster.GetComponent<Monster>();
    }

    public static void StartSpawn()
    {
        if (monsterSc.spawnFunction == null)
        {
            monsterSc.spawnFunction = monsterSc.StartCoroutine(monsterSc.Spawn());
        }
    }
    public static void StopSpawn()
    {
        monsterSc.isAlive = false;
        monsterSc.navMesh.Warp(new Vector3(0, -50, 0));
    }

    public void SpawnCheeseMan()
    {
        LevelManager.StartGame();

    }

    public static void SetMonsterSpawn()
    {

        int randompoint = Random.Range(0, instance.spawnLocations.Count);


        Vector3 direction = instance.spawnLocations[randompoint].position + instance.spawnLocations[randompoint].right*2 + instance.spawnLocations[randompoint].up ;

        monsterSc.navMesh.Warp(direction);
        Quaternion rotation = Quaternion.LookRotation(direction - (instance.spawnLocations[randompoint].position + instance.spawnLocations[randompoint].up), Vector3.up);
        //rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        monsterSc.transform.rotation = rotation;
        monsterSc.animator.Play("Entering");
    }

}
