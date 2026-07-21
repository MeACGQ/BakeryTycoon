using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI itemText;

    private void OnEnable()
    {
        MoneyManager.Instance.OnMoneyChanged += UpdateMoneyText;
        PlayerInventory.Instance.OnStackChanged += UpdateItemText;
        PlayerInventory.Instance.OnInventoryCleared += ClearText;
    }

    private void OnDisable()
    {
        MoneyManager.Instance.OnMoneyChanged -= UpdateMoneyText;
        PlayerInventory.Instance.OnStackChanged -= UpdateItemText;
        PlayerInventory.Instance.OnInventoryCleared -= ClearText;
    }

    private void UpdateMoneyText(int _money)
    {
        moneyText.text = "$" + _money;
    }

    private void UpdateItemText(int _stackCount)
    {
        itemText.text = _stackCount + "X";
    }

    private void ClearText()
    {
        itemText.text = "";
    }
}
