using UnityEngine;

public class MoveBase
{
    public float Speed {  get; set; }
    public Vector3 TargetMove {  get; set; }
    protected Transform obgectMove;

    public MoveBase(Transform obgect, Vector3 target, float speed=1f)
    {
        obgectMove = obgect;
        TargetMove = target;
        Speed = speed;
    }
    public virtual void MoveUpdate()
    {
        obgectMove.position = Vector3.MoveTowards(obgectMove.position,TargetMove,Speed*Time.fixedDeltaTime);
    }
    public virtual void MoveUpdate(Vector3 target)
    {
        obgectMove.position = Vector3.MoveTowards(obgectMove.position, target, Speed * Time.fixedDeltaTime);
    }
}
