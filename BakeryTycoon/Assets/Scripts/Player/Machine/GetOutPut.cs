using System.Collections.Generic;
using UnityEngine;

public class GetOutPut : MonoBehaviour
{
    public ItemData FindOutPut(ItemData _inputName, List<Recipe> recipes)
    {
        Recipe recipe = recipes.Find(r => r.input == _inputName);

        if (recipe == null)
            return null;

        return recipe.output;
    }
}
