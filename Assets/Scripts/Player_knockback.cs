using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class Player_knockback : MonoBehaviour
{

    public GameObject mycam;
    public GameObject enemy;
    public float pushforce;

    private bool shouldpush = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(enemy.transform.position, transform.position);
        //Debug.Log(dist);
        if (dist < 2f && shouldpush)
        {
            Debug.Log("Oh yeah");
            this.GetComponent<Rigidbody>().AddForce(mycam.transform.forward * -1);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if(hit.gameObject.CompareTag("Enemy"))
        {
            shouldpush = true;
            enemy = hit.gameObject;
        }
           
        

    }
}
