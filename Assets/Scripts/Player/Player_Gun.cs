using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Gun : MonoBehaviour
{
    Camera camera;
    [SerializeField] private float speed;
    [SerializeField] private float distanceLookingDown;
    [SerializeField] private float distanceNormal = 0.51f;


    void Start()
    {
        camera = Camera.main;
    }
    private void LateUpdate()
    {
        Quaternion newRotation = camera.transform.rotation;
        transform.DORotateQuaternion(newRotation, speed);

        print(transform.localEulerAngles.x);

        if (transform.localEulerAngles.x > 40 && transform.localEulerAngles.x < 300)
        {
            transform.GetChild(0).DOLocalMoveZ(distanceLookingDown, 1);
            transform.GetChild(0).DOLocalMoveY(-0.81f, 1);
        }
        else
        {
            transform.GetChild(0).DOLocalMoveZ(distanceNormal, 1);
            transform.GetChild(0).DOLocalMoveY(-0.11f, 1);
        }


    }
}
