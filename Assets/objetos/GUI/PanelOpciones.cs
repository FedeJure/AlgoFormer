using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpciones : MonoBehaviour {
	private string partidaAEntrar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void activarPanelOpciones(){
		this.gameObject.SetActive (true);
	}
	public void desactivarPanelOpciones(){
		this.gameObject.SetActive (false);

	}
	public void entrar(){
		if (partidaAEntrar != null)
			GameObject.Find ("Main Camera").GetComponent<ControladorPantallas> ().entrarEnPartida (partidaAEntrar);
	}
	public void setPartidaAEntrar(string nombre){
		partidaAEntrar = nombre;
	}
	public void borrar(){
		ControladorPantallas.borrarPartida (partidaAEntrar);
	}
}
