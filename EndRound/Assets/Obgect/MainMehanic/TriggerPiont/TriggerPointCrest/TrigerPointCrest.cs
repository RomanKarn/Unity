using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerPointCrest : MonoBehaviour
{

    [SerializeField] private EnumCrest crestTipeOnTrigger;

    public event Action<EnumCrest> EnableCrest;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ObgTriggerCrest>() != null)
        {
            crestTipeOnTrigger = collision.GetComponent<ObgTriggerCrest>().crestTipe;
            EnableCrest?.Invoke(crestTipeOnTrigger);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ObgTriggerCrest>() != null)
        {
            crestTipeOnTrigger = EnumCrest.nofing;
            EnableCrest?.Invoke(crestTipeOnTrigger);
        }
    }
}
