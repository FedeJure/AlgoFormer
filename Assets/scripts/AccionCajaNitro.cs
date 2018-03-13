using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionCajaNitro : MonoBehaviour,Accion {
	private float cantidadDanio = 1;


	private Animator anim;
	private bool seAcciono = false;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	}


	public void accion(GameObject objeto){
		//this.GetComponent<CircleCollider2D> ().enabled = true;
		seAcciono = true;
		anim.SetTrigger ("explosion");

	}
	public float getDanio(){
		return cantidadDanio;
	}
	public bool enAccion(){
		return seAcciono;

	}

}
