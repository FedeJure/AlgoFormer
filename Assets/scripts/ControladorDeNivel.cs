using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ControladorDeNivel : MonoBehaviour {
	public MiNetworkManager netManager;
	// Use this for initialization
	void Start () {
		netManager = GameObject.Find ("NetworkManager").GetComponent<MiNetworkManager> ();
		if (netManager == null)
			return;
		//GameObject.Instantiate (netManager.playerPrefab);



	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
