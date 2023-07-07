using UnityEngine;

public class AvaratAnimasion : MonoBehaviour
{
    [SerializeField] private Transform target;
    private ConfigurableJoint joint;
    private Quaternion startRotashion;
    void Start()
    {
        this.joint = GetComponent<ConfigurableJoint>();
        this.startRotashion = transform.localRotation;
    }

    void FixedUpdate()
    {
        joint.targetRotation = Quaternion.Inverse(target.localRotation) * startRotashion;
    }
}
