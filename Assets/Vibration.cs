using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vibration : MonoBehaviour {
	UnityEngine.UI.Button boton;
	// Use this for initialization
	void Start () {
		boton = GetComponent<UnityEngine.UI.Button> ();
		if (boton == null)
			return;
		boton.onClick.AddListener (vibrar);
	}
	
	public void vibrar(){
		VibrationService.Vibrate (50);
	}
}
