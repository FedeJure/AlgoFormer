using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantallaCargarPartida : MonoBehaviour {

	public Button[] slots;

	private List<string> partidasGuardadas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void actualizarPartidasGuardadas(){
		if (BlazeSave.Exists ("partidasGuardadas.bin")) {

			partidasGuardadas = BlazeSave.LoadData<List<string>> ("partidasGuardadas.bin");
		
			for (int i = 0; i < 8; i++) {
				slots [i].GetComponent<SaveSlot> ().desocupar ();

			}

			for (int i = 0; i <partidasGuardadas.Count; i++) {
				slots [i].GetComponent<SaveSlot> ().ocupar (partidasGuardadas [i]);

			}
		

		}
	}
}
