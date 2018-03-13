using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControladorPantallas : MonoBehaviour {
	public GameObject pantallaInicial;
	public GameObject objetoJugador;
	public static string nombreEscenaSalaDeJuago = "SalaDelJuego";

	private GameObject pantallaActual;
	private Stack<GameObject> pilaPantallas;

	//private Dictionary<string,GameObject> cuentas;
	private static List<string> partidasGuardadas;
	private static string nombrePartidasGuardadas = "partidasGuardadas.bin";
	private int cantidadMaximaPartidasGuardadas = 8;


	private static string ultimaPartidaAccedida;
	private static Jugador ultimoJugadorAccesado;
	private static GameObject ultimoObjetoJugador;
	public static ControladorPantallas instancia;





	void Start(){




		ultimoObjetoJugador = objetoJugador;
		
		foreach (Canvas pantalla in GameObject.FindObjectsOfType<Canvas> ()) {
			pantalla.gameObject.SetActive (false);
		}
		pantallaInicial.SetActive (true);
		pantallaActual = pantallaInicial;

		pilaPantallas = new Stack<GameObject> ();
		//cuentas = new Dictionary<string,GameObject>();


		if (BlazeSave.Exists(nombrePartidasGuardadas))
			partidasGuardadas = BlazeSave.LoadData<List<string>>(nombrePartidasGuardadas);
		else
			partidasGuardadas = new List<string>();
		BlazeSave.CrearCarpeta ();
		instancia = this;

	}
	
	public void cambiarPantalla(GameObject otraPantalla){
		otraPantalla.SetActive(true);
		pantallaActual.gameObject.SetActive (false);
		pilaPantallas.Push (pantallaActual);
		pantallaActual = otraPantalla;


	}

	public void retrocederPantalla(){
		GameObject otro = pilaPantallas.Pop ();
		otro.SetActive (true);
		pantallaActual.gameObject.SetActive (false);
		pantallaActual = otro;
	}
	public void crearCuenta (Text imputField){
		string nombre = imputField.text;
		GameObject jugador;
		if (nombre.Length > 0 && !partidasGuardadas.Contains(nombre) && partidasGuardadas.Count <= cantidadMaximaPartidasGuardadas) {
			jugador = GameObject.Instantiate (objetoJugador);
			Jugador.nombreJugador = nombre;
			  // para q persista el cambio de escena.
			partidasGuardadas.Add(nombre);
			BlazeSave.SaveData (nombrePartidasGuardadas, partidasGuardadas);
			BlazeSave.SaveData (nombre + ".bin", Jugador.vidasIniciales);

			DontDestroyOnLoad (jugador);
			controladorEscena.cargarEscena ("SalaDelJuego");


		}



	}

	public void entrarEnPartida(string nombrePartida){

		if (partidasGuardadas.Contains (nombrePartida)) {

			foreach (GameObject g in GameObject.FindGameObjectsWithTag("Jugador")){
				Destroy (g);
			}

			GameObject objetoJugadorTemp = GameObject.Instantiate (objetoJugador);
			Jugador jugador = objetoJugador.GetComponent<Jugador> ();
			if (jugador.cargarPartida (nombrePartida,jugador) && partidasGuardadas.Contains (nombrePartida)) {
				/*
				DontDestroyOnLoad (objetoJugadorTemp);


				if (!BlazeSave.Exists (nombrePartida + ".bin"))
					return;
				Jugador.atributos = BlazeSave.LoadData<List<string>>(nombrePartida+".bin");
				Debug.Log (Jugador.atributos [0]);*/
				Jugador.nombreJugador =nombrePartida;
				Jugador.vidasActuales = BlazeSave.LoadData <int>(nombrePartida + ".bin");
				DontDestroyOnLoad (objetoJugadorTemp);
				controladorEscena.cargarEscena (nombreEscenaSalaDeJuago);
				return;
			}
			//Destroy (objetoJugador);
		}

	}
	public static void borrarPartida(string nombrePartida){
		if (partidasGuardadas.Contains (nombrePartida)) {
			partidasGuardadas.Remove (nombrePartida);
			BlazeSave.Delete (nombrePartida);
			BlazeSave.SaveData (nombrePartidasGuardadas, partidasGuardadas);
		}

	}
	public static void entrarEnUltimaPartidaAccedida(){
		if (ultimaPartidaAccedida != null) {
			instancia.entrarEnPartida (ultimaPartidaAccedida);
			ultimoJugadorAccesado.restarVida (1);
			}
		}




}
