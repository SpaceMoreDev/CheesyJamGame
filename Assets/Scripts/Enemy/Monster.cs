using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    public bool isAlive = true;
    public float minTimeToRespawn = 5f;
    public float maxTimeToRespawn = 20f;
    public float searchDelay = 5f;
    public static event Action ReachedDestination;

    [SerializeField] private float visionArea = 20f;
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private LayerMask targetLayers;
    public NavMeshAgent navMesh;
    private bool canMove = false;
    public Transform target;
    private IInteract targetBox;
    private bool isEscaping = false;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        ReachedDestination += Reached;
        navMesh.Warp(new Vector3(0, -50f, 0));
        StartCoroutine(Spawn());
    }

    public void Die() 
    {
        canMove = false;
        isAlive = false;
        navMesh.Warp(new Vector3(0, -50f, 0));
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeToRespawn,maxTimeToRespawn));
        isAlive = true;
        SpawnManager.SetMonsterSpawn();
        checkTarget();
    }

    IEnumerator SearchDelay()
    {
        yield return new WaitForSeconds(searchDelay);
        checkTarget();
    }

    
    void checkTarget()
    {
        float minDistance = Mathf.Infinity;
        target = null;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, visionArea, targetLayers);

        foreach (Collider collider in hitColliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < minDistance)
            {
                if (collider.TryGetComponent(out IBox box))
                {
                    if (!box.opened)
                    {
                        minDistance = distance;
                        target = collider.transform;
                    }

                }
            }
        }
        if (target != null)
        {
            navMesh.destination = target.position;
            canMove = true; // will be set via animation later on
        }
        else {

            minDistance = Mathf.Infinity;
            Collider[] exits = Physics.OverlapSphere(transform.position, visionArea, 1 << 6);

            foreach (Collider collider in exits)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < minDistance)
                { 
                    minDistance = distance;
                    target = collider.transform;
                }
            }

            navMesh.destination = target.position;

            isEscaping = true;
            canMove = true; // will be set via animation later on
        }

    }

    private void OnDrawGizmos()
    {
        if (!canMove) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionArea);
    }

    private void Update()
    {
        if (canMove)
        {
            if (navMesh.remainingDistance <= navMesh.stoppingDistance)
            {
                if (ReachedDestination != null)
                {
                    ReachedDestination.Invoke();
                }
                canMove = false;
            }
        }
    }

    private void Reached()
    {
        if (!isEscaping)
        {
            if (target.TryGetComponent<IInteract>(out IInteract box))
            {
                box.interact();

                if (target.TryGetComponent<CounterOpen>(out CounterOpen counter))
                {
                    if (counter.spawned)
                    {
                        counter.cheeseSc.interact();
                    }
                }
            }

            StartCoroutine(SearchDelay());
        }
        else
        {
            navMesh.Warp(new Vector3(0, -50f, 0));
        }
    }

}