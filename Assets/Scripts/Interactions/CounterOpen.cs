using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBox {
    void Begin();
}

public class CounterOpen : MonoBehaviour, IInteract, IBox
{
    [SerializeField] private bool opened = false;
    public GameObject currentCheese;
    public bool spawned { get { return currentCheese.activeSelf; } }
    bool canspawn { get { return LevelManager.spawnables[gameObject]; } }

    private Quaternion initialRotation;


    private void Awake()
    {
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
        }
    }

    public void interact()
    {
        if (opened) 
        {
            Quaternion targetRotation = Quaternion.AngleAxis(0f, transform.up) * initialRotation;
            transform.DORotateQuaternion(targetRotation, 1);
        }
        else 
        {
            Quaternion targetRotation = Quaternion.AngleAxis(90f, transform.up) * initialRotation;
            transform.DORotateQuaternion(targetRotation, 1);
        }
        opened = !opened;

    }
}
