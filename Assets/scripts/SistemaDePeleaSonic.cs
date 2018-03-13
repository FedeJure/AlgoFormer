using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;
public class SistemaDePeleaSonic : MonoBehaviour {

	public float vida = 100;


	private int cargaRush = 0;
	private int cargaRushMax = 5;
	private bool puedeAumentarCarga = true;

	private bool onRush;
	private bool rushInput;
	private Animator anim;
	private PlayerMotor motor;

	private Vector2 ultimaVelocidadNoNula;


	void Start () {
		anim = this.GetComponent<Animator> ();
		motor = this.GetComponent<PlayerMotor> ();
		onRush = false;
		rushInput = false;

	}
	
	// Update is called once per frame
	void Update () {
		guardarVelocidadNoNula ();
		chequearCargaRush ();


		
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

	private void chequearCargaRush(){
		if (motor.duckingInputDown () && motor.isGrounded () && motor.estaQuieto()) {
			if (motor.jumpInputDown () && cargaRush<6 && puedeAumentarCarga) {
				cargaRush += 1;
				puedeAumentarCarga = false;
				anim.SetBool ("cargandoRush", true);
				anim.SetFloat ("cargaRush", cargaRush);

			}

		}
		if (!motor.estaQuieto ()) {
			cargaRush = 0;
			anim.SetBool ("cargandoRush", false);
		}
		if (!motor.jumpInputDown ()) {
			puedeAumentarCarga = true;
		}
		if (!motor.duckingInputDown () && motor.isGrounded () && cargaRush > 0) {
			motor.impulsoEnX (cargaRush * motor.getWalkSpeed ());
			anim.SetBool ("cargandoRush", false);
			cargaRush = 0;

		}
	}

	public void efectuoAtaque(){ //se pone cualquier cosa q le suceda al personaje al efectuar un ataque
		this.gameObject.GetComponent<Rigidbody2D>().velocity = ultimaVelocidadNoNula;
		Debug.Log (this.ultimaVelocidadNoNula);
	}
	private void guardarVelocidadNoNula (){
		Vector2 vel = this.gameObject.GetComponent<Rigidbody2D> ().velocity;
		if (vel != Vector2.zero) {
			ultimaVelocidadNoNula = vel;
		}
	}
}
