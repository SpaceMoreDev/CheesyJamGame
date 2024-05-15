using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShakeManager : MonoBehaviour
{
    public static CameraShakeManager instance;

    [SerializeField] private float globalShakeForce = 1f;
    [SerializeField] private CinemachineImpulseListener impulselistener;

    private CinemachineImpulseDefinition impulsedefinition;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        impulselistener = Camera.main.GetComponent<CinemachineImpulseListener>();
    }

    public void CameraShake(CinemachineImpulseSource impulseSource)
    {
        impulseSource.GenerateImpulseWithForce(globalShakeForce);
    }

    public void ScreenShakeFromProfile(ScreenShakeProfile profile, CinemachineImpulseSource impulseSource)
    {
        //applying settings
        SetupScreenShakeSettings(profile, impulseSource);

        //Screenshake
        impulseSource.GenerateImpulseWithForce(profile.impactforce);
    }

    private void SetupScreenShakeSettings(ScreenShakeProfile profile, CinemachineImpulseSource impulseSource)
    {
        impulsedefinition = impulseSource.m_ImpulseDefinition;

        //Changing the impulse source settings
        impulsedefinition.m_ImpulseDuration = profile.impactTime;
        impulseSource.m_DefaultVelocity = profile.defaultVelocity;
        impulsedefinition.m_CustomImpulseShape = profile.impulseCurve;

        //Changing the impulse listener settings
        impulselistener.m_ReactionSettings.m_AmplitudeGain = profile.listeneramplitude;
        impulselistener.m_ReactionSettings.m_FrequencyGain = profile.listenerfrequency;
        impulselistener.m_ReactionSettings.m_Duration = profile.listenerduration;

    }
}
