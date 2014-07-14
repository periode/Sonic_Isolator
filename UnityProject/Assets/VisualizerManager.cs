using UnityEngine;
using System.Collections;

public class VisualizerManager : MonoBehaviour {


	public GameObject volGauge;
	public GameObject mouse;

	float r;
	public float minValueY;
	public float minValueX;

	Vector2 randomScale;

	// Use this for initialization
	void Start () {


		minValueX = 0.3f;
		minValueY = 0.1f;

		randomScale = new Vector2(minValueX, minValueY); 
	
	}
	
	// Update is called once per frame
	void Update () {
		r = (volGauge.audio.volume)*1.0f;
		if(mouse.GetComponent<Mouse>().power){
			randomScale = transform.localScale;
			randomScale.y = Random.Range(minValueY, r);
			randomScale.x = Random.Range(minValueX, r);
			transform.localScale = randomScale;
		}
	
	}
}
