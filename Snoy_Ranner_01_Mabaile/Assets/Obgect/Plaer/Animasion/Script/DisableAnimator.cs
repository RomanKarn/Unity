using UnityEngine;

public class DisableAnimator : MonoBehaviour
{
    [SerializeField] private Animator animatorPlaer;
    [SerializeField] private Rigidbody plaerRidgibodi;
    [SerializeField] private Rigidbody snouybord;
    [SerializeField] private ConfigurableJoint joinPlaer;
    public void DisableAnimatorInAnimasion()
    {
        animatorPlaer.enabled = false;
        plaerRidgibodi.freezeRotation = false;
        joinPlaer.connectedBody = snouybord;
        joinPlaer.xMotion = ConfigurableJointMotion.Locked;
        joinPlaer.yMotion = ConfigurableJointMotion.Locked;
        joinPlaer.zMotion = ConfigurableJointMotion.Locked;
    }
}
