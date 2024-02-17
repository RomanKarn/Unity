using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace MovePlaer
{
    public class MoveStandart: IMovePlaer
    {
        public float Speed { get; set; }
        public Rigidbody Plaer {  get; set; }
        public MoveStandart(Rigidbody plaer,float speedMove=1.0f)
        {
            Plaer = plaer;
            Speed = speedMove;
        }
        public void MoveLeft()
        {
            Plaer.MovePosition(Plaer.position + Vector3.left * Speed * Time.fixedDeltaTime);
        }
        public void MoveRight()
        {
            Plaer.MovePosition(Plaer.position + Vector3.right * Speed * Time.fixedDeltaTime);
        }
    }
}