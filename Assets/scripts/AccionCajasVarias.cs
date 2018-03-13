using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionCajasVarias : MonoBehaviour,Accion{


	private Animator anim;
	private bool seAcciono = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void accion(GameObject objeto){
		seAcciono = true;
		anim.SetTrigger ("accion");
	}
	public float getDanio(){
		return 0;
	}
	public bool enAccion(){
		return seAcciono;

	}
}
