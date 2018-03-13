using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float velocidad = 5;
	public float radioDeteccion = 3;
	public string tagBuscada = "Player";
	public float distanciaAcercamiento = 0.2f;

	private Vector3 posicionActual;
	private CircleCollider2D circuloDeDeteccion;
	private Rigidbody2D body;
	private Vector2 velocidadActual;
	private Animator anim;

	private bool persiguiendo = false;
	                                                                   // si hay 2 objetivos en rango los va a poner
	public List<GameObject> objetivosActuales = new List<GameObject>();// en cola de espera y perseguira al primero




	void Start () {
		circuloDeDeteccion = this.gameObject.AddComponent<CircleCollider2D> ();
		body = GetComponent<Rigidbody2D> ();
		velocidadActual = body.velocity;
		circuloDeDeteccion.isTrigger = true;
		circuloDeDeteccion.radius = radioDeteccion;
		anim = this.gameObject.GetComponent<Animator> ();

		posicionActual = this.transform.position;

	}
	

	void Update () {
		this.anim.SetFloat ("horSpeed", Mathf.Abs(this.body.velocity.x));
	
			
	}
	void FixedUpdate(){
		if (objetivosActuales.ToArray().Length >0) {
			perseguir (objetivosActuales [0]);

		}
	}


	void OnTriggerStay2D( Collider2D otro){
		GameObject objetivo = otro.gameObject;
		if (objetivo.CompareTag (tagBuscada)) {
			if (!objetivosActuales.Contains (objetivo)) {
				objetivosActuales.Add (objetivo);
			}
		}
	}
	void OnTriggerExit2D(Collider2D otro){
		GameObject objetivo = otro.gameObject;
		if (objetivo.CompareTag (tagBuscada)) {
			objetivosActuales.Remove (objetivo);
		}
	}

	void perseguir(GameObject objetivo){
		Rigidbody2D bodyObjetivo = objetivo.GetComponent<Rigidbody2D> ();
		Vector2 posicionObjetivo = bodyObjetivo.transform.position;

		velocidadActual.x =  getDireccionX (body.position, posicionObjetivo) * velocidad;
		body.velocity = velocidadActual;

	}
	int getDireccionX(Vector2 origen,Vector2 destino){
		if (Mathf.Abs (destino.x - origen.x) < distanciaAcercamiento) {
			return 0;
		}
		else if (destino.x > origen.x) {
			flipRigth();
			return 1;
		} 
		flipLeft();
		return -1;
	}

	void flipRigth(){
		Vector3 scale = this.transform.localScale;
		scale.x = Mathf.Abs(scale.x);
		this.transform.localScale = scale;
	}
	void flipLeft(){
		Vector3 scale = this.transform.localScale;
		scale.x = -Mathf.Abs(scale.x);
		this.transform.localScale = scale;
	}
}
