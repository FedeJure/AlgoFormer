using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AbrirNetworkManager : MonoBehaviour {
	public GameObject networkManager;

	// Use this for initialization
	void Start () {
		networkManager = GameObject.Find ("NetworkManager");
	}
	
	// Update is called once per frame
	void Update () {
		networkManager = GameObject.Find ("NetworkManager");
		if (gameObject.activeInHierarchy && !networkManager.activeInHierarchy) {
			networkManager.GetComponent<NetworkManager> ();
		}
	}
}
