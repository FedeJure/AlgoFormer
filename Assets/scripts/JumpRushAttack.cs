using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRushAttack : StateMachineBehaviour {



	private CircleCollider2D circulo;


	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}



	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
	override public void OnStateEnter(Animator anim,AnimatorStateInfo stateInfo, int layerIndex){

		anim.GetComponent<BoxCollider2D> ().enabled = false;
		anim.GetComponentInChildren<CircleCollider2D> ().enabled = true;

	


	}

	private void OnStateExit (Animator anim,AnimatorStateInfo stateInfo, int layerIndex){
		anim.GetComponentInChildren<CircleCollider2D> ().enabled = false;
		anim.GetComponent<BoxCollider2D> ().enabled = true;


	}
	override public void OnStateUpdate(Animator anim, AnimatorStateInfo stateInfo, int layerIndex) {
		anim.GetComponent<BoxCollider2D> ().enabled = false;
	}


}
