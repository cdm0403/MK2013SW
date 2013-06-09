using UnityEngine;
using System.Collections;

public class Bean : MonoBehaviour {

  public GameObject m_Bean;
	public bool Moving;
	public Transform T_Bean;
	float r;

	void Start () {
		Moving = false;
		r = Random.Range(0,360);
		T_Bean.Rotate(r,0,0);
		Debug.Log(""+r);
		//rigidbody.AddForce(transform.right * 10f);
	}
	void Update () {			
		//AddForce(transform.right * 5f);
		//rigidbody.AddForce(transform.forward *10000f);
		rigidbody.AddForce(transform.forward *100f);
	}
}
