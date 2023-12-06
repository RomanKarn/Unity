using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class StartInitAllObg : MonoBehaviour
{
    [SerializeField] private IInit[] obgInit;
    void Start()
    {
        obgInit = FindObjectsOfType<MonoBehaviour>(true).OfType<IInit>().ToArray();

        for (int i = 0; i < obgInit.Length; i++)
        {
            obgInit[i].Init();
        }
    }
}
