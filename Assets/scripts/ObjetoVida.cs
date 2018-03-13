using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoVida : MonoBehaviour {
	public string tagBuscada = "Player";
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == tagBuscada) {
			Jugador.modificarVida (1);
			Destroy (gameObject);
		}
	}
}
