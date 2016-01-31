using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapManager : MonoBehaviour
{

    public RectTransform mapPanel;
    public RectTransform gameOverPanel;

    public Text textDisplay; 
    public float displayTime = 3;    
    float counter;
    bool visible;
    public bool gameOver = false;

	// Use this for initialization
	void Start () {
        //ShowMap(1);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(visible && !gameOver)
        {
            counter += Time.deltaTime;
            if(counter >= displayTime)
            {
                HideMap();
            }
        }
	}

    public void ShowMap(int day)
    {
        textDisplay.text = "Day: " + day;
        mapPanel.gameObject.SetActive(true);
        counter = 0f;
        visible = true;
    }

    public void ShowGameOver()
    {
        gameOver = true;
        gameOverPanel.gameObject.SetActive(true);
    }

    public void HideMap()
    {
        mapPanel.gameObject.SetActive(false);
        counter = 0f;
        visible = false;

    }
}
