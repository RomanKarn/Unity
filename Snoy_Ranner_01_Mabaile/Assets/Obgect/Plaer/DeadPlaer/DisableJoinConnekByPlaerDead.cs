using UnityEngine;
using State;
using UnityEngine.UIElements;

public class DisableJoinConnekByPlaerDead : MonoBehaviour
{
    [SerializeField] private StateMashin stateMashin;
    private FixedJoint plaerJoinOnSnoubord;
    void Start()
    {
        stateMashin.svitchStateDaed += Dead;
        if(this.GetComponent<FixedJoint>())
            this.plaerJoinOnSnoubord = this.GetComponent<FixedJoint>();
    }

    private void Dead()
    {
        if (plaerJoinOnSnoubord != null)
        {
            plaerJoinOnSnoubord.breakForce = 0;
            this.GetComponent<DisableJoinConnekByPlaerDead>().enabled = false;
        }
    }
}
