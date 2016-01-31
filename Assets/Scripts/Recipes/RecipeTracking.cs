using UnityEngine;
using System.Collections;

public class RecipeTracking
{
    public Recipe recipe;
    public bool createdSuccessfully;

    public RecipeTracking(Recipe r, bool outcome)
    {
        recipe = r;
        createdSuccessfully = outcome;
    }
}
