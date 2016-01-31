using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutcomePageManager : MonoBehaviour {

    public RectTransform outcomePanel;
    public Text dayText;
    public Text resultText;
    //public bool success;

    public Image liquidImage;
    public Image skullImage;
    public Image outcomeImage;


    public Sprite failSprite;
    public Sprite successSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowPanel(bool result, int score, int total, Color col, int day)
    {
        outcomePanel.gameObject.SetActive(true);
        if (result)
        {
            outcomeImage.sprite = successSprite;
            skullImage.gameObject.SetActive(false);
        }
        else
        {
            outcomeImage.sprite = failSprite;
            skullImage.gameObject.SetActive(true);
        }

        liquidImage.color = col;
        dayText.text = "Day " + day;
        resultText.text = score + " / " + total;
    }

    public void HidePanel()
    {
        outcomePanel.gameObject.SetActive(false);
    }
}
