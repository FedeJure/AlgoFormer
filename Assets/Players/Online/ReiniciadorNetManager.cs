using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciadorNetManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void reiniciar(){
		MiNetworkManager nm =  GameObject.Find ("NetworkManager").GetComponent<MiNetworkManager> ();
		nm.playerPrefab = null;
		nm.onlineScene = null;
	}
}
