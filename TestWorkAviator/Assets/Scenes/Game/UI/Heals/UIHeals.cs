using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeals : MonoBehaviour 
{
    private Plaer plaer;
    private GameObject prefabHP;
    private GameObject conteinerHP;
    private Sprite greenHP;
    private Sprite elloyHP;
    private Sprite readHP;

    private List<GameObject> heals;
    private int coolHP = 12;
    public void Initcalizashion(Plaer plaer, GameObject prefabHP, GameObject conteinerHP, Sprite greenHP, Sprite elloyHP, Sprite readHP)
    {
        this.plaer = plaer;
        this.prefabHP = prefabHP;
        this.conteinerHP = conteinerHP;
        this.greenHP = greenHP;
        this.elloyHP = elloyHP;
        this.readHP = readHP;
        plaer.PlaerTakeColDamag += UbdateHealseAterTakeDamage;
        plaer.PlaerTakeColHalsing += UbdateHealseAterTakeHelsing;
        heals= new List<GameObject>();
        for (int i = 0; i < coolHP; i++) 
        {
            GameObject hpItem = Instantiate(prefabHP, conteinerHP.transform);
            heals.Add(hpItem);
            if (coolHP/3>i) 
            {
                hpItem.GetComponent<Image>().sprite = readHP;
                continue;
            }
            if((coolHP/3)*2>i)
            {
                hpItem.GetComponent<Image>().sprite = elloyHP;
                continue;
            }
            hpItem.GetComponent<Image>().sprite = greenHP;

        }
    }

    private void UbdateHealseAterTakeDamage(int damege)
    {
        for (int i = 1;i <= heals.Count; i++) 
        {
            if (heals[heals.Count-i].gameObject.activeInHierarchy)
            {
                heals[heals.Count - i].gameObject.SetActive(false);
                damege--;
            }
            if (damege <= 0)
                return;
        }
    }
    private void UbdateHealseAterTakeHelsing(int healse)
    {
        for (int i = 0; i < heals.Count; i++)
        {
            if (!heals[i].gameObject.activeInHierarchy)
            {
                heals[i].gameObject.SetActive(true);
                healse--;
            }
            if (healse <= 0)
                return;
        }
    }
}
