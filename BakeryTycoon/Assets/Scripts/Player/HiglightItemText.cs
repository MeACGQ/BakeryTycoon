using TMPro;
using UnityEngine;

public class HiglightItemText : MonoBehaviour
{
    public TextMeshProUGUI itemCounterText;

    public void HiglightText(int _count)
    {
        itemCounterText.text = _count.ToString() + "X";
    }

    public void HideText()
    {
        itemCounterText.text = "";
    }
}
