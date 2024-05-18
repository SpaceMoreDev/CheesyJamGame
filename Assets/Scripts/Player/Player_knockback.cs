using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.WSA;
using Cinemachine;

public class Player_knockback : MonoBehaviour
{

    public Camera mycam;
    public float pushforce;

    private CinemachineImpulseSource impulseSource;

    [SerializeField] ScreenShakeProfile profile;

    // Start is called before the first frame update
    void Start()
    {
        mycam = Camera.main;
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            GetComponent<Rigidbody>().AddForce(mycam.transform.forward * -pushforce, ForceMode.Impulse);
            impulseSource = col.gameObject.GetComponent<CinemachineImpulseSource>();
            //CameraShakeManager.instance.ScreenShakeFromProfile(profile, impulseSource);
        }
       
    }
    
}
