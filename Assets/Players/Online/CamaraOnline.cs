using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CamaraOnline : MonoBehaviour {
	public NetworkIdentity netId;
	// Use this for initialization
	void Start () {
		if (!netId.isLocalPlayer) {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
