using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject title;
	GameObject subtitle1;
	GameObject subtitle2;

	// Use this for initialization
	void Start () {

		title = GameObject.Find("Title");
		subtitle1 = GameObject.Find("Subtitle1");
		subtitle2 = GameObject.Find("Subtitle2");
	
	}
	
	// Update is called once per frame
	void Update () {

		subtitle1.guiText.text = "Use of this device is exclusively reserved to Inspectors, in matters of Economic and Social Security.\n" +
			"Any other employee found using this device will be permanently relocated.";

		subtitle2.guiText.text = "Caution must be maintained at all times when operating the system on incriminated individuals, as health risks may appear.\n" +
			"In any case of serious* injury, please contact your assigned governmental physician via the dedicated interface.";
	
	}
}
