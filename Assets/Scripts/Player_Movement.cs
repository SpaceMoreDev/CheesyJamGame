using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Movement : MonoBehaviour
{
    public float Speed = 10f;
    public Camera mycam;

    private Transform playerBody;
    //private Rigidbody rb;
    private CharacterController charcont;

    private Vector3 Move;
    private Vector3 camforward;
    private Vector3 camright;


    private float hor;
    private float vert;
    // Start is called before the first frame update
    void Start()
    {
        charcont = GetComponent<CharacterController>();
        playerBody = transform;
    }

    // Update is called once per frame


    //FixedUpdate
    void FixedUpdate()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        Move = new Vector3 (hor,0,vert);

        camforward = mycam.transform.forward;
        camright = mycam.transform.right;

        Move = vert * camforward + hor * camright;
        Move.y = 0f;
        charcont.Move(Move * Speed * Time.deltaTime);
    }

}
