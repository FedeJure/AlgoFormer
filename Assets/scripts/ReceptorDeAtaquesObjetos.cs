using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorDeAtaquesObjetos : MonoBehaviour {
	/* tiene que tener en Components, un script de Accion al destruir*/

	public List<string> tagEsperada = new List<string>();




	// Use this for initialization

	void OnTriggerEnter2D(Collider2D col){

		//if (col.GetType().ToString() != "CircleCollider2D")
		//	return;

		if (tagEsperada.Contains(col.tag)) {

			col.SendMessageUpwards ("efectuoAtaque",SendMessageOptions.DontRequireReceiver);
			gameObject.GetComponent<Accion> ().accion (col.gameObject);
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
			gameObject.GetComponentInParent<Accion>().accion(col.gameObject);
			gameObject.GetComponentInParent<BoxCollider2D> ().isTrigger = true;


		}

		
		
	}


}
