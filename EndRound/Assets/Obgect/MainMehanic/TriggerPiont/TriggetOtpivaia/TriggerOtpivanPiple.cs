using System;
using UnityEngine;

public class TriggerOtpivanPiple : MonoBehaviour, ICanEnteractive, IInit
{
    public event Action<int> OtpetPiple;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject deadPipleExists;
    public void Init()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        deadPipleExists = GameObject.FindGameObjectWithTag("DeadPiple");
    }

    public void UseObgetc()
    {
        if (gameManager.needAtrebutsReligion.vapen == EnumVapen.nofing|| gameManager.canSpavnNewDead )
        {
            Debug.Log("DontWork");
            return;
        }
        if(gameManager.nowAtrebutsReligion.crest== gameManager.needAtrebutsReligion.crest&&
        gameManager.nowAtrebutsReligion.vapen== gameManager.needAtrebutsReligion.vapen&&
        gameManager.nowAtrebutsReligion.close== gameManager.needAtrebutsReligion.close) 
        {
            deadPipleExists.GetComponent<Animator>().SetTrigger("Otpevgood");
            gameManager.canSpavnNewDead= true;
            OtpetPiple?.Invoke(0);
        }
        else
        {
            deadPipleExists.GetComponent<Animator>().SetTrigger("Otpevbead");
            gameManager.canSpavnNewDead = true;
            OtpetPiple?.Invoke(-1);
        }
    }
}
