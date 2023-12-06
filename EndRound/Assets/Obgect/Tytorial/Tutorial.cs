using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour, ICanEnteractive
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject vnimanie;
    public void UseObgetc()
    {
        tutorial.SetActive(true);
        vnimanie.SetActive(false);
    }

}
