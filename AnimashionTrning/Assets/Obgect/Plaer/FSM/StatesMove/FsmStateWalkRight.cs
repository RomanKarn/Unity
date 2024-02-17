using MovePlaer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmStateWalkRight : FsmState
{
    private IMovePlaer Move { get; set; }
    private Animator AnimatorPlaer { get; set; }
    private GameObject ModelPlaer { get; set; }

    public FsmStateWalkRight(FSM fsm, Animator animator, GameObject model, IMovePlaer move) : base(fsm)
    {
        Move = move;
        AnimatorPlaer = animator;
        ModelPlaer = model;
        
    }

    public override void Enter()
    {
        AnimatorPlaer.SetTrigger("StartWalk");
       
    }
    public override void Update()
    {
        Move.MoveRight();
    }
}
