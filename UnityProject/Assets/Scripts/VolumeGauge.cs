using UnityEngine;
using System.Collections;

public class VolumeGauge : MonoBehaviour {

	public float standardThreshold;
	public float extremeThreshold;
	public float volumeCap;

	public GameObject volumeFill;
	public GameObject mouse;

	Vector2 scale;
	Vector2 position;

	Vector2 startScale = new Vector2(0.9f, 0.01f);
	Vector2 startPos = new Vector2(0, -0.48f);

	// Use this for initialization
	void Start () {

		volumeFill.transform.localScale = startScale;
		volumeFill.transform.localPosition = startPos;
		volumeCap = standardThreshold;
		audio.volume = 0;



	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButton(0) && mouse.GetComponent<Mouse>().vol){

			scale = volumeFill.transform.localScale;
			position = volumeFill.transform.localPosition;

			scale.y = (Input.mousePosition.y)/(Screen.height*0.98f);
			position.y = -(((Input.mousePosition.y)/(Screen.height*0.95f))*startPos.y)+startPos.y;

			volumeFill.transform.localScale = scale;
			volumeFill.transform.localPosition = position;



			audio.volume = scale.y;
		}

		if(audio.volume > volumeCap){
			audio.volume = volumeCap;
		}

		Debug.Log("volume :"+audio.volume);
	}
}
