using UnityEngine;
using System.Collections;

public class GO_Main : MonoBehaviour {
  public GUITexture m_Main;
	public AudioClip m_BG;
	
	// Use this for initialization
	void Start () {
	AudioSource.PlayClipAtPoint(m_BG,transform.position);
	}

	void Update () {
	if( Application.isEditor ) // PC
		{
			if( Input.GetMouseButtonDown(0) ) {
				if(true == m_Main.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					Main();
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
						Main();
					}
					
				}
			}
		}
	}
	void Main()
	{
		Debug.Log("aa");
		 Application.LoadLevel("main");
	}	
}
