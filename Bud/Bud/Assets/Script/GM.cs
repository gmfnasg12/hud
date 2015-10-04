using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {
	private Vector3 nowIndexValue = new Vector3(0f,0f,0f);
	private Vector3 maxIndexValue = new Vector3(0f,0f,0f);
	private Vector3 minIndexValue = new Vector3(0f,0f,0f);
	//private List<GameObject> hexagonalGameobjectManager = new List<GameObject> ();
	private Dictionary<Vector3, GameObject> hexagonalGameobjectManager = new Dictionary<Vector3, GameObject>();
	private float updateTime = 0f; 

	public GameObject hexagonalRefPrefab;
	public float updateTimeInterval = 10f;
	public int createLimit = 10;

	// Use this for initialization
	void Start () {
		if (hexagonalRefPrefab == null) {
			Debug.LogError("[GM.cs] hexagonalRefPrefab is null please set");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > updateTime) {
			updateTime = Time.time;
			createBaseHexagonal();
		}
	}

	private void createBaseHexagonal(){
		//create x way
		for (int xWay=(int)nowIndexValue.x-createLimit; xWay < (int)nowIndexValue.x+1+createLimit; xWay++) {
			Vector3 newPos = new Vector3((float)xWay, nowIndexValue.y, nowIndexValue.z); 
			if(!hexagonalGameobjectManager.ContainsKey(newPos)){
				Debug.Log("[GM.cs] [createBaseHexagonal] Create hexagonal by pos("+newPos+")");
			}else{
				Debug.Log("<color=yellow>[GM.cs] [createBaseHexagonal] Already have hexagonal by pos("+newPos+")</color>");
			}
		}

	}

}
