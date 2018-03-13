using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasControl : MonoBehaviour {

	public Text cantidadObjeto;
	public Image objetoAMostrar;
	public Text cantidadVida;



	public Sprite objetoPlayer1;
	public RecolectorDeObjetos recolectorPlayer1;
	public Sprite objetoPlayer2;
	public RecolectorDeObjetos recolectorPlayer2;



	public RecolectorDeObjetos recolectorPlayerActual;

	// Use this for initialization
	void Start () {

		recolectorPlayerActual = recolectorPlayer1;
		cantidadObjeto.text = recolectorPlayer1.getRecolecciones ().ToString ();
		objetoAMostrar.sprite = objetoPlayer1;
	}
	
	// Update is called once per frame
	void Update () {
		cantidadObjeto.text = recolectorPlayerActual.getRecolecciones ().ToString ();
		cantidadVida.text = GameObject.FindGameObjectWithTag ("Jugador").GetComponent<Jugador> ().getVidas ().ToString();
	}
		

	public void switchPlayer(){
		if (objetoAMostrar.sprite == objetoPlayer1) {
			objetoAMostrar.sprite = objetoPlayer2;
			recolectorPlayerActual = recolectorPlayer2;
			cantidadObjeto.text = recolectorPlayer2.getRecolecciones ().ToString ();

		} else {
			
			objetoAMostrar.sprite= objetoPlayer1;
			recolectorPlayerActual = recolectorPlayer1;
			cantidadObjeto.text = recolectorPlayer1.getRecolecciones ().ToString ();
		}
	}


}
