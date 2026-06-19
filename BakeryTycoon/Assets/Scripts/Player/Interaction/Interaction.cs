using UnityEngine;

public class Interaction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ItemBase>(out ItemBase item))
        {
            item.Hold();
        }
    }
}
