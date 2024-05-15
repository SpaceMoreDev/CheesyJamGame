using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public float pushforce = 10;
    private GameObject mycam;

    private void Start()
    {
        mycam = Camera.main.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6) // transition layer
        {
            print("transitioning");
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (col.gameObject.TryGetComponent(out Monster monster))
            {
                GetComponent<Rigidbody>().AddForce(mycam.transform.forward * -pushforce, ForceMode.Impulse);
                monster.animator.Play("Attack");
                monster.gameObject.transform.LookAt(transform, Vector3.up);
            }
        }
    }


}
