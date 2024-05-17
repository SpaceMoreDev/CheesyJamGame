using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor.PackageManager;
public class Shooting : MonoBehaviour
{
    

    public static event Action<GameObject> e_ShotObject;

    public GameObject gun;
    public Camera mycam;
    public GameObject player;
    [SerializeField] private GameObject _bulletholeprefab;
    [SerializeField] private Animator gunanim;
    [SerializeField] ScreenShakeProfile profile;

    private CinemachineImpulseSource impulseSource;

    private string entag;

    private RaycastHit hit;
    private GameObject hitobj;
    private int layermask;



    // Start is called before the first frame update
    void Start()
    {
        layermask = 1 << 3;
        mycam = Camera.main;
        impulseSource = gun.GetComponent<CinemachineImpulseSource>();
        //gunanim = gun.GetComponent<Animator>();
        entag = "Enemy";
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gunanim.SetTrigger("isfiring");

            if (Physics.Raycast(mycam.transform.position, mycam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,~layermask))
            {
                hitobj = hit.collider.gameObject;

                Debug.DrawRay(hit.point, -mycam.transform.TransformDirection(Vector3.forward), Color.red,10f);

                //Debug.Log($"Did Hit {hitobj.name}");
                StartBlasting(hitobj);
                
                if (hitobj.CompareTag(entag))
                {
                    if (hitobj.TryGetComponent<Monster>(out Monster monster))
                    {
                        monster.Die();
                    }
                }
                if(!hit.collider.gameObject.CompareTag(entag)||!hit.collider.gameObject.CompareTag(player.tag))
                {
                    //Instantiating the bullet hole object
                    GameObject obj = Instantiate(original: _bulletholeprefab, hit.point, Quaternion.LookRotation(hit.normal));

                    //Modifying the position so it looks better
                    obj.transform.position += obj.transform.forward / 300;
                    Destroy(obj, 3f);
                }
                
            }
            if (CameraShakeManager.instance != null)
            {
                CameraShakeManager.instance.ScreenShakeFromProfile(profile, impulseSource);

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
