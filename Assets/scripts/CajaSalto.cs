using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaSalto : MonoBehaviour {
	public string tagEsperada = "Player";
	public float impulso = 20;

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponentInParent <Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag == tagEsperada) {
			col.gameObject.GetComponent<PlayerMotor> ().impulsoEnY (impulso);
			anim.SetTrigger ("salto");
		}

	}*/
	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == tagEsperada) {
			col.gameObject.GetComponent<PlayerMotor> ().impulsoEnY (impulso);
			anim.SetTrigger ("salto");
			col.gameObject.SendMessage ("enSalto", SendMessageOptions.DontRequireReceiver);

		}
	}

}
