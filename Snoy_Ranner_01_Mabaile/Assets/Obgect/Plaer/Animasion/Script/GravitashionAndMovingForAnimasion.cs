using UnityEngine;

public class GravitashionAndMovingForAnimasion : MonoBehaviour
{
    private Rigidbody plaerRigidBodi;
    [SerializeField]private bool enable=false;
    void Start()
    {
        this.plaerRigidBodi = this.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if(enable)
        {
            Move();
        }
    }

    public void SvitchEableFors()
    {
        if(!enable)
        {
            enable=true;
        }
        else
        {
            enable=false;
        }
    }
    private void Move()
    {
        plaerRigidBodi.AddForce(Vector3.forward * 1000f);
    }
}
