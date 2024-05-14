using UnityEngine;

public class Cheese : MonoBehaviour, IInteract
{
    private void Awake()
    {
        GameState.cheeseCount++;
    }

    public void interact()
    {
        transform.parent.gameObject.SetActive(false);
        GameState.collectedCheese++;
        print($"collected {GameState.collectedCheese}/{GameState.cheeseCount} cheese!");
    }
}
