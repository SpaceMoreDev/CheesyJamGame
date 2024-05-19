using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Gun : MonoBehaviour
{
    public static  Player_Gun instance;
    private bool isArmed = false;
    public static bool Armed { set {

            instance.isArmed = value;

            Interact.instance.SetArmed(value);

        } get { return instance.isArmed; } }
    GameObject thecamera;
    [SerializeField] private Vector3 positionOffset;
    private float smoothingFactor = 10;

    Quaternion newRotation;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        thecamera = Interact.Camera;
        newRotation = thecamera.transform.rotation;
    }

    private void Update()
    {
        transform.position = thecamera.transform.position;
        newRotation = thecamera.transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * smoothingFactor);
    }
}
