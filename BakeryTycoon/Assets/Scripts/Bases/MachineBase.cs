using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBase : InteractbleBase
{
    public ItemData[] acceptleProducts;

    [SerializeField] GameObject inputProduct;
    [SerializeField] Transform outputPoint;
    [SerializeField] List<Recipe> recipes;
    [SerializeField] float productTime = 3f;

    [SerializeField] int productStack = 0;

    private bool isWorking = false;

    public void AddProduct(ItemData item, int currentStack)
    {
        if (inputProduct == null)
        {
            inputProduct = item.itemObject;

            productStack += currentStack;
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

            GameObject result = GetOutput(inputProduct.name);

            if (result != null)
            {
                Instantiate(result, outputPoint.position, Quaternion.identity);
            }

            productStack--;
        }

        inputProduct = null;

        isWorking = false;
    }

    GameObject GetOutput(string inputName)
    {
        Recipe recipe = recipes.Find(r => r.input == inputName);

        if (recipe == null)
            return null;

        return recipe.output;
    }
}