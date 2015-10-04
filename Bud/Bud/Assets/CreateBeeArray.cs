using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateBeeArray : MonoBehaviour {

	public GameObject hexRef;
	public int scal = 10;
	public float basicHexY = 2;
	public float basicHexX = Mathf.Sqrt(3);
	public float hexY = 1;
	public float hexX = 1;
	public int createSize = 7;
	public List<GameObject> hexGoArray = new List<GameObject>();

	public int xindex;
	public int yindex;


	// Use this for initialization
	void Start () {
		scal = Mathf.Max (10, scal);
		hexX = (float)(int)(basicHexX * scal);
		hexY = basicHexY * scal;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			CreateArray();
		}

		if (Input.GetKeyDown (KeyCode.F2)) {
			foreach(GameObject go in hexGoArray){
				Destroy(go);
			}
		}

		if (Input.GetKeyDown (KeyCode.F4)) {
			string name = "";
			float newX = xindex*hexX;
			float newY = yindex*(-1*hexY);
			if((xindex+1)%2==0){
				newY = newY + hexY/2;
			}
			Vector3 newPos = new Vector3(newX, newY, 0);
			if(GameObject.Find(newPos.ToString())){
				Debug.Log("find by name " + newPos.ToString()+", xindex("+xindex+"), yindex("+yindex+")");
				GameObject.Find(newPos.ToString()).SetActive(!GameObject.Find(newPos.ToString()).activeSelf);
			}else{
				Debug.LogWarning("Not find by name " + newPos.ToString()+", xindex("+xindex+"), yindex("+yindex+")");
			}

		}
	}

	void CreateArray(){
		GameObject orgObj = hexRef;
		hexX = (float)(int)(basicHexX * scal);
		hexY = basicHexY * scal;
		if (hexRef != null) {
		} else {
			orgObj = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			orgObj.transform.localScale = new Vector3(2,2,2);
		}
		for(int i = 0; i<createSize;i++){
			for(int j =0; j<createSize;j++){
				float newX = i*hexX;
				float newY = j*(-1*hexY);
				if((i+1)%2==0){
					newY = newY + hexY/2;
				}
				
				GameObject newGo = GameObject.Instantiate(orgObj, new Vector3(newX, newY, 0), Quaternion.identity) as GameObject;
				newGo.name = newGo.transform.position.ToString();
				newGo.transform.localScale = newGo.transform.localScale*scal;
				hexGoArray.Add(newGo);
			}
		}
	}
}
