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
        if (machine.outputStack <= 0) return;

        if (PlayerInventory.Instance.itemData == null || PlayerInventory.Instance.itemData == machine.outputProduct)
        {
            PlayerInventory.Instance.AddItem(machine.outputProduct, machine.outputStack);

            machine.ClearMachine();
        }
        else
            return;
    }
}
