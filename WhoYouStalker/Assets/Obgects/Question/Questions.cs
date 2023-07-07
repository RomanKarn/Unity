using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour
{
    public event Action<string,int,int> eventFinal;
    public List<DataQuestion> allQuestions;

    [SerializeField] private Animator questionAnimashion;
    [SerializeField] private Plaer plaer;
    [SerializeField] private Image foto;
    [SerializeField] private TextMeshProUGUI textQuewstion;
    [SerializeField] private GameObject parentButtonAnsvers;
    [SerializeField] private GameObject prefabButtonAnsver;

    [SerializeField] private AudioSource questionSound;
    [SerializeField] private YandexSDK reclama;

    [SerializeField] private int lavelGoodAndBead;
    [SerializeField] private int lavelOrderAndChaos;

    [SerializeField] private int maxLavelGoodAndBead;
    [SerializeField] private int maxLavelOrderAndChaos;
    [SerializeField] private int minLavelGoodAndBead;
    [SerializeField] private int minLavelOrderAndChaos;

    private int namberQuestion=0;
    private string selectGame_path;


    public void Init()
    {
        reclama.PlayFullScrinReclama();
    }

    public void StartWhoYouStalker(string path,int maxGB,int maxOC, int minGB, int minOC)
    {
        selectGame_path = path;
        maxLavelGoodAndBead= maxGB;
        maxLavelOrderAndChaos = maxOC;
        minLavelGoodAndBead =minGB;
        minLavelOrderAndChaos= minOC;
        this.allQuestions = LodingXMLDataQuestion.Loding("Question/"+selectGame_path+ "/questions");
        UpdateQuestion();
    }
    public void LodingNextCard()
    {
        if (allQuestions.Count> namberQuestion)
        {
            questionAnimashion.SetTrigger("Svitch");
            questionSound.Play();
            return;
        }
        reclama.PlayFullScrinReclama();
        reclama.PlayShowRating();
        questionAnimashion.SetTrigger("Disable");
        eventFinal?.Invoke(selectGame_path, this.lavelGoodAndBead, this.lavelOrderAndChaos);
    }

    private void UpdateQuestion()
    {
        foto.sprite = allQuestions[namberQuestion].foto;
        textQuewstion.text = allQuestions[namberQuestion].text;
        ClearOutChiledParetButton();
        foreach(AnsversStrust item in allQuestions[namberQuestion].ansver)
        {
            ClicHendler newButton =  Instantiate(prefabButtonAnsver, parentButtonAnsvers.transform).GetComponent<ClicHendler>();
            newButton.InitBotton(item,this.GetComponent<Questions>());
        }
        namberQuestion++;
    }
    private void ClearOutChiledParetButton()
    {
        if (parentButtonAnsvers.transform.childCount <= 0)
            return;
        for(int i=0;i< parentButtonAnsvers.transform.childCount;i++) 
        {
           Destroy(parentButtonAnsvers.transform.GetChild(i).gameObject);
        }
    }
    public void UpdateLavelGoodAndBead(int col)
    {
        this.lavelGoodAndBead += col;
        if (lavelGoodAndBead > maxLavelGoodAndBead)
            this.lavelGoodAndBead = maxLavelGoodAndBead;
        if (lavelGoodAndBead < minLavelGoodAndBead)
            this.lavelGoodAndBead = minLavelGoodAndBead;
    }
    public void UpdateLavelOrederAndChaos(int col)
    {
        this.lavelOrderAndChaos += col;
        if (lavelOrderAndChaos > maxLavelOrderAndChaos)
            this.lavelOrderAndChaos = maxLavelOrderAndChaos;
        if (lavelOrderAndChaos < minLavelOrderAndChaos)
            this.lavelOrderAndChaos = minLavelOrderAndChaos;
    }
}

