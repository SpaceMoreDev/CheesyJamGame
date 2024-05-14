using UnityEngine;

public interface IInteract {
    void interact();
}

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask layers;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, layers))
            {
                if (hit.collider.gameObject.TryGetComponent<IInteract>(out IInteract interactedObj))
                {
                    interactedObj.interact();
                }
            }
        }
    }
}
