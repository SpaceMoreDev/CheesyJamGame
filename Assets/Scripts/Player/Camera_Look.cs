using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Look : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public Camera mycam;

    private Transform playerBody;

    private float xRot = 10f;
    private float yRot = 10f;

    // Start is called before the first frame update
    void Start()
    {
        mycam = Camera.main;
        playerBody = transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRot += mouseX;
        xRot -= mouseY;

        xRot = Mathf.Clamp(xRot, -90f, 90f);
        mycam.transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);

        //playerBody.Rotate(Vector3.up * mouseX);
    }
}
