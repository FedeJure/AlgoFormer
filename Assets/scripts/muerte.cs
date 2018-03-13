using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muerte : StateMachineBehaviour {


	void  OnStateEnter(Animator animator, AnimatorStateInfo info,int layerIndex){

		animator.gameObject.SendMessage ("impulsoDeMuerte");
		ControladorPantallas.instancia.entrarEnPartida(ControladorPantallas.nombreEscenaSalaDeJuago);

	}
	void  OnStateExit(Animator animator, AnimatorStateInfo info,int layerIndex){
		GameObject objetoJugador = GameObject.FindGameObjectWithTag ("Jugador");
		Jugador.modificarVida (-1);
		if (Jugador.vidasActuales <= 0) {
			ControladorPantallas.borrarPartida (Jugador.nombreJugador);
			controladorEscena.irAlMenu ();
			return;
		
		}
		controladorEscena.cargarEscena ("SalaDelJuego",objetoJugador);

	}
}
