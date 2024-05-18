using System;
using UnityEngine;

public interface IInteract {
    void interact(GameObject caller);
}

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask layers;
    [SerializeField] private GameObject trolly;
    [SerializeField] private GameObject hand;
    static public GameObject Camera;
    public static bool holding = false;

    private void Awake()
    {
        Camera = gameObject;
    }

    private void Update()
    {
        trolly.transform.position = transform.position;

        Vector3 currentRotation = trolly.transform.eulerAngles;
        Vector3 targetRotation = transform.eulerAngles;
        trolly.transform.rotation = Quaternion.Euler(currentRotation.x, targetRotation.y, currentRotation.x);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (holding) {
                holding = false;
                hand.SetActive(true);

            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, layers))
                {
                    if (hit.collider.gameObject.TryGetComponent<IInteract>(out IInteract interactedObj))
                    {
                        if (hit.collider.tag == "Trolly")
                        {
                            interactedObj.interact(trolly.transform.GetChild(0).gameObject);
                            hand.SetActive(false);
                        }
                        else
                        {
                            interactedObj.interact(gameObject);
                        }
                    }
                }
            }
             
        }
    }
}
