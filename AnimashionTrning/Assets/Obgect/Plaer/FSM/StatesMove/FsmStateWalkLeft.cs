using MovePlaer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmStateWalkLeft : FsmState
{
    private IMovePlaer Move { get; set; }
    private Animator AnimatorPlaer { get; set; }
    private GameObject ModelPlaer { get; set; }

    public FsmStateWalkLeft(FSM fsm, Animator animator,GameObject model, IMovePlaer move) : base(fsm)
    {
        Move = move;
        AnimatorPlaer = animator;
        ModelPlaer = model;
    }

    public override void Enter()
    {
        AnimatorPlaer.SetTrigger("StartWalk");
        ModelPlaer.transform.rotation = new Quaternion(0,-90f,0,0);
    }
    public override void Update()
    {
        Move.MoveLeft();
    }
}
