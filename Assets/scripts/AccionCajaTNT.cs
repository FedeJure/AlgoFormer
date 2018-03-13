using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionCajaTNT : MonoBehaviour , Accion {
	private Animator anim;
	private float danio = 1;
	private string tagEsperada = "Player";
	private bool seAcciono = false;
	private float impulso = 10;
	void Start () {
		anim = GetComponent<Animator> ();

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
		return this.danio;
	}

	public bool enAccion(){
		return seAcciono;

	}
	void OnTriggerEnter2D(Collider2D col){

		if (col.tag == tagEsperada) {
			PlayerMotor pMotor = col.GetComponent<PlayerMotor> ();
			if (pMotor.estaCayendo () && !seAcciono) {
				seAcciono = true;
				pMotor.impulsoEnY (impulso);
				anim.SetTrigger ("activacion");
				Invoke ("explotar", 3);

			}
		}
	}

	public void explotar(){
		GameObject noSirveDeNada = new GameObject();
		accion (noSirveDeNada);
	}


}
