using UnityEngine;

public class Cheese : MonoBehaviour, IInteract
{
    [SerializeField] bool countable = true;
    private void Start()
    {
        if (countable)
        {
            GameState.CheeseInGame++;
        }
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
