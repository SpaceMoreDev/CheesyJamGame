using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBox {
    bool opened { get; }
    void Begin();
}

public class CounterOpen : MonoBehaviour, IInteract, IBox
{
    public bool opened { set; get; }
    public GameObject currentCheese;
    public Cheese cheeseSc;
    public bool spawned { get { return currentCheese.activeSelf; } }
    bool canspawn { get { return LevelManager.spawnables[gameObject]; } }

    private Quaternion initialRotation;


    private void Awake()
    {
        opened = false;
        LevelManager.spawnables.Add(gameObject,false);

        currentCheese.SetActive(false);
    }
    private void Start()
    {
        initialRotation = transform.rotation;
    }
    public void Begin()
    {
        if (canspawn)
        {
            currentCheese.SetActive(true);
            cheeseSc = currentCheese.transform.GetChild(0).GetComponent<Cheese>();
        }
    }

    public void interact(GameObject caller)
    {
        if (opened) 
        {
            Quaternion targetRotation = Quaternion.AngleAxis(0f, transform.up) * initialRotation;
            transform.DORotateQuaternion(targetRotation, 1);
        }
        else 
        {
            Quaternion targetRotation = Quaternion.AngleAxis(-90f, transform.up) * initialRotation;
            transform.DORotateQuaternion(targetRotation, 1);
        }
        opened = !opened;

        if (opened)
        {
            print("opened container");
        }
    }
}
