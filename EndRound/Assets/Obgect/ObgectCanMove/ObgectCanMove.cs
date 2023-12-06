using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObgectCanMove : MonoBehaviour,IInit,IMovoble,ICanTake
{
    [SerializeField] private bool obgMove = false;
    [SerializeField] private Transform folovingTarget;
    private Rigidbody2D obgBody;
    public void Init()
    {
        obgBody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 position)
    {
        transform.position=position;
    }
    public void ObgTake(Transform ogbHowTake)
    {
        obgMove=true;
        folovingTarget = ogbHowTake;
        
    }
    public void ObgDrop()
    {
        obgMove = false;
        folovingTarget = transform;
    }
    
    private void FixedUpdate()
    {
        if(obgMove) 
        {
            this.Move(folovingTarget.position);
        }
    }
}
