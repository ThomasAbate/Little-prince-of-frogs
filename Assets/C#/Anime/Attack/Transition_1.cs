using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_1 : StateMachineBehaviour
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerAttack.instance.isAttacking)
        {
            PlayerAttack.instance.Animation.Play("Attack_2");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerAttack.instance.isAttacking = false;
    }

}
