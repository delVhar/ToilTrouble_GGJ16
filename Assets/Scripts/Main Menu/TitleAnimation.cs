using UnityEngine;
using System.Collections;

public class TitleAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		int x = 0;
		x += 1;
		float f = Mathf.Clamp (Mathf.Cos (Time.realtimeSinceStartup), -1f, 1f);
		float g = Mathf.Clamp (Mathf.Sin (Time.realtimeSinceStartup), -1f, 1f);
		this.GetComponent<RectTransform>().localScale -= (new Vector3(f * 0.05f, f * 0.05f, 0) * Time.deltaTime);
		transform.Rotate (Vector3.forward * -g * 0.05f);
	}
}
