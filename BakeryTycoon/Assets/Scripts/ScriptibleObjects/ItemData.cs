using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/ItemData", fileName = "ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public GameObject itemObject;
}
