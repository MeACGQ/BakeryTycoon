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

    public void AddItem(ItemData _data)
    {
        if (itemData == _data)
        {
            itemStack++;

            itemText.HiglightText(itemStack);
        }
        else
        {
            itemData = _data;

            itemStack++;
     
            highlightItem.Highlight(_data.itemObject);
        }

        holdingObject = itemData.itemObject;
    }

    public void ClearInventory()
    {
        itemData = null;
        itemStack = 0;

        highlightItem.Hide();
        itemText.HideText();
    }
}