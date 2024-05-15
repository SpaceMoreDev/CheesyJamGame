using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Gun : MonoBehaviour
{
    Camera camera;
    [SerializeField] private Vector3 positionOffset;
    private float smoothingFactor = 10;

    Quaternion newRotation;

    void Start()
    {
        camera = Camera.main;
        newRotation = camera.transform.rotation;
        

    }

    private void Update()
    {
        transform.position = camera.transform.position;
        newRotation = camera.transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * smoothingFactor);
    }
}
