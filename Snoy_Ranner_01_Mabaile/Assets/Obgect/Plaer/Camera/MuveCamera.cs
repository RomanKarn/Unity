using UnityEngine;

public class MuveCamera : MonoBehaviour
{
    [SerializeField] private GameObject plaer;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed = 10;

    private Transform plaerPosishion;
    private Transform cameraPosishion;
    void Start()
    {
        this.cameraPosishion = this.GetComponent<Transform>();
        plaerPosishion = plaer.GetComponent<Transform>();
    }
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        cameraPosishion.LookAt(plaerPosishion,Vector3.up);
    }
    private void Move()
    {
        Vector3 cameraPosishionTarget=new Vector3(plaerPosishion.position.x, plaerPosishion.position.y, plaerPosishion.position.z);
        this.transform.position=Vector3.MoveTowards(cameraPosishion.position, cameraPosishionTarget+ offset, Time.fixedDeltaTime * speed);
    }
}
