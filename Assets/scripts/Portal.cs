using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class Portal : MonoBehaviour {
	public MiNetworkManager networkManager;
	public GameObject networkHUD;
	public string nombreNivelAEntrar;
	public string nombreEscenaActual="SalaDelJuego";
	public NetworkManagerHUD HUD;


	// Use this for initialization
	void Start () {
		if (networkManager == null)
			networkManager = GameObject.Find ("NetworkManager").GetComponent<MiNetworkManager> ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if ((col.name == "Crash" || col.name == "Sonic")  && networkManager != null) {
			networkManager.onlineScene = nombreNivelAEntrar;
			networkHUD.SetActive (true);
			if (col.name == "Crash")
				networkManager.setCrashPrefab ();
			else
				networkManager.setSonicPrefab ();

		}
	}
	void OnTriggerExit2D(Collider2D col){
		if ((col.name == "Crash" || col.name == "Sonic") && networkManager != null) {
			networkManager.onlineScene = null;
			networkHUD.SetActive (false);
			HUD.showGUI = false;
			networkManager.playerPrefab = null;
		}
	}
}
