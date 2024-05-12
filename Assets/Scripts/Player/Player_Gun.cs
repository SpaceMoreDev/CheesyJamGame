using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Gun : MonoBehaviour
{
    Camera camera;
    [SerializeField] private float smoothingFactor;
    [SerializeField] private Vector3 positionOffset;

    void Start()
    {
        camera = Camera.main;
    }

    private void FixedUpdate()
    {
        transform.position = Camera.main.transform.position;

        Quaternion newRotation = camera.transform.rotation;
        transform.DORotateQuaternion(newRotation, smoothingFactor).SetEase(Ease.Linear);
    }
}
