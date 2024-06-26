using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
//using UnityEditor.PackageManager;
using System.Numerics;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.UI;
using Unity.VisualScripting;
using DG.Tweening;
public class Shooting : MonoBehaviour
{
    public static event Action<GameObject> e_ShotObject;

    public GameObject gun;
    public GameObject mycam;
    public GameObject muzzle;

    public float smoketime;
    public float muzzletime;

    [SerializeField] private GameObject player;
    [SerializeField] private ParticleSystem smokeparticlesprefab;
   // [SerializeField] private ParticleSystem muzzleflashprefab;

    [SerializeField] private GameObject _bulletholeprefab;
    //[SerializeField] private Animator gunanim;

    [SerializeField] ScreenShakeProfile profile;
    [SerializeField] private GameObject muzzleflash;
    [SerializeField] private AudioSource AudioSource;


    private CinemachineImpulseSource impulseSource;

    private string entag;

    private RaycastHit hit;
    private GameObject hitobj;
    private int layermask;
    [SerializeField] LayerMask decalLayers;


    // Start is called before the first frame update
    void Start()
    {
        smokeparticlesprefab.Stop();
        //muzzleflashprefab.Stop();
        layermask = 1 << 3;
        mycam = Interact.Camera;
        impulseSource = gun.GetComponent<CinemachineImpulseSource>();
        //gunanim = gun.GetComponent<Animator>();
        entag = "Enemy";
        smoketime = 1f;
        muzzletime = 0.5f;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Player_Gun.Armed)
        {
            //Showing Muzzleflash
            //StartCoroutine(SpawnParticles(muzzleflashprefab, muzzletime));

            //gunanim.SetTrigger("isfiring");

            StartCoroutine(activateflash());

            Playaudio();

            if (Physics.Raycast(mycam.transform.position, mycam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,~layermask))
            {
                Debug.Log(hit.point);
                hitobj = hit.collider.gameObject;

                Debug.DrawRay(hit.point, -mycam.transform.TransformDirection(Vector3.forward), Color.red,10f);


                StartBlasting(hitobj);

                
                //Showing Smoke
                StartCoroutine(SpawnParticles(smokeparticlesprefab,smoketime));


                if (hitobj.CompareTag(entag))
                {
                    if (hitobj.TryGetComponent<Monster>(out Monster monster))
                    {
                        monster.Die();
                    }
                }
                if(!hit.collider.gameObject.CompareTag(entag) && !hit.collider.gameObject.CompareTag("Flash") && Includes(decalLayers, hit.collider.gameObject.layer))
                {
                    Debug.Log(hit.collider.gameObject.tag);
                    //Instantiating the bullet hole object
                    GameObject obj = Instantiate(original: _bulletholeprefab, hit.point, Quaternion.LookRotation(hit.normal));

                    //Modifying the position so it looks better
                    obj.transform.position += obj.transform.forward/300;
                    Destroy(obj, 3f);
                }
                
            }
            if (CameraShakeManager.instance != null)
            {
                CameraShakeManager.instance.ScreenShakeFromProfile(profile, impulseSource);

            }

        }
    }

    public bool Includes(
          LayerMask mask,
          int layer)
    {
        return (mask.value & 1 << layer) > 0;
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
        particleprefab.Play();
        yield return new WaitForSeconds(lifetime);
        particleprefab.Stop();
    }

    IEnumerator activateflash()
    {
        muzzleflash.GetComponent<SpriteRenderer>().DOFade(255,0.1f);
        yield return new WaitForSeconds(0.1f);
        muzzleflash.GetComponent<SpriteRenderer>().DOFade(0, 0.1f);
    }

    void Playaudio()
    {
        AudioSource.Play();
    }
}
