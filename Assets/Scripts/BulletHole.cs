using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHole : MonoBehaviour
{
    [SerializeField] private GameObject _bulletholeprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hitInfo;
            //checking if the raycast is hitting anything
            if(Physics.Raycast(origin:transform.position,direction:transform.forward,out hitInfo))
            {
                //Instantiating the bullet hole object
                GameObject obj = Instantiate(original:_bulletholeprefab,hitInfo.point,Quaternion.LookRotation(hitInfo.normal));

                //Modifying the position so it looks better
                obj.transform.position += obj.transform.forward / 1000;
                Destroy(obj, 3f);
            }
        }
        
    }
}
