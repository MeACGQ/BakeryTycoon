using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IHoldable
{
    public ItemData data;

    public void Hold()
    {
        PlayerInventory inv = FindFirstObjectByType<PlayerInventory>();

        inv.AddItem(data);

        Debug.Log("Data alindi");
    }

    public void Drop()
    {

    }
}