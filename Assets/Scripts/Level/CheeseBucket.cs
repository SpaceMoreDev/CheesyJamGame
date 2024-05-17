using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBucket : MonoBehaviour
{
    public GameObject bucket;
    [SerializeField] private LineRenderer line;

    public Transform bucketCheeses;

    private void Update()
    {
        line.SetPosition(0,bucket.transform.position + new Vector3(0,0.99f,0));
    }

}
