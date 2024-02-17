using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Plaer plaer;
    void Start()
    {
        Init();
    }

    void Update()
    {
        
        plaer.Update();
    }

    public void Init()
    {
        plaer = new Plaer(GetComponent<Rigidbody>(),GetComponent<Animator>(),this.gameObject.transform.GetChild(0).gameObject);
    }
}
