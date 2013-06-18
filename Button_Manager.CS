using UnityEngine;
using System.Collections;

public class Button_Manager : MonoBehaviour {
	
	
	public GUITexture m_Bean;
	public GUITexture m_Bubble;
	public GUITexture m_Game;
	public GUITexture m_exit;
	public AudioClip m_BG;
	// Use this for initialization
	void Start () {
	AudioSource.PlayClipAtPoint(m_BG,transform.position);
	}
	
	// Update is called once per frame
	void Update () {
			if( Input.GetMouseButtonDown(0) ) {
				if(true == m_Bean.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					Bean();
				}
				if(true == m_Bubble.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					Game();
				}
				if(true == m_Game.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					MainGame();
				}
				if(true == m_exit.HitTest( new Vector2( Input.mousePosition.x, Input.mousePosition.y) ) ) {
					Exit();
				}
			}
	}
	void MainGame()
	{
		Application.LoadLevel("MainGame");
	}

	void Bean()
	{
		Application.LoadLevel("Bean");
	}
	void Game()
	{
		Application.LoadLevel("Game");
	}	
	void Exit()
	{
		 Application.Quit();
	}	
}
