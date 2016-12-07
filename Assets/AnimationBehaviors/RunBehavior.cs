using UnityEngine;
using System.Collections;

public class RunBehavior : StateMachineBehaviour {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

		animator.GetComponent<Player_New> ().Run = true;

		animator.SetFloat ("speed", 0);
        Player_New.Instance.isRunning = true;
		if (animator.tag == "Player") 
		{
			Player_New.Instance.MyRigidbody.velocity = Vector2.zero;
		}

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		if (Input.GetKeyUp (KeyCode.LeftShift))
		{
			animator.GetComponent<Player_New> ().Run = false;
			animator.SetTrigger ("stopRunning");
			animator.ResetTrigger ("run");
            Player_New.Instance.isRunning = false;
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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
}