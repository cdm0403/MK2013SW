using UnityEngine;
using System.Collections;

public class Bean_Cover : MonoBehaviour {
  public GameObject m_Bean;
	private float RandomX;
	// Use this for initialization
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;		
			
			if (Physics.Raycast(ray, out hit)) {
				if(hit.transform.tag == "Bean_Cover") {
					RandomX = Random.Range(0,90);
					Instantiate(m_Bean, hit.point, m_Bean.transform.rotation);

					
					/*
					Instantiate(m_Bean, hit.point, m_Bean.transform.rotation);
					hit.transform.collider.enabled = false;
					hit.transform.GetComponent<Bean>().Moving=true;
					//Rigidbody body=go.GetComponent<Rigidbody>();
					//body.AddForce( transform.right * 5f);
					*/
				} 
				
			if(GameObject.Find("Bean(Clone)")) // gameobject가 "bullet3(Clone)" 일때.
			{
				if(transform.position.x > 28)
				{
					transform.localPosition= new Vector3(-2f,0.01f,0);
				}
			}	
				
		}}
	}}
	
