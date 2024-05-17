using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trolly : MonoBehaviour, IInteract
{
    public static Trolly instance;
    public bool active = false;
    Transform playerTransform;

    [SerializeField] private List<GameObject> cheeses = new List<GameObject>(); 

    int carried = 0 ;
    public int cheeseCarried { 
        set 
        {
            instance.carried = value; 

            for(int i=0; i<cheeses.Count; i++)
            {
                if (i < carried)
                {
                    cheeses[i].SetActive(true);
                }
                else
                {
                    cheeses[i].SetActive(false);
                }
            }
        } 
        get 
        { 
            return instance.carried; 
        } 
    }

    private void Awake()
    {
        instance = this;
    }

    public void interact(GameObject caller)
    {
        if (caller.tag == "Player")
        {
            Interact.holding = true;
            playerTransform = caller.transform;
        }
        else
        {
            cheeseCarried--;
            GameState.CheeseInGame--;
        }
    }

    private void Update()
    {
        if (Interact.holding)
        {
            if (playerTransform != null)
            {
                transform.position =  playerTransform.position;

                Vector3 currentRotation = transform.transform.eulerAngles;
                Vector3 targetRotation = playerTransform.eulerAngles;

                transform.rotation = Quaternion.Euler(currentRotation.x, targetRotation.y + 90, currentRotation.x);
            }
        }
    }
}
