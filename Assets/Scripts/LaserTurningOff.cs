using UnityEngine;
using System.Collections;

public class LaserTurningOff : StateMachineBehaviour {
    private Collider2D _laserCollider;
    private SpriteRenderer _laserSprite;
 
    private Collider2D getLaserCollider (Animator animator)
    {
        if (_laserCollider == null)
            _laserCollider = animator.gameObject.GetComponent<Collider2D>();

        return _laserCollider;
    }

    private SpriteRenderer getLaserSprite (Animator animator)
    {
        if (_laserSprite == null)
            _laserSprite = animator.gameObject.GetComponent<SpriteRenderer>();

        return _laserSprite;
    }
    
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        getLaserCollider(animator).enabled = false;
        Color col = getLaserSprite(animator).color;
        getLaserSprite(animator).color = new Color(col.r, col.g, col.b, 0);
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        getLaserCollider(animator).enabled = true;
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
