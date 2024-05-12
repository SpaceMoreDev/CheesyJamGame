using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //i added a variable that is basically the tag to customize it perhaps

    public static event Action<GameObject> e_ShotObject;

    public GameObject gun;
    public Camera mycam;

    [SerializeField] private Animator gunanim;

    private Vector3 dir;
    private string entag;

    private RaycastHit hit;
    private GameObject hitobj;


    // Start is called before the first frame update
    void Start()
    {
        //gunanim = gun.GetComponent<Animator>();
        entag = "Enemy";
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gunanim.SetTrigger("isfiring");

            if (Physics.Raycast(mycam.transform.position, mycam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                hitobj = hit.collider.gameObject;

                //Debug.DrawRay(mycam.transform.position, mycam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                //Debug.Log($"Did Hit {hitobj.name}");
                StartBlasting(hitobj);

                if (hitobj.CompareTag(entag))
                {
                    hitobj.transform.position = new Vector3(0, -50f, 0);
                }
            }
            
        }
    }
    public static void StartBlasting(GameObject myobj)
    {
        if(e_ShotObject != null) 
        {
            e_ShotObject.Invoke(myobj);
        }
    }
}
