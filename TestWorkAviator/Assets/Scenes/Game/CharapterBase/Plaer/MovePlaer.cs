using UnityEngine;

public class MovePlaer : MoveBase
{
    public MovePlaer(Transform obgect, Vector3 target, float speed) : base(obgect, target, speed)
    {
    }
    public override void MoveUpdate()
    {
        obgectMove.position = Vector3.MoveTowards(obgectMove.position, new Vector3(TargetMove.x, obgectMove.position.y, obgectMove.position.z), Speed * Time.fixedDeltaTime);
    }

    public override void MoveUpdate(Vector3 target)
    {
        obgectMove.position = Vector3.MoveTowards(obgectMove.position, new Vector3(target.x, obgectMove.position.y, obgectMove.position.z), Speed * Time.fixedDeltaTime);
    }
}
