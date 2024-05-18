using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CheeseBucket : MonoBehaviour
{
    private bool played = false;
    public GameObject bucket;
    [SerializeField] private LineRenderer line;
    [SerializeField] private PlayableDirector cutscene;

    public Transform bucketCheeses;

    public void ReadyGame()
    {
        if (GameState.collectedCheese >= 1 && !played)
        {
            if (cutscene != null)
            {
                cutscene.Play();
                played = true;
            }
           
        }
    }

    private void Update()
    {
        line.SetPosition(0,bucket.transform.position + new Vector3(0,0.99f,0));
    }

}
