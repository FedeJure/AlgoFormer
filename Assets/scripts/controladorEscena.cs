using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class controladorEscena : MonoBehaviour {

	public Scene menuPrincipal;
	public Scene nivel1;

	// Use this for initialization
	void Start(){

	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public static void cargarEscena(string nombreEscena, GameObject objetoPersistente = null){
		if (objetoPersistente != null) {
			DontDestroyOnLoad (objetoPersistente);
		}
		SceneManager.LoadScene (nombreEscena);

	}
	public void salirDelJuego(){
		Application.Quit ();
	}
	public static void irAlMenu(){
		GameObject.Destroy (GameObject.FindGameObjectWithTag ("Jugador"));
		cargarEscena ("MenuInicio");
	}
	public void irAlMenu_(){
		GameObject.Destroy (GameObject.FindGameObjectWithTag ("Jugador"));
		cargarEscena ("MenuInicio");
	}



}
