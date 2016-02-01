using UnityEngine;
using System.Collections;

public class ForceResolution : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        if (Screen.height > 1000)
        {
            Screen.SetResolution(576, 1024, false);
        }
        else
        {
            Screen.SetResolution(405, 720, false);
        }
        Screen.orientation = ScreenOrientation.Portrait;
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
