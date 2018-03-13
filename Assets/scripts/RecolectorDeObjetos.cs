using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectorDeObjetos : MonoBehaviour {


	public canvasControl miCanvas;
	public string nombreRecoleccionBuscada;

	private int cantidadRecolecciones;

	// Use this for initialization
	void Start () {
		cantidadRecolecciones = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D col){
		if (col.name.Contains(nombreRecoleccionBuscada)) {
			recolectar (1);
			Destroy (col.gameObject);
		}
	}
	public void recolectar(int cantidad){
		cantidadRecolecciones += cantidad;
		//miCanvas.agregarObjeto (cantidad);
	}
	public int getRecolecciones(){
		return cantidadRecolecciones;
	}

}
