using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor.PackageManager;
using System.Numerics;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
public class Shooting : MonoBehaviour
{
    

    public static event Action<GameObject> e_ShotObject;

    public GameObject gun;
    public Camera mycam;
    public GameObject muzzle;
    public float smoketime;
    //public float muzzletime;

    [SerializeField] private GameObject player;
    [SerializeField] private ParticleSystem smokeparticlesprefab;
    //[SerializeField] private ParticleSystem muzzleflashprefab;
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
        smoketime = 1f;
        //muzzletime = 2f;
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


                StartBlasting(hitobj);

                //Showing Smoke
                StartCoroutine(SpawnParticles(smokeparticlesprefab,smoketime));

                //Showing Muzzleflash
                //StartCoroutine(SpawnParticles(muzzleflashprefab, muzzletime));

                if (hitobj.CompareTag(entag))
                {
                    if (hitobj.TryGetComponent<Monster>(out Monster monster))
                    {
                        monster.Die();
                    }
                }
                if(!hit.collider.gameObject.CompareTag(entag))
                {
                    Debug.Log(hit.collider.gameObject.tag);
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

    IEnumerator SpawnParticles(ParticleSystem particleprefab,float lifetime)
    {
        particleprefab.gameObject.SetActive(true);
        yield return new WaitForSeconds(lifetime);
        particleprefab.gameObject.SetActive(false);
    }
}
