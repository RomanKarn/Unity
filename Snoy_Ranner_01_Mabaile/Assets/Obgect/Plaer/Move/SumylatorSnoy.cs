using UnityEngine;
using State;

public class SumylatorSnoy : MonoBehaviour
{
    [SerializeField] private StateMashin stateMashin;
    [SerializeField] private float snoyPlotnost;
    [SerializeField] private AnimationCurve snoyEcsponent;
    private Transform plaerTransformLocal;
    private Rigidbody plaerRigidBodi;
    private void Start()
    {
        this.plaerRigidBodi = this.GetComponent<Rigidbody>();
        this.plaerTransformLocal = this.GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Ray ray = new Ray(plaerTransformLocal.transform.position, Vector3.down);
        if((Physics.Raycast(ray, out RaycastHit hit))&&(stateMashin.stateNow== "PlaerFlay"))
        {
            plaerRigidBodi.drag = snoyPlotnost * snoyEcsponent.Evaluate(hit.distance);
        }
    }
}
