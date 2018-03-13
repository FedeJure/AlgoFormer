using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciarPartida : StateMachineBehaviour {


	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		ControladorPantallas.entrarEnUltimaPartidaAccedida ();

	}


}
