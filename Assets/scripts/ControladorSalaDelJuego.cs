using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSalaDelJuego : MonoBehaviour {

	public GameObject jugador;


	// Use this for initialization
	void Start () {
		jugador = GameObject.FindWithTag ("Jugador");
		controladorEscena.cargarEscena ("Nivel0");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
