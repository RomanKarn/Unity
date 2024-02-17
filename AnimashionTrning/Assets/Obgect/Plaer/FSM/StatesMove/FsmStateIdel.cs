using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmStateIdel : FsmState
{
    private Animator AnimatorPlaer {  get; set; }
    public FsmStateIdel(FSM fsm, Animator animator) : base(fsm)
    {
        AnimatorPlaer = animator;
    }

    public override void Enter()
    {
        AnimatorPlaer.SetTrigger("StartIdel");
    }

}
