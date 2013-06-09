using UnityEngine;
using System.Collections;

public class InputMouse : MonoBehaviour {
  
	public GameObject m_Balloon;
	public GUIText gui_text1;
	public static int Score = 0;
	private float done = 30.0F;
	public GUIText gui_text;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)) {

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;			
			if (Physics.Raycast(ray, out hit)) { // 위 3줄은 ray를 쏘는 공식.
				if(hit.transform.tag == "plane") { // plane일 경우 생성(plane의 렌더러는 꺼놔서 안보임).
					Instantiate(m_Balloon, hit.point, m_Balloon.transform.rotation);
				} 

				if(hit.transform.tag == "balloon") { // 풍선을 클릭하면 멈추게 함.
					hit.transform.GetComponent<Balloon>().Bigger = false;
					if(hit.transform.localScale.x < 50) { //풍선이 30보다 작으면 제거.
						Score = Score - 50;
						Destroy(hit.transform.gameObject);
					}
					else if(hit.transform.localScale.x > 70){
						Score = Score - 50;
						Destroy(hit.transform.gameObject);
					}	
					else if(hit.transform.localScale.x >=50 && hit.transform.localScale.x <= 70){
						Score = Score + 100;
						hit.transform.collider.enabled = false;
						hit.transform.GetComponent<Balloon>().Moving = true; // 성공하면 풍선이 움직이게 함.
					}
				}
			}
		}

		gui_text1.text = "Score : "+ Score;

		if(done>0F){
			done-=Time.deltaTime;
			gui_text.text = "Time : "+ done.ToString("##.##") +" sec";

	 	}
		else{
		   	gui_text.text = "Time Over"; 
	   	}

	}	
}
