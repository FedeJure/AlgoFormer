using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour {
	public Transform player1;
	public Transform player2;
	public Canvas interfaz;


	private Transform actualPlayer;


	private bool switchInput;
	// Use this for initialization
	void Start () {
		actualPlayer = player1;
		player2.gameObject.SetActive (false);

		this.SendMessage ("switchTarget", actualPlayer);
	}
	
	// Update is called once per frame
	void Update () {
		switchInput = Input.GetKeyDown (KeyCode.Tab);
		if (switchInput) {
			if (actualPlayer == player1) {
				player2.gameObject.SetActive (true);
				player1.gameObject.SetActive (false);

				player2.position = player1.position;
				actualPlayer = player2;


			} else {
				player2.gameObject.SetActive (false);
				player1.gameObject.SetActive (true);

				player1.position = player2.position;
				actualPlayer = player1;
			}
			SendMessage ("switchTarget", actualPlayer);
			interfaz.SendMessage ("switchPlayer");
		}


	}
}
