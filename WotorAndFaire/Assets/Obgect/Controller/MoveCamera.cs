using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour, IInit
{
    [SerializeField] private GameObject mainRenderObgets;
    [SerializeField] private List<Transform> poolPointMove;
    [SerializeField] private float speed;

    private Transform tergetPosinMove;
    private int idTergetPosinMove=0;
    private bool moveCanNext = false;
    public bool InitStart()
    {
        tergetPosinMove = this.transform;
        return true;
    }
    public void StartMove()
    {
        moveCanNext = true;
    }
    void FixedUpdate()
    {
        Move();
        SacssesPointTarget();
    }

    private void Move()
    {
        this.transform.position = Vector2.MoveTowards(mainRenderObgets.transform.position, tergetPosinMove.position, Time.fixedDeltaTime * speed);
    }
    private void SacssesPointTarget()
    {
        if(Vector2.Distance(this.transform.position, tergetPosinMove.position)<0.5f)
        {
            NewTarget();
        }
    }
    private void NewTarget()
    {
        if (!moveCanNext)
            return;
        tergetPosinMove = poolPointMove[idTergetPosinMove];
        idTergetPosinMove++;
        if (idTergetPosinMove >= poolPointMove.Count)
            moveCanNext = false;
    }

}
