using UnityEngine;

public class Cheese : MonoBehaviour, IInteract
{
    private void Awake()
    {
        GameState.CheeseInGame++;
    }

    public void interact(GameObject caller)
    {
        if (caller.tag != "Enemy")
        {
            transform.parent.gameObject.SetActive(false);
            GameState.collectedCheese++;
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
            GameState.CheeseInGame--;
        }
    }
}
