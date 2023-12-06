using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPointGrob : MonoBehaviour
{
    [SerializeField] private RelegiAtributs grobTipeOnTrigger;
    private RelegiAtributs grobTipeOnTriggerNULL;
    public event Action<RelegiAtributs> EnableGrob;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ReliginPeple>() != null)
        {
            grobTipeOnTrigger = collision.GetComponent<ReliginPeple>().atribustPeaple;
            EnableGrob?.Invoke(grobTipeOnTrigger);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ReliginPeple>() != null)
        {
            grobTipeOnTrigger = grobTipeOnTriggerNULL;
            EnableGrob?.Invoke(grobTipeOnTrigger);
        }
    }
}
