using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public SoundManager sound;

    public RectTransform credits;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        sound.GameOver();
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        credits.gameObject.SetActive(true);
    }

    public void HideCredits()
    {
        credits.gameObject.SetActive(false);
    }
}
