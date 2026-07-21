using System.Collections.Generic;
using UnityEngine;

public class FarmBase : MonoBehaviour
{
    [SerializeField] private List<Plot> plots;

    public ItemData cropData;

    private void Awake()
    {
        plots = new List<Plot>(GetComponentsInChildren<Plot>());
    }

    private void Start()
    {
        StartPlanting();
    }

    public void StartPlanting()
    {
        foreach (var plot in plots)
        {
            plot.StartPlant(cropData);
        }
    }
}