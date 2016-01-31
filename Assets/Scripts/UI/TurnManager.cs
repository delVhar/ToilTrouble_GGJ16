using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public MapManager map;
    public ScrollManager scroll;
    public ShopManager shop;


    public RecipeGenerator recipes;
    public int dayNumber = 0;
    public int numberToCraft = 3;

    
    
    // Use this for initialization
	void Start ()
    {
        recipes.GeneratePotion();
        NewTurn();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewTurn()
    {
        dayNumber++;
        if (recipes.GeneratedRecipes.Count < Mathf.FloorToInt((dayNumber/200) * 100) + 1)
        {
            recipes.GeneratePotion();
        }
        numberToCraft = Mathf.CeilToInt((dayNumber / 200) * 100) + 2;
        map.ShowMap(dayNumber);
    }
}
