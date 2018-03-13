using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorCaja : MonoBehaviour {
	public string tagEsperada = "Player";
	public float impulsoAlDestruir = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){

		if (col.tag == tagEsperada) {
			PlayerMotor pMotor = col.GetComponent<PlayerMotor> ();
			if (pMotor.estaCayendo ()) {
				pMotor.impulsoEnY (impulsoAlDestruir);
				GetComponentInParent<Accion> ().accion (col.gameObject);
				Destroy (this.gameObject);
			}
		}
	}
}
