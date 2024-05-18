using System;
using System.Collections;
using UnityEngine;

public interface IInteract {
    void interact(GameObject caller);
}

public class Interact : MonoBehaviour
{
    public static Interact instance;

    [SerializeField] private LayerMask layers;
    [SerializeField] private GameObject trolly;
    [SerializeField] private GameObject hand;
    static public GameObject Camera;
    public static bool holding = false;
    public Animator animator;

    public Interact()
    {
    }

    private void Awake()
    {
        Camera = gameObject;
        instance = this;    
    }

    private IEnumerator SetBoolForOneFrame(string parameterName)
    {
        animator.SetBool(parameterName, true);
        yield return new WaitForEndOfFrame(); // Wait for one frame
        animator.SetBool(parameterName, false);
    }

    private void Update()
    {


        trolly.transform.position = transform.position;

        Vector3 currentRotation = trolly.transform.eulerAngles;
        Vector3 targetRotation = transform.eulerAngles;
        trolly.transform.rotation = Quaternion.Euler(currentRotation.x, targetRotation.y, currentRotation.x);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (holding)
            {
                holding = false;
                hand.SetActive(true);

            }
            else
            {
                StartCoroutine(SetBoolForOneFrame("Use"));

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
        else if (Input.GetMouseButtonDown(0) && Player_Gun.instance.isArmed)
        {
           StartCoroutine(SetBoolForOneFrame("isfiring"));
        }
    }

}
