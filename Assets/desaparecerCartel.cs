using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparecerCartel : MonoBehaviour {
	GameObject miGameObject;
	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		
	}
	
	// Update is called once per frame
	void Update () {
		miGameObject = this.gameObject;	
		if (miGameObject.activeInHierarchy == true) {
			Invoke ("desaparecerCart", 3);
		}
	}
	protected void desaparecerCart(){
		miGameObject.SetActive (false);
	}
}
