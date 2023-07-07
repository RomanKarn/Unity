using UnityEngine;

public class CollisionOnDeangerosObgect : MonoBehaviour
{
    [SerializeField] private Rigidbody plaerRigibodi;
    [SerializeField] private ConfigurableJoint plaerJoin;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("notDo");
        if (other.tag=="Dangeros")
        {
            Debug.Log("do");
            plaerJoin.xMotion = ConfigurableJointMotion.Free;
            plaerJoin.yMotion = ConfigurableJointMotion.Free;
            plaerJoin.zMotion = ConfigurableJointMotion.Free;
            JointDrive driveZiro= new JointDrive();
            driveZiro.positionSpring = 0;
            plaerJoin.slerpDrive = driveZiro;
            plaerRigibodi.AddForce(Vector3.forward*100f);
        }
    }
}
