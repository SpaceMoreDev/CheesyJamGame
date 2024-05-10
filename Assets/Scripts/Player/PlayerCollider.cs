using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6) // transition layer
        {
            print("transitioning");
        }
    }
}
