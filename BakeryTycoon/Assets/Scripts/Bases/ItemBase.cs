using UnityEngine;

public abstract class ItemBase : InteractbleBase, IHoldable
{
    public ItemData data;

    public override void Interact()
    {
        Hold();
    }

    public void Hold()
    {
        PlayerInventory inv = FindFirstObjectByType<PlayerInventory>();

        if (inv != null)
            inv.AddItem(data);
        else
            Debug.LogWarning("Data alinamadi");

        Destroy(gameObject);
    }

    public void Drop()
    {

    }
}