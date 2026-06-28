using UnityEngine;

public class ProductOutPut : InteractbleBase
{
    [SerializeField] MachineBase machine;

    private void Start()
    {
        machine = GetComponentInParent<MachineBase>();
    }

    public override void Interact()
    {
        PlayerInventory inv = FindFirstObjectByType<PlayerInventory>();

        if (machine.outputStack <= 0) return;

        if (inv.itemData == null || inv.itemData == machine.outputProduct)
        {
            inv.AddItem(machine.outputProduct, machine.outputStack);

            machine.ClearMachine();
        }
        else
            return;
    }
}
