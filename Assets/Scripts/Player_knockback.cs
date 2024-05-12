using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class Player_knockback : MonoBehaviour
{

    public GameObject mycam;
    public float pushforce;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            GetComponent<Rigidbody>().AddForce(mycam.transform.forward * -pushforce, ForceMode.Impulse);
        }
    }
    
}
