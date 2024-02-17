using MovePlaer;
using UnityEngine;

public class Plaer
{
    private FSM _fsm;
    private IMovePlaer Move{ get; set; }
    private GameObject ModelPlaer { get; set; }
    private Animator AnimatorPlaer { get; set; }
    public Plaer(Rigidbody plaer,Animator animator,GameObject model)
    {
        Move = new MoveStandart(plaer);
        ModelPlaer = model;
        AnimatorPlaer = animator;
        _fsm = new FSM();
        _fsm.AddState(new FsmStateIdel(_fsm,animator));
        _fsm.AddState(new FsmStateWalkLeft(_fsm,animator,model, Move));
        _fsm.AddState(new FsmStateWalkRight(_fsm, animator, model, Move));
        _fsm.SetState<FsmStateIdel>();
    }

    public void MoveLeftPlaer()
    {
        _fsm.SetState<FsmStateWalkLeft>();
    }
    public void MoveRightPlaer()
    {
        _fsm.SetState<FsmStateWalkRight>();
    }
    public void MoveStopPlaer()
    {
        _fsm.SetState<FsmStateIdel>();
    }
    public void Update()
    {
        _fsm.Update();
    }
}
