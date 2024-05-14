using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] List<Transform> spawnLocations = new List<Transform>();
    bool enemyActive = false;
    static public GameObject Monster;
    private float maxWaiTime = 10f;

    private void Awake()
    {
        Monster = Instantiate(EnemyPrefab, transform);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        float randomWait = Random.Range(3f, maxWaiTime);
        yield return new WaitForSeconds(randomWait);

        int randompoint = Random.Range(0, spawnLocations.Count);
        Monster.transform.position = spawnLocations[randompoint].position;

        StartCoroutine(Spawn());
    }

}
