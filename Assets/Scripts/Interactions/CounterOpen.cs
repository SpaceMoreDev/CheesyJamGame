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
    bool canspawn { get { return spawnables[gameObject]; } }

    public static Dictionary<GameObject,bool> spawnables = new Dictionary<GameObject, bool>();


    private void Awake()
    {
        spawnables.Add(gameObject,false);

        currentCheese.SetActive(false);
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
            transform.DORotate(new Vector3(0, 0, 0), 1, RotateMode.LocalAxisAdd);
        }
        else 
        {
            transform.DORotate(new Vector3(0, 90, 0), 1,RotateMode.LocalAxisAdd);
        }
        opened = !opened;

    }
}
