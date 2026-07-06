using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FarmBase : MonoBehaviour
{
    [SerializeField] private List<Plot> plots;

    public ItemData cropData;

    private void Awake()
    {
        plots = GetComponentsInChildren<Plot>().ToList();
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