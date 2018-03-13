using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;


public class AlejadorCamara : MonoBehaviour {
	Slider slider;
	public Camera camara;
	private Camera2DFollow follow;
	private float distanciaNormal;
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		follow = camara.GetComponent<Camera2DFollow> ();
		distanciaNormal = -10;
	}
	
	// Update is called once per frame
	void Update () {
		if (follow.m_OffsetZ != distanciaNormal * slider.value) {
			follow.m_OffsetZ = distanciaNormal * slider.value;

			return;
		}
		;
	}
}
