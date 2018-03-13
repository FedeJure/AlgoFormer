using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilidades : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
public class EstrategiaMovimiento{
	
	private float velocidad;
	private AnimationClip animacion;
	public EstrategiaMovimiento(float velocidad, AnimationClip animacion){
		this.velocidad = velocidad;
		this.animacion = animacion;
	}
	public float getVelocidad (){
		return this.velocidad;
	}

	public AnimationClip getAnimacion(){
		return this.animacion;
	}
}

public class EstrategiaMovimientoParado : EstrategiaMovimiento{
	public EstrategiaMovimientoParado(float velocidad,AnimationClip animacion):base(velocidad, animacion){
	}
}


