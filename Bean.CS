using UnityEngine;
using System.Collections;


public class Bean : MonoBehaviour {


  //public GameObject m_Bean;
	public Transform T_Bean;
	public Transform T_Bean1;
	public Transform T_Bean2;
	float R1;
	float R2;
	
	
	void Start () {
		R1 = Random.Range(0,360);
		R2 = Random.Range(0,1);
		/*
		if(R2==0){
			T_Bean1.Rotate(0,0,R1);
		}
		if(R2==1){
			T_Bean2.Rotate(0,0,R1);
		}
		*/
		T_Bean.Rotate(0,R1,0);
		Debug.Log(""+R1);
		rigidbody.AddForce(transform.forward *300f);
		
		//rigidbody.AddForce(transform.right * 10f);
	}
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;		
			if (Physics.Raycast(ray, out hit)) {
				if(hit.transform.tag == "G_Bean") {
					Destroy(gameObject);
					Bean_Cover.Score-=50;
				}
				if(hit.transform.tag == "B_Bean") {
					Destroy(gameObject);
					Bean_Cover.Score+=100;
				}
			}
		}
	}
}

