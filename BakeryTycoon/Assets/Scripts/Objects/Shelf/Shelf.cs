using UnityEngine;

public class Shelf : InteractbleBase
{
    [Header("Shelf Settings")]
    [SerializeField] private Transform[] shelfPositions;
    [SerializeField] private int capacity;
    [SerializeField] private ItemData acceptableData;

    private GameObject[] productDatas;
    private int currentCapacity;

    private void Start()
    {
        currentCapacity = capacity;

        productDatas = new GameObject[capacity];

        for (int i = 0; i < capacity; i++)
        {
            Transform chamber = shelfPositions[i];

            GameObject newProduct = Instantiate(acceptableData.itemObject, chamber.position, Quaternion.identity, shelfPositions[i]);

            productDatas[i] = newProduct;

            newProduct.SetActive(false);
        }
    }

    public override void Interact()
    {
        if (acceptableData != PlayerInventory.Instance.itemData) return;

        PutToShelf();
    }

    private void PutToShelf()
    {
        if (currentCapacity <= 0) return;

        int playerStack = PlayerInventory.Instance.itemStack;
        if (playerStack <= 0) return;

        int amountToPlace = Mathf.Min(playerStack, currentCapacity);

        int placedCount = 0;

        for (int i = 0; i < capacity; i++)
        {
            if (placedCount >= amountToPlace) break;

            if(!productDatas[i].activeSelf)
            {
                productDatas[i].SetActive(true);

                placedCount++;
                currentCapacity--;
            }
        }

        PlayerInventory.Instance.RemoveFromStack(placedCount);

        if (PlayerInventory.Instance.itemStack <= 0)
        {
            PlayerInventory.Instance.ClearInventory();
        }
    }
}