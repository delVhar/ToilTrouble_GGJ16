using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour {

    public Image ingredient1;
    public Image ingredient2;
    public Image ingredient3;
    public Button mixButton;

    public Image outcomeImage;
    public Sprite outcomePass;
    public Sprite outcomeFail;


    public GameTurnManager gtm;
    public int currentRecipe = 0;
    public List<GenericIngredient> currentIngredients;

    public RectTransform speechBubble;
    public Text potionText;

    public FMODUnity.StudioEventEmitter buttonEmitter;
    public FMODUnity.StudioEventEmitter outcomeEmitter;

    public Image customer;
    public List<Sprite> customerSprites;
    public Vector2 customerHidden;
    public Vector2 customerVisible;
    public float customerMoveSpeed;

    public SoundManager sound;

    // Use this for initialization
    void Start ()
    {
        //buttonEmitter = GetComponent<FMODUnity.StudioEventEmitter>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PrintDetails()
    {
        Recipe r = gtm.todaysRecipes[currentRecipe];
        Debug.Log("Now make a : " + gtm.todaysRecipes[currentRecipe].potionName);
        Debug.Log(string.Format("{0}, {1}, {2}", 
            r.requiredIngredients[0].IngredientName.ToString(),
            r.requiredIngredients[1].IngredientName.ToString(),
            r.requiredIngredients[2].IngredientName.ToString()));

        outcomeImage.gameObject.SetActive(false);
        speechBubble.gameObject.SetActive(true);
        potionText.text = gtm.todaysRecipes[currentRecipe].potionName;
        potionText.color = gtm.todaysRecipes[currentRecipe].potionColour;
    }

    public void MakePotion()
    {
        if(currentIngredients.Count < 3)
        {
            // We shouldn't be visible...
            mixButton.gameObject.SetActive(false);
            return;
        }
        

        if (gtm.todaysRecipes[currentRecipe].CheckPotion(currentIngredients))
        {
            //gtm.todaysOutcomes.Add(new RecipeTracking(gtm.todaysRecipes[currentRecipe], true));
            gtm.numberSuccess++;
            Debug.Log("Made a potion!");
            outcomeImage.sprite = outcomePass;
            //outcomeEmitter.SetParameter("Success", 1f);
            sound.PlayPotion(true);
            //Debug.Log("Param: " + outcomeEmitter.Params[0].Name + " is: " + outcomeEmitter.Params[0].Value);
        }
        else
        {
            Debug.Log("Failed to make a potion!");
            outcomeImage.sprite = outcomeFail;
            sound.PlayPotion(false);
            //outcomeEmitter.SetParameter("Success", 0f);
            //Debug.Log("Param: " + outcomeEmitter.Params[0].Name + " is: " + outcomeEmitter.Params[0].Value);
        }

        DiscardPotion();
        outcomeImage.gameObject.SetActive(true);
        //outcomeEmitter.Play();
        currentRecipe++;

        HideBubble();
        
        // Not using due to only 1 character :(
        //CustomerLeave
        //NewCustomer();
        //CustomerEnter;


        if (currentRecipe >= gtm.numberToCraft)
        {
            // that's all.
            currentRecipe = 0;
            gtm.Invoke("EndTurn", 1.5f);
            //gtm.EndTurn();
        }
        else
        {
            Invoke("PrintDetails", 1.5f);
            //PrintDetails();
        }
    }

    

    public void UseIngredient(GenericIngredient i)
    {
        if (currentIngredients.Count >= 3)
            return;

        currentIngredients.Add(i);
        //buttonEmitter.Play();
        sound.PlayMix();
        switch(currentIngredients.Count)
        {
            case 1:
                ingredient1.gameObject.SetActive(true);
                ingredient1.sprite = i.tableIcon;
                break ;

            case 2:
                ingredient2.gameObject.SetActive(true);
                ingredient2.sprite = i.tableIcon;
                break;

            case 3:
                ingredient3.gameObject.SetActive(true);
                ingredient3.sprite = i.tableIcon;
                mixButton.gameObject.SetActive(true);
                break;
        }
    }

    public void DiscardPotion()
    {
        sound.PlayButton();
        ingredient1.gameObject.SetActive(false);
        ingredient2.gameObject.SetActive(false);
        ingredient3.gameObject.SetActive(false);
        mixButton.gameObject.SetActive(false);
        currentIngredients = new List<GenericIngredient>();
    }

    public void DiscardPotion(bool quiet)
    {
        if (!quiet)
        {
            DiscardPotion();
            return;
        }

        ingredient1.gameObject.SetActive(false);
        ingredient2.gameObject.SetActive(false);
        ingredient3.gameObject.SetActive(false);
        mixButton.gameObject.SetActive(false);
        currentIngredients = new List<GenericIngredient>();
    }

    public void HideBubble()
    {
        speechBubble.gameObject.SetActive(false);
    }

    public void CustomerEnter()
    {

    }

    public void CustomerExit()
    {

    }

    public void NewCustomer()
    {
        int randInt = Random.Range(0, customerSprites.Count);
        customer.sprite = customerSprites[randInt];
    }
}
