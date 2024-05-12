using UnityEngine;

public interface IInteract {
    void interact();
}

public class Interact : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
            {
                if (hit.collider.gameObject.TryGetComponent<IInteract>(out IInteract interactedObj))
                {
                    interactedObj.interact();
                }
            }
        }
    }
}
