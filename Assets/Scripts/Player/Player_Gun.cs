using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Gun : MonoBehaviour
{
    public static  Player_Gun instance;
    public bool isArmed = true;
    public bool Armed { set {
            if (value)
            {
                Interact.instance.animator.SetBool("Armed", true);
                print("armed and ready");
            }
            else
            {
                Interact.instance.animator.SetBool("Armed", false);
                print("unarmed");
            }
            instance.isArmed = value;


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

        Armed = false;
    }

    private void Update()
    {
        transform.position = thecamera.transform.position;
        newRotation = thecamera.transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * smoothingFactor);
    }
}
