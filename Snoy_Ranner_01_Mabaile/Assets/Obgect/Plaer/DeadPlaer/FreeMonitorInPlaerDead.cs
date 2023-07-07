using UnityEngine;
using State;
public class FreeMonitorInPlaerDead : MonoBehaviour
{
    [SerializeField] private StateMashin stateMashin;

    private ConfigurableJoint plaerJoinOnSnoubord;
    void Start()
    {
        stateMashin.svitchStateDaed += Dead;
        this.plaerJoinOnSnoubord = this.GetComponent<ConfigurableJoint>();
    }

    private void Dead()
    {
        plaerJoinOnSnoubord.xMotion = ConfigurableJointMotion.Free;
        plaerJoinOnSnoubord.yMotion = ConfigurableJointMotion.Free;
        plaerJoinOnSnoubord.zMotion = ConfigurableJointMotion.Free;
        plaerJoinOnSnoubord.connectedBody = null;
        JointDrive driveZiro = new JointDrive();
        driveZiro.positionSpring = 0;
        driveZiro.positionDamper = 0;
        driveZiro.maximumForce = 0;
        plaerJoinOnSnoubord.slerpDrive = driveZiro;
    }

}
