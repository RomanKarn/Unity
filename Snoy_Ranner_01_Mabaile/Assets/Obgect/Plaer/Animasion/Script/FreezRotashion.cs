using UnityEngine;

public class FreezRotashion : MonoBehaviour
{
    [SerializeField] private Rigidbody plaerRidgibodi;
    [SerializeField] private ConfigurableJoint joinPlaer;
    public void FreezRotasionPlaer()
    {
        plaerRidgibodi.freezeRotation= true;
        joinPlaer.connectedBody = null;
        joinPlaer.xMotion = ConfigurableJointMotion.Free;
        joinPlaer.yMotion = ConfigurableJointMotion.Free;
        joinPlaer.zMotion = ConfigurableJointMotion.Free;
    }
}
