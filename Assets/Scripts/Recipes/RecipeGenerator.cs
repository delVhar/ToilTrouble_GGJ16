using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecipeGenerator : MonoBehaviour {

    public TextAsset adjList;
    public TextAsset nounList;

    public List<Recipe> GeneratedRecipes;
    public List<GenericIngredient> AvailableIngredients;
    public List<PotionIcon> PotionIcons;

    
    [Range(0.0f, 1.0f)]
    public float colourSaturation = 0.5f;
    [Range(0.0f, 1.0f)]
    public float colorBrightness = 1f;

    public string[] adjectives;
    public string[] nouns;

	// Use this for initialization
	void Start ()
    {
        ReadNouns();
        ReadAdjectives();
        GeneratedRecipes = new List<Recipe>();

        /*for (int i = 0; i < 10; i++)
        {
            GeneratePotion();
        }
        Debug.Log(Time.realtimeSinceStartup);*/

    }
	
	// Update is called once per frame
	void Update ()
    {
       // testColor = SelectColor();

       /* if(GeneratedRecipes.Count < 200)
        {
            GeneratePotion();
        }
        else
        {
            Debug.Log(Time.realtimeSinceStartup);
            this.gameObject.SetActive(false);
        }*/
    }

    void ReadNouns()
    {
        nouns = nounList.text.Split("\n"[0]);
    }

    void ReadAdjectives()
    {
        adjectives = adjList.text.Split("\n"[0]);
    }

    bool AllowPotion(Recipe newRecipe)
    {
        foreach(Recipe r in GeneratedRecipes)
        {
            if (r.CheckPotion(newRecipe.requiredIngredients) || r.potionName.Equals(newRecipe.potionName))
                return false;
        }
        return true;
    }

    public List<GenericIngredient> SelectIngredients()
    {
        List<GenericIngredient> ingredients = new List<GenericIngredient>();
        while(ingredients.Count < 3)
        {
            int randInt = Random.Range(0, AvailableIngredients.Count);
            ingredients.Add(AvailableIngredients[randInt]);
        }

        return ingredients;
    }

    public string GenerateName()
    {
        int nounInt = Random.Range(0, nouns.Length);
        int adjInt = Random.Range(0, adjectives.Length);

        return string.Format("{0} {1} Potion", adjectives[adjInt], nouns[nounInt]);
    }

    public Color SelectColor()
    {
        return Color.HSVToRGB(Random.Range(0.0f, 1.0f), colourSaturation, colorBrightness);
    }

    public PotionIcon SelectIcon()
    {
        return PotionIcons[Random.Range(0, PotionIcons.Count)];
    }

    public Recipe RandomPotion()
    {
        Recipe newRecipe = new Recipe(
            SelectIngredients(),
            GenerateName(),
            SelectIcon(),
            SelectColor());

        return newRecipe;
    }

    public void GeneratePotion()
    {
        if (GeneratedRecipes.Count > 200)
            return;
        //int i = 0;
        while (true)
        {
            // Make sure we don't loop too long.
            /*i++;
            if (i > 200)
                return;*/

            Recipe newPotion = RandomPotion();
            if (AllowPotion(newPotion))
            {
                GeneratedRecipes.Add(newPotion);
                return;
            }
        }
    }

}
