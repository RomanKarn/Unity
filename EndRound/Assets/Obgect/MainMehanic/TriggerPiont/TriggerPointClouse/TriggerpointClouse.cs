using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerpointClouse : MonoBehaviour
{
    [SerializeField] private EnumClouse clouseTipeOnTrigger;
    public event Action<EnumClouse> EnableClouse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EnableClouse?.Invoke(clouseTipeOnTrigger);
        }
    }
}
