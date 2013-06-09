using UnityEngine;
using System.Collections;

public class Button_Manager : MonoBehaviour {
  
	/*
	public string GameStart;
	public string End;
	*/
	
	public string S_Bean;
	public string S_Bubble;
	public string S_Home;
	public string S_exit;
	public GUITexture m_Bean;
	public GUITexture m_Bubble;
	public GUITexture m_Home;
	public GUITexture m_exit;
	
	//public AudioClip m_mainBGM;
	
	void start()
	{
		//AudioSource.PlayClipAtPoint(m_mainBGM,transform.position);
	}


	void Update ()
	{
		if( Application.isEditor ) // PC
		{
			if( Input.GetMouseButtonDown(0) ) {
				if(true == m_Bean.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					Bean();
				}
				if(true == m_Bubble.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					Bubble();
				}
				if(true == m_Home.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					Debug.Log("dd");
					Home();
				}
				if(true == m_exit.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					Exit();
				}
			}
		}
		
		else { // Mobile
			if( Input.touchCount > 0 )
			{
				Touch touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Began)
				{
					if( m_Bean.HitTest( touch.position )) {
						Bean();
					}
					if( m_Bubble.HitTest( touch.position )) {
						Bubble();
					}
					if( m_exit.HitTest( touch.position )) {
						Home();
					}
					if( m_Bubble.HitTest( touch.position )) {
						Exit();
					}
				}
			}
		}
	}
	
	void Bean()
	{
		Application.LoadLevel("Bean");
	}
	void Bubble()
	{
		Application.LoadLevel("Bubble");
	}	
	void Home()
	{
		Application.LoadLevel("Home");
	}	
	void Exit()
	{
		 Application.Quit();
	}	
}













