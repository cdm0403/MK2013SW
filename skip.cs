using UnityEngine;
using System.Collections;

public class Skip : MonoBehaviour {
  public float Skip_delay=3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Skip_delay-=Time.deltaTime;
		if(Skip_delay<0)
		{
			Application.LoadLevel("main");
		}
	
	}
}
