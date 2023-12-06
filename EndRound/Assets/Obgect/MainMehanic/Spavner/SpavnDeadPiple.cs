using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpavnDeadPiple : MonoBehaviour, IInit,ICanEnteractive
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<GameObject> peplesTipe;
    [SerializeField] private GameObject deadPipleExists;
    [SerializeField] private GameObject vnimanie;
    public void Init()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        deadPipleExists = GameObject.FindGameObjectWithTag("DeadPiple");
        Repacpiple();
    }
    
    public void Spavn()
    {
        deadPipleExists.transform.position = this.transform.position+ new Vector3(0f,-1.3f,0f);
        Repacpiple();
        deadPipleExists.GetComponent<Animator>().SetTrigger("Spavn");
        gameManager.canSpavnNewDead = false;
        gameManager.startTimer = true;
        vnimanie.SetActive(false);
    }

    public void UseObgetc()
    {
        if(gameManager.canSpavnNewDead)
            Spavn();
    }

    private void Repacpiple()
    {
        int rand = Random.Range(0, peplesTipe.Count);
        deadPipleExists.GetComponent<ReliginPeple>().atribustPeaple = peplesTipe[rand].GetComponent<ReliginPeple>().atribustPeaple;
        deadPipleExists.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = peplesTipe[rand].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }
}
