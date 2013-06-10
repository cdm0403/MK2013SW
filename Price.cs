using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class mainScript : MonoBehaviour {
  
	public GameObject selectedObject;		
	
	
	Vector3[] objectPosition = new Vector3[5];
	public LinkedList<GameObject> BeltItem = new LinkedList<GameObject>();
	
	public bool[] isPossible = new bool[5]{true,true,true,true,true};
	
	string[] nameForNumber = new string[8];
	
	public int totalPrice = 0;
	
	// Use this for initialization
	void Start () {	
		StageData.Instance().StageClearScore[Application.loadedLevel-2] = 0;
		StageData.Instance().StageTimeScore[Application.loadedLevel-2] = 0;
		objectPosition[0] = new Vector3(-400f,-240f,-150f);
		objectPosition[1] = new Vector3(-280f,-240f,-150f);
		objectPosition[2] = new Vector3(-160f,-240f,-150f);
		objectPosition[3] = new Vector3(-40f,-240f,-150f);
		objectPosition[4] = new Vector3(80f,-240f,-150f);
		
		nameForNumber[0] = "Apple";
		nameForNumber[1] = "Banana";
		nameForNumber[2] = "Grape";
		nameForNumber[3] = "Strawberry";
		nameForNumber[4] = "Carrot";
		nameForNumber[5] = "Eggplant";
		nameForNumber[6] = "Cookie";
		nameForNumber[7] = "Watermelon";
		
		MakeQuestion();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Belt_Back").transform.FindChild("Belt").gameObject.GetComponent<BeltScript>().isOn) return;
		if(Input.GetMouseButtonDown(1)){
			
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			Physics.Raycast(ray,out hit);
			
			if(hit.transform != null && hit.transform.gameObject.layer == 8){ // select fixed
				for(int i=0;i<5;i++){
					if(objectPosition[i].x == hit.collider.transform.position.x){
						isPossible[i] = true;
						break;
					}
				}
				BeltItem.Remove(hit.collider.gameObject);
				Destroy(hit.collider.gameObject);
			}
			
		}else if(Input.GetMouseButton(0)&& selectedObject != null){
			Vector3 temp = camera.ScreenPointToRay(Input.mousePosition).GetPoint(10f);
			selectedObject.transform.position = Vector3.Lerp(selectedObject.transform.position,new Vector3(temp.x,temp.y,-16.0f),Time.deltaTime*10f);			
		}else if(Input.GetMouseButtonUp(0)){
			if(selectedObject != null){
				if(selectedObject.GetComponent<ObjectScript>().isSelected){
					if(BeltItem.Count<5){
						BeltItem.AddLast(selectedObject);
						for(int i=0;i<5;i++){
							if(isPossible[i]== true){
								selectedObject.transform.position= objectPosition[i];
								isPossible[i] = false;
								AudioManager.Instance().Play("currectanswer",false);
								break;
							}
						}
					}else{
						Destroy(selectedObject);		
					}
				}else{
					Destroy(selectedObject);	
				}
				selectedObject = null;
			}
		}		
	}
	
	public void MakeQuestion(){
		isPossible[0] = true;
		isPossible[1] = true;
		isPossible[2] = true;
		isPossible[3] = true;
		isPossible[4] = true;
		
		BeltItem.Clear();
		
		GameObject.Find("Apple").GetComponent<ItemScript>().initialize();
		GameObject.Find("Banana").GetComponent<ItemScript>().initialize();
		GameObject.Find("Carrot").GetComponent<ItemScript>().initialize();
		GameObject.Find("Cookie").GetComponent<ItemScript>().initialize();
		GameObject.Find("Eggplant").GetComponent<ItemScript>().initialize();
		GameObject.Find("Grape").GetComponent<ItemScript>().initialize();
		GameObject.Find("Strawberry").GetComponent<ItemScript>().initialize();
		GameObject.Find("Watermelon").GetComponent<ItemScript>().initialize();
		
		if(Application.loadedLevelName.Contains("1")){
			// 구매가능한 물건 랜덤 //
			int[] objectNumber = new int[3];
			int count = 0;
			int objectNum = 3;
			
			while(count<objectNum){
				int index = Random.Range(0,5);
				bool isValid = true;
				for(int i=0;i<count;i++){
					if(objectNumber[i] == index){
						isValid = false;
						break;
					}
				}
				if(isValid){
					objectNumber[count] = index;
					Vector3 pos = GameObject.Find(nameForNumber[index]).transform.position;
					GameObject.Find(nameForNumber[index]).transform.position = new Vector3(pos.x,pos.y,-10f);
					count ++;
				}
			}	
			/////////////////////////////////////
			////// 각각 다른 가격 측정 ////////////
			int[] priceArray = new int[3];
			count = 0;
			while(count < objectNum){
				int index = Random.Range(3,5);
				bool isValid = true;
				for(int i=0;i<count;i++){
					if(priceArray[i] == index*10){
						isValid = false;
						break;
					}
				}
				if(isValid){
					priceArray[count] = index*10;
					GameObject.Find(nameForNumber[objectNumber[count]]).GetComponent<ItemScript>().price = index*10;	
					count++;
				}
			}
			/////////////////////////////////////
			/////////// 총 가격 랜덤 /////////////
			int step1 = Random.Range(0,3);
			int step2 = step1;
			while(step2==step1){
				step2 = Random.Range(0,3);	
			}
			totalPrice = priceArray[step1]+priceArray[step2];
			GameObject.Find("TotalPrice_Back").transform.FindChild("TotalPrice").gameObject.GetComponent<TotalPriceScript>().price = totalPrice;
			/////////////////////////////////////
			
			
			
		}else if(Application.loadedLevelName.Contains("2")){
			// 구매가능한 물건 랜덤 //
			int[] objectNumber = new int[3];
			int count = 0;
			int objectNum = 3;
			
			while(count<objectNum){
				int index = Random.Range(0,8);
				bool isValid = true;
				for(int i=0;i<count;i++){
					if(objectNumber[i] == index){
						isValid = false;
						break;
					}
				}
				if(isValid){
					objectNumber[count] = index;
					Vector3 pos = GameObject.Find(nameForNumber[index]).transform.position;
					GameObject.Find(nameForNumber[index]).transform.position = new Vector3(pos.x,pos.y,-10f);
					count ++;
				}
			}	
			/////////////////////////////////////
			////// 각각 다른 가격 측정 ////////////
			int[] priceArray = new int[3];
			count = 0;
			while(count < objectNum){
				int index = Random.Range(2,6);
				bool isValid = true;
				for(int i=0;i<count;i++){
					if(priceArray[i] == index*50){
						isValid = false;
						break;
					}
				}
				if(isValid){
					priceArray[count] = index*50;
					GameObject.Find(nameForNumber[objectNumber[count]]).GetComponent<ItemScript>().price = index*50;	
					count++;
				}
			}
			/////////////////////////////////////
			/////////// 총 가격 랜덤 /////////////
			int step1 = Random.Range(0,5);
			int step2 = step1;
			while(step2==step1){
				step2 = Random.Range(0,5);	
			}
			totalPrice = priceArray[step1]+priceArray[step2];
			GameObject.Find("TotalPrice_Back").transform.FindChild("TotalPrice").gameObject.GetComponent<TotalPriceScript>().price = totalPrice;
			/////////////////////////////////////
			
			
			
		}else if(Application.loadedLevelName.Contains("3")){
			// 구매가능한 물건 랜덤 //
			int[] objectNumber = new int[4];
			int count = 0;
			int objectNum = 4;
			
			while(count<objectNum){
				int index = Random.Range(0,8);
				bool isValid = true;
				for(int i=0;i<count;i++){
					if(objectNumber[i] == index){
						isValid = false;
						break;
					}
				}
				if(isValid){
					objectNumber[count] = index;
					Vector3 pos = GameObject.Find(nameForNumber[index]).transform.position;
					GameObject.Find(nameForNumber[index]).transform.position = new Vector3(pos.x,pos.y,-10f);
					count ++;
				}
			}	
			/////////////////////////////////////
			////// 각각 다른 가격 측정 ////////////
			int[] priceArray = new int[4];
			count = 0;
			while(count < objectNum){
				int index = Random.Range(10,51);
				bool isValid = true;
				for(int i=0;i<count;i++){
					if(priceArray[i] == index*50){
						isValid = false;
						break;
					}
				}
				if(isValid){
					priceArray[count] = index*50;
					print (count+" : "+priceArray[count]);
					GameObject.Find(nameForNumber[objectNumber[count]]).GetComponent<ItemScript>().price = index*50;	
					count++;
				}
			}
			
	/*		int step1 = Random.Range(0,3);
			int step2 = step1;
			int step3;
			while(step2==step1){
				step2 = Random.Range(0,3);
				step3 = Random.Range(0,3);
			}
			totalPrice = priceArray[step1]+priceArray[step2]+priceArray[step3];
			GameObject.Find("TotalPrice_Back").transform.FindChild("TotalPrice").gameObject.GetComponent<TotalPriceScript>().price = totalPrice; */
			/////////////////////////////////////
			/////////// 총 가격 랜덤 /////////////
			int totalNum = Random.Range(2,4);
			print(totalNum);
			int[] stepArr = new int[totalNum];
			stepArr[0] = Random.Range(0,4);
			print ("step0 : "+stepArr[0]);
			for(int i=1;i<totalNum;){
				bool isValid = true;
				stepArr[i] = Random.Range(0,4);
				for(int j=0;j<i;j++){
					if(stepArr[j] == stepArr[i]){
						isValid =false;
						break;
					}
				}
				if(isValid){
					print ("step"+i+" : "+stepArr[i]);
					i++;
				}
			}
			for(int i=0;i<totalNum;i++) totalPrice += priceArray[stepArr[i]];
			print(totalPrice);
			GameObject.Find("TotalPrice_Back").transform.FindChild("TotalPrice").gameObject.GetComponent<TotalPriceScript>().price = totalPrice;
			/////////////////////////////////////
			
			
			
		}else if(Application.loadedLevelName.Contains("4")){
			// 구매가능한 물건 랜덤 //
			int[] objectNumber = new int[4];
			int count = 0;
			int objectNum = 4;
			
			while(count<objectNum){
				int index = Random.Range(0,8);
				bool isValid = true;
				for(int i=0;i<count;i++){
					if(objectNumber[i] == index){
						isValid = false;
						break;
					}
				}
				if(isValid){
					objectNumber[count] = index;
					Vector3 pos = GameObject.Find(nameForNumber[index]).transform.position;
					GameObject.Find(nameForNumber[index]).transform.position = new Vector3(pos.x,pos.y,-10f);
					count ++;
				}
			}	
			/////////////////////////////////////
			////// 각각 다른 가격 측정 ////////////
			int[] priceArray = new int[4];
			count = 0;
			while(count < objectNum-2){
				int index = Random.Range(1,6);
				bool isValid = true;
				int saleIndex = Random.Range(1,4);
				for(int i=0;i<count;i++){
					if(priceArray[i] == index*100*(10-1*saleIndex)){
						isValid = false;
						break;
					}
				}
				if(isValid){
					priceArray[count] = index*100*(10-1*saleIndex);
					GameObject.Find(nameForNumber[objectNumber[count]]).GetComponent<ItemScript>().isSale = true;
					GameObject.Find(nameForNumber[objectNumber[count]]).GetComponent<ItemScript>().saleIndex = saleIndex-1;
					GameObject.Find(nameForNumber[objectNumber[count]]).GetComponent<ItemScript>().price = index*100*(10-1*saleIndex);	
					count++;
				}
			}
			while(count < objectNum){
				int index = Random.Range(2,11);
				bool isValid = true;
				for(int i=0;i<count;i++){
					if(priceArray[i] == index*500){
						isValid = false;
						break;
					}
				}
				if(isValid){
					priceArray[count] = index*500;
					GameObject.Find(nameForNumber[objectNumber[count]]).GetComponent<ItemScript>().price = index*500;	
					count++;
				}
			}
			/////////////////////////////////////
			/////////// 총 가격 랜덤 /////////////
			int totalNum = Random.Range(2,3);
			int[] stepArr = new int[totalNum];
			stepArr[0] = Random.Range(0,4);
			for(int i=1;i<totalNum;){
				bool isValid = true;
				stepArr[i] = Random.Range(0,4);
				for(int j=0;j<i;j++){
					if(stepArr[j] == stepArr[i]){
						isValid =false;
						break;
					}
				}
				if(isValid){
					i++;
				}
			}
			for(int i=0;i<totalNum;i++) totalPrice += priceArray[stepArr[i]];
			GameObject.Find("TotalPrice_Back").transform.FindChild("TotalPrice").gameObject.GetComponent<TotalPriceScript>().price = totalPrice;
			/////////////////////////////////////
		}else if(Application.loadedLevelName.Contains("5")){
			// 구매가능한 물건 랜덤 //
			int[] objectNumber = new int[4];
			int count = 0;
			int objectNum = 4;
			
			while(count<objectNum){
				int index = Random.Range(0,8);
				bool isValid = true;
				for(int i=0;i<count;i++){
					if(objectNumber[i] == index){
						isValid = false;
						break;
					}
				}
				if(isValid){
					objectNumber[count] = index;
					Vector3 pos = GameObject.Find(nameForNumber[index]).transform.position;
					GameObject.Find(nameForNumber[index]).transform.position = new Vector3(pos.x,pos.y,-10f);
					count ++;
				}
			}	
			/////////////////////////////////////
			////// 각각 다른 가격 측정 ////////////
			int[] priceArray = new int[4];
			count = 0;
			while(count < objectNum-2){
				int index = Random.Range(1,6);
				bool isValid = true;
				int saleIndex = Random.Range(1,4);
				for(int i=0;i<count;i++){
					if(priceArray[i] == index*100*(10-1*saleIndex)){
						isValid = false;
						break;
					}
				}
				if(isValid){
					priceArray[count] = index*100*(10-1*saleIndex);
					print("----------------------------------");
					print (nameForNumber[objectNumber[count]]);
					print("index : "+index);
					print("saleIndex : "+saleIndex);
					print (index*100*(10-1*saleIndex));
					print("----------------------------------");
					GameObject.Find(nameForNumber[objectNumber[count]]).GetComponent<ItemScript>().isSale = true;
					GameObject.Find(nameForNumber[objectNumber[count]]).GetComponent<ItemScript>().saleIndex = saleIndex-1;
					GameObject.Find(nameForNumber[objectNumber[count]]).GetComponent<ItemScript>().price = index*100*(10-1*saleIndex);	
					count++;
				}
			}
			while(count < objectNum){
				int index = Random.Range(2,11);
				bool isValid = true;
				for(int i=0;i<count;i++){
					if(priceArray[i] == index*100){
						isValid = false;
						break;
					}
				}
				if(isValid){
					priceArray[count] = index*100;
					GameObject.Find(nameForNumber[objectNumber[count]]).GetComponent<ItemScript>().price = index*100;
					count++;
				}
			}
			/////////////////////////////////////
			/////////// 총 가격 랜덤 /////////////
			int totalNum = Random.Range(2,4);
			int[] stepArr = new int[totalNum];
			stepArr[0] = Random.Range(0,4);
			for(int i=1;i<totalNum;){
				bool isValid = true;
				stepArr[i] = Random.Range(0,4);
				for(int j=0;j<i;j++){
					if(stepArr[j] == stepArr[i]){
						isValid =false;
						break;
					}
				}
				if(isValid){
					i++;
				}
			}
			for(int i=0;i<totalNum;i++) totalPrice += priceArray[stepArr[i]];
			print(totalPrice);
			GameObject.Find("TotalPrice_Back").transform.FindChild("TotalPrice").gameObject.GetComponent<TotalPriceScript>().price = totalPrice;
			/////////////////////////////////////
			
			
			
		}
	}
	
}
