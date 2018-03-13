using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour {
	public GameObject panel;
	private string partidaGuardada;

	private bool estaVacio = true;
	private Button boton;
	private string defaultText = "Vacio";

	// Use this for initialization
	void Awake () {
		boton = GetComponent<Button> ();
		boton.enabled = false;

	}

	
	public bool ocupar(string partida){
		if (!estaVacio)
			return false;
		partidaGuardada = partida;
		boton.enabled = true;
		GetComponentInChildren<Text> ().text = partida;
		boton.GetComponent<Button> ().onClick.AddListener (accionAlClickear);
		estaVacio = false;
		return true;

	}
	public void desocupar(){
		if (!estaVacio) {
			GetComponentInChildren<Text> ().text = defaultText;
			boton.enabled = false;
			estaVacio = true;
			partidaGuardada = null;
		}
	}
	private void accionAlClickear(){
		
	
		panel.GetComponent<PanelOpciones> ().setPartidaAEntrar (partidaGuardada);
		panel.transform.position = this.gameObject.transform.position;
		panel.SetActive (true);



	}

}
