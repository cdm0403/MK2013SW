using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
  
	public static bool onMaker;
	public static int Mode; // 0. Pour Mode , 1. Bubble Mode
	
	public GameObject m_Bubble;	
	bool FirstButton;
	
	GameObject go;
	
	// Use this for initialization
	void Start () {
		
		onMaker = false;
		FirstButton = true;
		Mode = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		 if (Input.GetMouseButton(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit)) {
				if(hit.transform.tag == "cup" && Mode == 1) {
					Debug.Log("cup");					
					if(FirstButton) {
						go = (GameObject)Instantiate(m_Bubble, hit.transform.position, m_Bubble.transform.rotation);
						go.transform.position = new Vector3(go.transform.position.x,
							go.transform.position.y+10, go.transform.position.z);
						FirstButton = false;
					}					
				}	
				
				if(hit.transform.tag == "bubble" ) {
					Debug.Log("bubble");
					go.transform.localScale = new Vector3(go.transform.localScale.x+0.1f,
						go.transform.localScale.y+0.1f, go.transform.localScale.z+0.1f);
				}				
			}				
		}	
		
		if(Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	
	}
}
