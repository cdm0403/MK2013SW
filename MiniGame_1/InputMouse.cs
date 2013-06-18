using UnityEngine;
using System.Collections;

public class InputMouse : MonoBehaviour {
	
	public GameObject m_Balloon;
	public GameObject[] m_Success;
	public static int Score = 0;
	public GameObject m_end;
	private float done = 20F;
	public static int Success = 0;
	public int State=0;
	public GUIText gui_text;
	public GUIText gui_text1;
	public GUIText T_Success;
	public GUITexture m_Main;
	
	public AudioClip m_fail;
	public AudioClip m_successs;
	
	//public GUITexture T_Start;
	int j=1;

	// Use this for initialization
	void Start () {
		for(int i=1;i<26;i++){
			string ii = i.ToString();
			m_Success[i] = GameObject.Find("Sphere"+ii);
		}
		Success = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0)) {
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) { // 위 3줄은 ray를 쏘는 공식.
				if(true == m_Main.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					Home();
				}
				if(hit.transform.tag == "Start_BT"){
					State=1;
					Destroy(hit.transform.gameObject);
				}
				if(hit.transform.tag == "Game_Over"){
					Application.LoadLevel("main");
				}
				if(hit.transform.tag == "plane") { // plane일 경우 생성(plane의 렌더러는 꺼놔서 안보임).
					Instantiate(m_Balloon, hit.point, m_Balloon.transform.rotation);
				} 
				
				if(hit.transform.tag == "balloon") { // 풍선을 클릭하면 멈추게 함.
					hit.transform.GetComponent<Balloon>().Bigger = false;
					if(hit.transform.localScale.x < 60) { //풍선이 60보다 작으면 제거.
						Score = Score - 50;
						AudioSource.PlayClipAtPoint(m_fail,transform.position);
						Destroy(hit.transform.gameObject);
					}
					else if(hit.transform.localScale.x > 80){
						AudioSource.PlayClipAtPoint(m_fail,transform.position);
						Score = Score - 50;
						Destroy(hit.transform.gameObject);
					}	
					else if(hit.transform.localScale.x >=60 && hit.transform.localScale.x <= 80){
						AudioSource.PlayClipAtPoint(m_successs,transform.position);
						Score = Score + 100;
						Success++;
						m_Success[j].renderer.enabled = true;
						j++;
						hit.transform.collider.enabled = false;
						hit.transform.GetComponent<Balloon>().Moving = true; // 성공하면 풍선이 움직이게 함.
					}
				}
			}
			
			
		
		}
		
		gui_text1.text = "Score : "+ Score;
		T_Success.text = "Success : " + Success;
		if(State==1){
			if(done>0F){
				done-=Time.deltaTime;
				gui_text.text = "Time : "+ done.ToString("##.##") +" sec";
	 		}
			else{
		   		gui_text.text = "Time Over"; 
				Instantiate(m_end);
	   		}
		}
	}
	
	void Home()
		{
			Debug.Log("aa");
			Application.LoadLevel("main");
		}
	
}
