using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class SistemaDePeleaCrash : MonoBehaviour {

	public float vida = 100;


	private bool rushInput;

	private GameObject ataque;


	private Animator anim;
	private PlayerMotor motor;




	void Start () {
		anim = this.GetComponent<Animator> ();
		motor = this.GetComponent<PlayerMotor> ();
		ataque = GameObject.Find ("AtaqueCrash");

	}

	// Update is called once per frame
	void Update () {
		rushInput = Input.GetKeyDown (KeyCode.C) || CrossPlatformInputManager.GetButtonDown("Cuadrado");
	
		chequearAtaque ();



	}
	private void chequearAtaque(){
		if (rushInput) {
			anim.SetTrigger ("rush"); //el collider que aparece en el ataque se maneja en un script puesto en la animacion asi dura lo mismo que ella. 
		}
	}
	public void recibirAtaque(float ataque){
		vida -= ataque;
		if (vida <= 0) { morir ();}
	}
	private void morir(){
		this.anim.SetTrigger ("morir");



	}
	public void impulsoDeMuerte(){
		Vector2 impulsoMuerte = new Vector2 (0, 10); 
		this.GetComponent<Rigidbody2D> ().velocity = impulsoMuerte;
		this.GetComponent<CapsuleCollider2D> ().enabled = false;
		this.GetComponent<BoxCollider2D> ().enabled = false;

	}




}
