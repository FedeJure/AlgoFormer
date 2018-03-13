using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionLimiteCaida : MonoBehaviour,Accion {
	private float danio = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void accion(GameObject obj){
		
	}
	public float getDanio(){
		return danio;
	}
	public bool enAccion(){
		return true;
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Player")
			col.gameObject.SendMessage ("morir");
	}

}
