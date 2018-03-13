using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Jugador : MonoBehaviour {

	public static int vidasIniciales = 5;
	public static int vidasActuales = 5;
	public static string nombreJugador = "";
	// Use this for initialization
	void Awake(){




	}
	void Start () {

			
	}

	
	// Update is called once per frame
	void Update () {
		
	}
	public void setNombre(string otroNombre){

		guardarProgreso ();

	}
	public int getVidas(){
		return vidasActuales;
	}
	public static void modificarVida(int cantidad){
		vidasActuales += cantidad;
		guardarProgreso ();

	}
	public void restarVida(int cantidad){
		vidasActuales -= cantidad;
		guardarProgreso ();
	}
	public static void guardarProgreso(){
		
		//BlazeSave.SaveData(atributos[(int)Atributos.Nombre].ToString()+".bin",atributos);
		BlazeSave.Delete(nombreJugador+".bin");
		BlazeSave.SaveData(nombreJugador+".bin",vidasActuales);



	}


	public bool cargarPartida(string nombrePartida,Jugador jugador){
		if (!BlazeSave.Exists (nombrePartida + ".bin"))
			return false;

		return true;
	


	}
	public string getNombre(){
		return nombreJugador;
	}
}
