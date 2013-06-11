using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {
	
	public GameObject m_Balloon;
	public bool Bigger; // true일때 계속 커지하는 bool 값.
	//public int Score = 0;
	public bool Moving; // true일때 움직이게 하는 bool 값.
	//public GUIText gui_textscore;
	//int r; //방향 랜덤.

	// Use this for initialization
	void Start () {
		Bigger = true; 
		Moving = false;
		
		//r = Random.Range(0,4);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Bigger) {
			
			transform.localScale = new Vector3(transform.localScale.x + 2.5f, 
				transform.localScale.y + 2.5f, transform.localScale.z + 2.5f); // Scale 0.1씩 커지게 함.
		}
		
		if(Moving) {			
			transform.Translate(1.5f,0,0);
			//else if(r==1) transform.Translate(-0.6f,0,0);
			//else if(r==2) transform.Translate(0,0.6f,0);
			//else if(r==3)  transform.Translate(0,-0.6f,0);
		}
		if(transform.localScale.x>70){
			InputMouse.Score-=50;
			Destroy(transform.gameObject);
		}
		
	}
}
