using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{

    [SerializeField] PlayableDirector director;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameStateManager.StartCutscene(director);
            print("fortnite");
        }
    }
}
