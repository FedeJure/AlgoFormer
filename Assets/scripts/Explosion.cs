using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : StateMachineBehaviour {


	private CircleCollider2D olaExplosion;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//olaExplosion = animator.gameObject.GetComponent<CircleCollider2D> ();
		//olaExplosion.enabled = true;

		olaExplosion = animator.gameObject.AddComponent<CircleCollider2D>();
		olaExplosion.radius = 0.3f;
		olaExplosion.isTrigger = true;
	


	}



}
