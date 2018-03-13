using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Networking.NetworkSystem;

public class MiNetworkManager : NetworkManager {
	public GameObject crashPrefab;
	public GameObject sonicPrefab;
	public InputField nombrePartida;
	public InputField nombrePartidaUnirse;
	private NetworkManagerHUD HUD;
	public GameObject jugador;

	private NetworkManager networkManager;


	// Use this for initialization
	void Start () {
		networkManager = NetworkLobbyManager.singleton;
		jugador = GameObject.FindGameObjectWithTag ("Jugador");
		HUD = GetComponent<NetworkManagerHUD> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (networkManager.networkAddress);

	}

	public void entrarConCrash(){
		string idPartida = nombrePartida.text;
		networkManager.networkAddress= (idPartida.Length >0) ? idPartida : "Default";
		Debug.Log (networkManager.networkAddress);
		networkManager.playerPrefab = crashPrefab;

		NetworkClient cliente = networkManager.StartHost();


	}
	public void entrarConSonic(){
		string idPartida = nombrePartida.text;
		networkManager.networkAddress= (idPartida.Length >0) ? idPartida : "Default";
		networkManager.playerPrefab = sonicPrefab;
		NetworkClient host = networkManager.StartHost();
	}
	public void entrarAPartida(){
		networkManager.networkAddress = (nombrePartidaUnirse.text.Length > 0) ? nombrePartidaUnirse.text : "Default";

		NetworkClient cliente = networkManager.StartClient ();
	

	}
	public void showHUD(bool mostrar){
		HUD.showGUI = mostrar;
	}
	public void setCrashPrefab(){
		playerPrefab = crashPrefab;

	}
	public void setSonicPrefab(){
		//playerPrefab = sonicPrefab;
		playerPrefab = this.spawnPrefabs [1];
	}

	public override void OnStartHost(){
		jugador.SetActive (false);


	}

	public override void OnStartClient(NetworkClient cliente){
		jugador.SetActive (false);


	}
	public override void OnStopHost(){
		//jugador.SetActive (true);
	}
	public override void OnStopClient(){
		//jugador.SetActive (true);

	}




}
