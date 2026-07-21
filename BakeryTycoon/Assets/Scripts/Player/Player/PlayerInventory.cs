using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public event Action<ItemData> OnItemUpdated;
    public event Action<int> OnStackChanged;
    public event Action OnInventoryCleared;

    public ItemData itemData;
    public int itemStack;
    public GameObject holdingObject;

    [SerializeField] private HighlightItem highlighter;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public bool AddItem(ItemData _data, int _count)
    {
        if (itemData != null && itemData != _data) return false;

        if (itemData == _data)
        {
            itemStack += _count;
        }
        else
        {
            itemData = _data;
            itemStack += _count;
            holdingObject = itemData.itemObject;

            if (highlighter != null)
            {
                highlighter.Highlight(itemData);
            }
        }

        OnItemUpdated?.Invoke(itemData);
        OnStackChanged?.Invoke(itemStack);

        return true;
    }

    public void RemoveFromStack(int _amount)
    {
        itemStack -= _amount;
        OnStackChanged?.Invoke(itemStack);
    }

    public void ClearInventory()
    {
        itemData = null;
        itemStack = 0;
        holdingObject = null;

        if (highlighter != null)
        {
            highlighter.Hide();
        }

        OnInventoryCleared?.Invoke();
    }
}