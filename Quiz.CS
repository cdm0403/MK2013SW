using UnityEngine;
using System.Collections;

public class Quiz : MonoBehaviour {
  
	public GameObject[] QuizObj1,QuizObj2,QuizObj3,QuizObj4;
	public GameObject[] AnswerObj;
	public GUIText m_Text;
	public GUIText m_Text1;
	public GUITexture m_Main;
	public int i;
	public string ii;
	// Use this for initialization
	void Start () {	
		NextQuiz();	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
					if (Physics.Raycast(ray, out hit)) {
						if(hit.transform.name+"(Clone)" == AnswerObj[i].transform.name){
							m_Text.enabled = true;
							m_Text.guiText.text = "True";
							StartCoroutine(textEnbleDelay(m_Text, 2f));
						}
				
						else { // 오답일때.
							m_Text.enabled = true;
							m_Text.guiText.text = "False";
							StartCoroutine(textEnbleDelay(m_Text, 2f));
					}
				}
		}
		
		
		
		///메인으로 가는 스크립트/// 
		if( Application.isEditor ) // PC
		{
			if( Input.GetMouseButtonDown(0) ) {
				if(true == m_Main.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					Home();
				}
			}
		}
		else { // Mobile
			if( Input.touchCount > 0 )
			{
				Touch touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Began)
				{
					if( m_Main.HitTest( touch.position )) {
						Home();
					}
					
				}
			}
		}
		///메인으로 가는 스크립트 -끝- /// 
		
	
	}
	
	void NextQuiz() { // 다음 퀴즈 내는 함수.
		if(AnswerObj[1] != null) {
			Destroy(AnswerObj[1].transform.gameObject);
			Destroy(AnswerObj[2].transform.gameObject);
			Destroy(AnswerObj[3].transform.gameObject);
			Destroy(AnswerObj[4].transform.gameObject);
		}
		i= Random.Range(1,5);
		ii=i.ToString();
		int r1,r2,r3,r4;
		Vector3 v1,v2,v3,temp;
		
		temp=transform.position;
		
		r1= Random.Range(1,8);
		r2= Random.Range(1,8);
		r3= Random.Range(1,8);
		r4= Random.Range(1,8);
		
		GameObject go1 = (GameObject) Instantiate(QuizObj1[r1], temp, QuizObj1[r1].transform.rotation);
		AnswerObj[1] = go1;
		StartCoroutine(ObjEnbleDelay(AnswerObj[1], 1f));
		
		v1=temp;
		v1.x= -1.0f;
		
		v2=temp;
		v2.x= 1.0f;
		
		v3=temp;
		v3.x= 3.0f;
		
		GameObject go2 = (GameObject) Instantiate(QuizObj2[r2], v1, QuizObj2[r2].transform.rotation);
		AnswerObj[2] = go2;
		StartCoroutine(ObjEnbleDelay(AnswerObj[2], 1f));
		
		GameObject go3 = (GameObject) Instantiate(QuizObj3[r3], v2, QuizObj3[r3].transform.rotation);
		AnswerObj[3] = go3;
		StartCoroutine(ObjEnbleDelay(AnswerObj[3], 1f));
		
		GameObject go4 = (GameObject) Instantiate(QuizObj4[r4], v3, QuizObj4[r4].transform.rotation);
		AnswerObj[4] = go4;
		StartCoroutine(ObjEnbleDelay(AnswerObj[4], 1f));
		m_Text.enabled = true;
		m_Text1.guiText.text ="Select Number :" + ii;
		textEnbleDelay(m_Text1, 1f);
		
	}
	
	IEnumerator ObjEnbleDelay(GameObject obj, float delay) { // 오브젝트 사라지는 딜레이.
		
		yield return new WaitForSeconds(delay);
		if(obj != null) {
			obj.renderer.enabled = false;			
		}
	}
	
	IEnumerator textEnbleDelay(GUIText obj, float delay) { // 텍스트 사라지는 딜레이.
		
		yield return new WaitForSeconds(delay);
		if(obj != null) {
			obj.enabled = false;
		}
		NextQuiz(); // 텍스트가 사라지고 다음문제 출제.
		
	}
	void Home()
	{
		Debug.Log("aa");
		 Application.LoadLevel("main");
	}
}
