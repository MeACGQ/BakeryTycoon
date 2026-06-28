using UnityEngine;

public abstract class ItemBase : InteractbleBase, IHoldable
{
    public ItemData data;

    private void Start()
    {
        gameObject.name = data.itemName;
    }

    public override void Interact()
    {
        Hold();
    }

    public void Hold()
    {
        PlayerInventory inv = FindFirstObjectByType<PlayerInventory>();



        if (inv != null)
        {
            if (inv.holdingObject == null || inv.holdingObject.name == gameObject.name)
            {
                inv.AddItem(data, 1);

                Destroy(gameObject);
            }

        }
        else
            Debug.LogWarning("Data alinamadi");

    }

    public void Drop()
    {

    }
}