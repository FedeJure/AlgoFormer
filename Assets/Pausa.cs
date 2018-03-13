using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class Pausa : MonoBehaviour {
	public GameObject menuPausa;
	public GameObject filtro;
	// Use this for initialization
	void Start () {
		menuPausa.SetActive (false);
		filtro.SetActive (false);
		Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButtonDown ("Pausa")) {
			if (Time.timeScale == 1f) {
				Time.timeScale = 0f;
				menuPausa.SetActive (true);
				filtro.SetActive (true);

			} else {
				Time.timeScale = 1f;
				menuPausa.SetActive (false);
				filtro.SetActive (false);
			}
		}
	}
}
