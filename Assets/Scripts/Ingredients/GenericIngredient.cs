using UnityEngine;
using System.Collections;

public enum IngredientEnum
{
    Eye,
    Mandrake,
    Berries,
    Feather,
    Tentacle,
    Wand,
    RuneStone
}

public class GenericIngredient : MonoBehaviour {

    public IngredientEnum IngredientName;
    //public string readableName; // Probably don't need this.
    public Texture recipeIcon;
    public Sprite tableIcon;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
