using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonNuevaPartida : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void cargarEscena(int index){


	}
	public void onClick(){
		Debug.Log ("sdfsdfsdfsd");
		SceneManager.LoadScene (1,LoadSceneMode.Additive);
	}
}
