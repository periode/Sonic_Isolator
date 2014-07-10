using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	Vector2 mousePosition;
	Vector2 powerPosition;
	Vector2 extremePosition;
	Vector2 healthPosition;

	public bool power;
	public bool extreme;
	public bool health;
	public bool vol;

	int s;

	public GameObject button1;
	public GameObject button2;
	public GameObject button3;

	public GameObject volumeGauge;

	// Use this for initialization
	void Start () {

		powerPosition = GameObject.FindGameObjectWithTag("Power").transform.position;
		extremePosition = GameObject.FindGameObjectWithTag("Extreme").transform.position;
		healthPosition = GameObject.FindGameObjectWithTag("Health").transform.position;

		power = false;
		extreme = false;
		health = false;
		vol = false;

		s = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = mousePosition;

		Debug.Log(power);

		if(Input.GetMouseButtonDown(0)){
			switch (s) {
			case 1://volume

				break;
			case 2://power

				power = !power;
				break;
			case 3://extreme frequencies

				extreme = !extreme;
				break;
			case 4://health

				health = !health;
				break;
			default:
				//no interaction so far
				break;
			}
		}

		if(power){
			volumeGauge.audio.Play();
			button1.renderer.enabled = true;
		}else{
			volumeGauge.audio.Stop();
			button1.renderer.enabled = false;
		}

		if(extreme){
			volumeGauge.audio.volume = volumeGauge.GetComponent<VolumeGauge>().extremeThreshold;
			button2.renderer.enabled = true;
		}else{
			volumeGauge.audio.volume = volumeGauge.GetComponent<VolumeGauge>().standardThreshold;
			button2.renderer.enabled = false;
		}

		if(!health) button3.renderer.enabled = false;
		if(health) button3.renderer.enabled = true;
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Volume"){
			vol = true;
			s = 1;
		}else if(col.tag == "Power"){
			s = 2;
		}else if(col.tag == "Extreme"){
			s = 3;
		}else if(col.tag == "Health"){
			s = 4;
		}
	}

	void OnTriggerExit2D(){
		vol = false;
		s = 0;
	}
}
