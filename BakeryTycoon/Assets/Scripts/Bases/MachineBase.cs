using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBase : InteractbleBase
{
    [Header("References")]
    [SerializeField] HighlightItem highlightInput;
    [SerializeField] HighlightItem highlightOutput;
    GetOutPut Getoutput;

    [Header("Products")]
    [SerializeField] public ItemData[] acceptableProducts;
    [SerializeField] public ItemData inputProduct;
    [SerializeField] public ItemData outputProduct;

    [Header("Recipes")]
    [SerializeField] private List<Recipe> recipes;

    [Header("Production Settings")]
    [SerializeField] private float productTime = 3f;

    [Header("Stacks")]
    [SerializeField] private int productStack = 0;
    public int outputStack = 0;

    private bool isWorking = false;
    private bool outputCreated = false;

    private void Start()
    {
        Getoutput = GetComponent<GetOutPut>();
    }

    public void AddProduct(ItemData item, int currentStack)
    {
        if (inputProduct == null)
        {
            inputProduct = item;

            productStack += currentStack;

            highlightInput.Highlight(inputProduct);
        }
        else
            productStack += currentStack;

        Produce();
    }

    public void Produce()
    {
        if (isWorking) return;

        if (inputProduct == null) return;

        StartCoroutine(MakingProduct());
    }

    public IEnumerator MakingProduct()
    {
        isWorking = true;

        while (productStack > 0)
        {
            yield return new WaitForSeconds(productTime);

            outputProduct = GetOutput(inputProduct);

            if (outputProduct != null && !outputCreated)
            {
                highlightOutput.Highlight(outputProduct);

                outputCreated = true;
            }

            productStack--;

            outputStack++;
        }

        highlightInput.Hide();

        inputProduct = null;

        isWorking = false;
    }

    ItemData GetOutput(ItemData _inputName)
    {
        return Getoutput.FindOutPut(_inputName, recipes);
    }

    public void ClearMachine()
    {
        outputProduct = null;
        outputStack = 0;
        outputCreated = false;

        highlightOutput.Hide();
    }
}