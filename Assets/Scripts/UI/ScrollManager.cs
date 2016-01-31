using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScrollManager : MonoBehaviour {

    public SoundManager sound;

    public RectTransform scrollContent;
    public RectTransform recipeParent;
    public RectTransform scrollBottom;

    public Button scrollButton;
    public Vector2 recipeStart = new Vector2(0f, -256f);
    public RecipeText recipePrefab;
    public List<RecipeText> recipiesShown;
    public float recipeTextHeight = 96;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowRecipes(List<Recipe> recipies)
    {
        recipiesShown = new List<RecipeText>();
        foreach (Recipe r in recipies)
        {
            RecipeText rt = Instantiate<RecipeText>(recipePrefab);
            rt.transform.SetParent(recipeParent, false);
            rt.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, recipeStart.y - (recipeTextHeight * recipiesShown.Count));
            rt.GetComponent<RectTransform>().offsetMax = new Vector2(0, rt.GetComponent<RectTransform>().offsetMax.y);
            rt.GetComponent<RectTransform>().offsetMin = new Vector2(0, rt.GetComponent<RectTransform>().offsetMin.y);

            rt.potionName.text = r.potionName;
            rt.potionName.color = r.potionColour;
            rt.potionBottle.sprite = r.icon.bottleIcon;
            rt.potionColour.sprite = r.icon.liquidIcon;
            rt.potionColour.color = r.potionColour;
            rt.ingredient1.sprite = r.requiredIngredients[0].tableIcon;
            rt.ingredient2.sprite = r.requiredIngredients[1].tableIcon;
            rt.ingredient3.sprite = r.requiredIngredients[2].tableIcon;
            
            
            recipiesShown.Add(rt);
        }
        RectTransform bottom = Instantiate<RectTransform>(scrollBottom);
        bottom.SetParent(recipeParent, false);
        bottom.anchoredPosition = new Vector2(0f, recipeStart.y - (recipeTextHeight * recipiesShown.Count) - 20);
        bottom.offsetMax = new Vector2(0, bottom.offsetMax.y);
        bottom.offsetMin = new Vector2(0, bottom.offsetMin.y);

        if(recipiesShown.Count > 4)
        {
            recipeParent.offsetMin = new Vector2(0, -(recipeTextHeight * (recipiesShown.Count - 4) + 400));
        }
    }

    public void CloseScroll()
    {
        //scrollButton.GetComponent<FMODUnity.StudioEventEmitter>().Play();
        sound.PlayScroll();
        for (int i = recipiesShown.Count - 1; i >= 0; i--)
        {
            Destroy(recipiesShown[i].gameObject);
        }        
        scrollContent.gameObject.SetActive(false);
    }

    public void OpenScroll(List<Recipe> recipies)
    {
        ShowRecipes(recipies);
        scrollContent.gameObject.SetActive(true);
    }
}

