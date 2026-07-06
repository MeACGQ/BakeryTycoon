using System.Collections;
using UnityEngine;

public class Plot : InteractbleBase
{
    public enum FarmStates { Empty, Growing, Ready };

    [SerializeField] FarmStates currentState;

    [SerializeField] private GameObject currentItem;

    public void StartPlant(ItemData _plantData)
    {
        if (currentState != FarmStates.Empty) return;

        currentItem = Instantiate(_plantData.seedObject, transform);

        StartCoroutine(StartGrowing(_plantData));
    }

    private IEnumerator StartGrowing(ItemData _plantData)
    {
        currentState = FarmStates.Growing;

        yield return new WaitForSeconds(_plantData.growTime);

        ReadyToHarve(_plantData);
    }

    void ReadyToHarve(ItemData _plantData)
    {
        Destroy(currentItem);

        currentItem = Instantiate(_plantData.itemObject, transform);

        currentItem.GetComponent<Collider>().enabled = false;

        currentState = FarmStates.Ready;
    }

    public override void Interact()
    {
        if (currentState == FarmStates.Ready)
        {
            currentState = FarmStates.Empty;

            PlayerInventory inv = FindFirstObjectByType<PlayerInventory>();
            FarmBase F_base = GetComponentInParent<FarmBase>();

            if (inv.AddItem(F_base.cropData, 1) == false) return;

            Destroy(currentItem);

            F_base.StartPlanting();
        }
    }
}
