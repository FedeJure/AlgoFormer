using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorDeAtaquesPlayer : MonoBehaviour {
	public List<string> tagsQueDanian;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		
		//if (col.GetType().ToString() != "CircleCollider2D")
		//	return;

		if (tagsQueDanian.Contains (col.tag) && col.GetComponent<Accion>().enAccion()) {
			
			float danio = col.GetComponent<Accion> ().getDanio ();
			this.SendMessageUpwards ("recibirAtaque", danio);


		}

	}


}
