using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borrar : StateMachineBehaviour {
	

	public bool destruir = false;
	void  OnStateExit(Animator animator, AnimatorStateInfo info,int layerIndex){

		if (destruir)
			Destroy(animator.gameObject);
		
		
		else
			animator.gameObject.SetActive (false);


	}

}
