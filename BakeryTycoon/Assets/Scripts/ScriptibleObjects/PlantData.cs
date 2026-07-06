using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/PlantData", fileName = "PlantData")]
public class PlantData : ScriptableObject
{
    public string plantName;

    public float growTime;

    public GameObject seedObject;

    public GameObject plantObject;
}
