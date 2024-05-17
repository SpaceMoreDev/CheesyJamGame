using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public float pushforce = 10;
    private GameObject mycam;
    GameObject bucket;

    private void Start()
    {
        mycam = Camera.main.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9) // transition layer
        {
            if (Interact.holding && Trolly.instance.cheeseCarried > 0)
            {
                print("checking cheese");

                GameState.collectedCheese += Trolly.instance.cheeseCarried;

                Transform BucketCheeses = other.GetComponent<CheeseBucket>().bucketCheeses.transform;
                BucketCheeses.gameObject.SetActive(true);

                for (int i = 0;  i< BucketCheeses.childCount; i++)
                {
                    if (Trolly.instance.cheeseCarried > i)
                    {
                        BucketCheeses.GetChild(i).gameObject.SetActive(true);
                    }
                    else 
                    {
                        BucketCheeses.GetChild(i).gameObject.SetActive(false);
                    }
                }

                Trolly.instance.cheeseCarried = 0;

                bucket = other.GetComponent<CheeseBucket>().bucket;
                

                bucket.transform.DOMoveY(10, 2.5f).onComplete += () => { bucket.transform.DOMoveY(0, 2.5f); BucketCheeses.gameObject.SetActive(false); };
            }
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
