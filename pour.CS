using UnityEngine;
using System.Collections;

public class Pour : MonoBehaviour {
  
	public GUIText dirX;

	// Use this for initialization
	void Start () {
	
	}
		
	// Update is called once per frame
	void Update () {
		
		Vector3 dir = Vector3.zero;
		dir.x = Input.acceleration.x;
		
		dirX.guiText.text = "dirX :"+dir.x;
			
		 
		if(dir.x < -0.3f && transform.localScale.y*247 < 25 && GameManager.onMaker) {
			
			dir.x *= Time.deltaTime; 	
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y - ((dir.x * 10)/247), transform.localScale.z);
			transform.position = new Vector3 (transform.position.x, transform.lossyScale.y , transform.position.z);
			
			if(transform.localScale.y * 247 > 22) {
				GameManager.Mode = 1;
			}
			
		}	
		
		
	}
}
