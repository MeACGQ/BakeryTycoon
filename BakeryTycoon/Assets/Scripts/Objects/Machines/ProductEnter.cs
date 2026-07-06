using System.Linq;
using UnityEngine;

public class ProductEnter : InteractbleBase
{
    [SerializeField] GameObject enterTray;
    [SerializeField] MachineBase machine;

    private void Start()
    {
        machine = GetComponentInParent<MachineBase>();
    }

    public override void Interact()
    {
        PlayerInventory inv = FindFirstObjectByType<PlayerInventory>();

        if (inv.itemData != null && machine.acceptableProducts.Contains(inv.itemData))
        {
            machine.AddProduct(inv.itemData, inv.itemStack);

            inv.ClearInventory();
        }
    }
}
