using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Recipe
{
    public List<GenericIngredient> requiredIngredients;
    public string potionName;
    public PotionIcon icon;
    public Color potionColour;
    

    public Recipe()
    {
        
    }

    public Recipe(List<GenericIngredient> ingredients, string name, PotionIcon i, Color color)
    {
        requiredIngredients = ingredients;
        potionName = name;
        icon = i;
        potionColour = color;

    }

    public bool CheckPotion(List<GenericIngredient> potion)
    {
        return requiredIngredients.SequenceEqual(potion);
    }
}
