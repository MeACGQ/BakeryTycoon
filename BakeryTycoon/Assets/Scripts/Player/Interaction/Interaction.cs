using UnityEngine;

public class Interaction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory inventory = GetComponent<PlayerInventory>();

        if (other.gameObject.TryGetComponent<InteractbleBase>(out InteractbleBase item))
        {
            item.Interact();
        }
    }
}
