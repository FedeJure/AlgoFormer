using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class playerOnline : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		if (!isLocalPlayer) {
			Destroy (this.GetComponent<PlayerMotor> ());
			Destroy (this.GetComponent<SistemaDePeleaCrash> ());
			Destroy (this.GetComponent<SistemaDePeleaSonic> ());
			Destroy (this.GetComponent<RecolectorDeObjetos> ());
			return;
		}
		//GetComponent<ReiniciadorNetManager> ().reiniciar ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
