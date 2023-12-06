using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPointVepon : MonoBehaviour, ICanEnteractive
{
    [SerializeField] private EnumVapen veponTipeOnTrigger;
    public event Action<EnumVapen> EnableVepon;

    public void UseObgetc()
    {
        EnableVepon?.Invoke(veponTipeOnTrigger);
    }
}
