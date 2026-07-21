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

        if (PlayerInventory.Instance.holdingObject == null || PlayerInventory.Instance.holdingObject.name == gameObject.name)
        {
            PlayerInventory.Instance.AddItem(data, 1);

            Destroy(gameObject);
        }
        else
            Debug.LogWarning("Data alinamadi");

    }

    public void Drop()
    {

    }
}