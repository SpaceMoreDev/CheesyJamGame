using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (menuName = "ScreenShake/New Profile")]
public class NewBehaviourScript : ScriptableObject
{
    [Header("Impulse Source Settings")]
    public float impactTime = 0.2f;
    public float impactforce = 1f;
    public Vector3 defaultVelocity = new Vector3(0f, -1f, 0f);
    public AnimationCurve Curve;

    [Header("Impulse Listener Settings")]
    public float listeneramplitude = 1f;
    public float listenerfrequency = 1f;
    public float listenerduration = 1f;

}
