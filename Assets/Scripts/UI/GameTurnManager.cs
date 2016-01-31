using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameTurnManager : MonoBehaviour {

    public MapManager map;
    public ScrollManager scroll;
    public ShopManager shop;
    public OutcomePageManager outcome;

    public SoundManager sound;
    
    public RecipeGenerator recipes;
    public int dayNumber = 0;
    public int numberToCraft = 3;
    public int numberSuccess;

    public int livesLeft = 3;
    public List<RectTransform> bossPlaces;
    public RectTransform boss;
    public Sprite deadTown;

    public List<Recipe> todaysRecipes;
    //public List<RecipeTracking> todaysOutcomes;


    // Use this for initialization
    void Start()
    {
        //recipes.GeneratePotion();
        NewTurn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndTurn()
    {
        bool result;
        // calc success and display!
        shop.speechBubble.gameObject.SetActive(true);
        shop.outcomeImage.gameObject.SetActive(false);
        if (numberSuccess >= (float)(numberToCraft/2f))
        {
            // Success today!
            Debug.Log("Success for day: " + dayNumber);
            result = true;
        }
        else
        {
            // Fail Today!
            livesLeft--;
            result = false;
            boss.anchoredPosition = bossPlaces[livesLeft].anchoredPosition;
            bossPlaces[livesLeft].GetComponent<Image>().sprite = deadTown;
            boss.anchorMax = bossPlaces[livesLeft].anchorMax;
            boss.anchorMin = bossPlaces[livesLeft].anchorMin;
            sound.LifeLost();
            sound.PlayStinger();
            Debug.Log("Failure for day: " + dayNumber);
            if (livesLeft <= 0)
            {
                GameOver();
                return;
            }
        }
        outcome.ShowPanel(result, numberSuccess, numberToCraft, recipes.SelectColor(), dayNumber);
        Invoke("NewTurn", 1.5f);
    }

    public void NewTurn()
    {
        outcome.HidePanel();
        dayNumber++;
        if (recipes.GeneratedRecipes.Count < Mathf.Floor((dayNumber / 200f) * 100 ) + 1)
        {
            recipes.GeneratePotion();
        }
        else
        {
            Debug.Log("Potion not generated.");
        }
        Debug.Log("Number of potions should be: " + (Mathf.Floor((dayNumber / 200f) * 100 ) + 1));
        numberToCraft = (int)Mathf.Ceil((dayNumber / 300f) * 100)+ 1;
        Debug.Log("Need to Craft: " + (Mathf.Ceil((dayNumber / 300f) * 100)+ 1));

        GetRecipes();
        map.ShowMap(dayNumber);
        
        scroll.OpenScroll(todaysRecipes);
        //todaysOutcomes = new List<RecipeTracking>();
        //shop.PrintDetails();
        numberSuccess = 0;
    }

    void GetRecipes()
    {
        todaysRecipes = new List<Recipe>();
        for(int i = 0; i < numberToCraft; i++)
        {
            int randInt = Random.Range(0, recipes.GeneratedRecipes.Count);
            todaysRecipes.Add(recipes.GeneratedRecipes[randInt]);
        }
    }

    void GameOver()
    {
        map.ShowMap(dayNumber);
        map.ShowGameOver();
        sound.GameOver();

        Debug.Log("GameOver");
    }

    public void GoToMain()
    {
        SceneManager.LoadScene(0);
    }
}
