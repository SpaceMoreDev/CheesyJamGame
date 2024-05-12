using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterOpen : MonoBehaviour, IInteract
{
    [SerializeField] private bool opened = false;
    public void interact()
    {
        if (opened) 
        {
            transform.DORotate(new Vector3(0, 0, 0), 1);
        }
        else 
        {
            transform.DORotate(new Vector3(0, 90, 0), 1);
        }
        opened = !opened;

    }
}
