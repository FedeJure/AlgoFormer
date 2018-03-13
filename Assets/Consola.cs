using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Consola : MonoBehaviour {
	private Text texto;
	// Use this for initialization
	void Awake(){
		GameObject.Find ("Consola").SetActive (true);
	}
	void Start () {
		texto = this.GetComponent<Text>();
		GameObject.Find ("Consola").SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("Consola").SetActive (true);
		texto.text += "/n"+System.Console.ReadLine ();
		texto.text += "/n....";
	}
}
