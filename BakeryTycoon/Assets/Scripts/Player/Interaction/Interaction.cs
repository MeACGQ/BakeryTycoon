using UnityEngine;

public class Interaction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<InteractbleBase>(out InteractbleBase item))
        {
            item.Interact();

            Debug.Log(item + " interact edildi");
        }
    }
}
