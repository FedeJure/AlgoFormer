using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionCajaConObjetos : MonoBehaviour,Accion {
	Animator anim;

	private int cantidadDeFrutas;
	public int cantidadMinima = 5;
	public int cantidadMaxima = 10;

	private bool seAcciono = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		cantidadDeFrutas = Random.Range (cantidadMinima, cantidadMaxima);
	}

	// Update is called once per frame
	void Update () {

	}

	public void accion(GameObject objeto){
		seAcciono = true;
		//objeto.GetComponentInParent<RecolectorDeObjetos> ().recolectar (cantidadDeFrutas);
		objeto.SendMessageUpwards ("recolectar", cantidadDeFrutas,SendMessageOptions.DontRequireReceiver);
		objeto.SendMessage ("recolectar", cantidadDeFrutas,SendMessageOptions.DontRequireReceiver);
		anim.SetTrigger ("accion");

	}
	public float getDanio(){
		return  0;
	}
	public bool enAccion(){
		return seAcciono;

	}
}
