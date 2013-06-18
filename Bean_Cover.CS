using UnityEngine;
using System.Collections;


public class Bean_Cover : MonoBehaviour {
    public GameObject m_Bean1;
	public GameObject m_Bean2;
	public GameObject m_start;
	public GameObject m_end;
	private float RandomX;
	public int state=0;
	public float Cover_delay=3.0f;
	int R2;

	public static int Score = 0;
	private float done = 20F;
	public static int Success = 0;
	public GUIText gui_text;
	public GUIText gui_text1;
	public GUITexture m_Main;
	
	public AudioClip m_pung;
	
	// Use this for initialization


	void Start () {
		state=0;
		Score = 0;
	}


	// Update is called once per frame
	void Update () {
		gui_text1.text = "Score : "+ Score;
		
		
		if(state==1){
			if(done>0F){
				done-=Time.deltaTime;
				gui_text.text = "Time : "+ done.ToString("##.##") +" sec";
	 		}
			else{
			   	gui_text.text = "Time Over"; 
				Instantiate(m_end);
	 	  	}
		}

	if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;		
			R2 = Random.Range(0,2);
			if (Physics.Raycast(ray, out hit)) {
				if(hit.transform.tag == "Game_Over"){
					Application.LoadLevel("main");
				}
				
				if(hit.transform.tag == "Game_Start"){
					state=1;
					Destroy(hit.transform.gameObject);
				}
				if(hit.transform.tag == "Bean_Cover") {
					AudioSource.PlayClipAtPoint(m_pung,transform.position);
					RandomX = Random.Range(0,90);
					if(R2==0){
					Instantiate(m_Bean1, hit.point, m_Bean1.transform.rotation);
					}
					if(R2==1){
					Instantiate(m_Bean2, hit.point, m_Bean2.transform.rotation);
					}
					/*
					Instantiate(m_Bean, hit.point, m_Bean.transform.rotation);
					hit.transform.collider.enabled = false;
					hit.transform.GetComponent<Bean>().Moving=true;
					//Rigidbody body=go.GetComponent<Rigidbody>();
					//body.AddForce( transform.right * 5f);
					*/
					StartCoroutine(Cover());
					renderer.enabled = false;
					gameObject.tag="Untagged";
					//StartCoroutine(Cover());
					//gameObject.SetActive(true);
					
				}	
		}
			//gameObject.SetActive(false);
		}
		/*
		if(gameObject==gameObject.SetActive(false))
		{
			Cover_delay-=Time.deltaTime;
			if(Cover_delay<0)
			{
				gameObject.SetActive(true);
			}
		}
		*/
		
		///메인으로 가는 스크립트/// 

			if( Input.GetMouseButtonDown(0) ) {
				if(true == m_Main.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					Home();
				}
			}
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
		///메인으로 가는 스크립트 -끝- /// 
	}
	
	 IEnumerator Cover(){
        yield return new WaitForSeconds(1f);
		Debug.Log("stop");
		renderer.enabled = true;
		gameObject.tag="Bean_Cover";	
    }
	
	void Home()
	{
		Debug.Log("aa");
		 Application.LoadLevel("main");
	}
}
