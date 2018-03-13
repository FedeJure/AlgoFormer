using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class AlActivar : MonoBehaviour {
	public GameObject crear;
	public GameObject MenuJugar;
	public GameObject crearOUnirse;
	public GameObject unirse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnEnable(){
		crear.SetActive (false);
		MenuJugar.SetActive (true);
		crearOUnirse.SetActive (false);
		unirse.SetActive (false);

	}
}
