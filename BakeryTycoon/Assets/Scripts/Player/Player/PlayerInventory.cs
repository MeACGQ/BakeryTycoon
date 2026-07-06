using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    HighlightItem highlightItem;
    HiglightItemText itemText;

    public ItemData itemData;

    public int itemStack;

    public GameObject holdingObject;

    private void Start()
    {
        highlightItem = GetComponent<HighlightItem>();
        itemText = GetComponent<HiglightItemText>();
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

            highlightItem.Highlight(_data.itemObject);
        }

        itemText.HiglightText(itemStack);

        holdingObject = itemData.itemObject;

        return true;
    }

    public void ClearInventory()
    {
        itemData = null;
        itemStack = 0;

        highlightItem.Hide();
        itemText.HideText();
    }
}