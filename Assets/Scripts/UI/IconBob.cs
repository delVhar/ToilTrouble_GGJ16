using UnityEngine;
using System.Collections;

public class IconBob : MonoBehaviour
{
    public bool bobbing = true;
    public float bobSpeed = 10f;
    public float amount = 15f;

    
    // Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(bobbing)
        {
            GetComponent<RectTransform>().Translate(new Vector3(0, Mathf.Cos(Time.timeSinceLevelLoad * 10), 0) * amount * Time.deltaTime);
        }
	}

   /*public void UpdatePos(Vector3 newPos)
    {
        GetComponent<RectTransform>().anchoredPosition = newPos;
    }*/
}
