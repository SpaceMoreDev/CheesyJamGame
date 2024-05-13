using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Cinemachine_Shake : MonoBehaviour
{
    public static Cinemachine_Shake Instance { get; private set; }
    CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shaketimer;
    private Vector3 originalpos;
    private void Awake()
    {
        
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        originalpos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(shaketimer > 0)
        {
            shaketimer -= Time.deltaTime;
            if(shaketimer <= 0f ) 
            {
                //time is over

                CinemachineBasicMultiChannelPerlin cmb = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cmb.m_AmplitudeGain = 0f;
                //transform.localPosition = originalpos;

            }
        }
    }

    public void ShakeCamera(float intestity, float time)
    {
        Debug.Log("OH YEAH");
        CinemachineBasicMultiChannelPerlin cmb = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        //cmb.m_FrequencyGain = intestity;
        cmb.m_AmplitudeGain = intestity;
        cmb.m_FrequencyGain = 1f;
        shaketimer = time;

    }
}
