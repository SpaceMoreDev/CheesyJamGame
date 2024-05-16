using UnityEngine;

public class Cheese : MonoBehaviour, IInteract
{

    private void OnEnable()
    {
        GameState.CheeseInGame++;
    }


    public void interact(GameObject caller)
    {
        if (caller.tag != "Enemy")
        {
            if (Trolly.instance.cheeseCarried < 2)
            {
                transform.parent.gameObject.SetActive(false);
                Trolly.instance.cheeseCarried++;
            }
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
            GameState.CheeseInGame--;
        }
    }
}
