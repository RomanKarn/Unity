using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClicHendler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Questions questionsUbdate;
    [SerializeField] private int ansverPont;
    [SerializeField] private string typeQuestion;
    public void InitBotton(AnsversStrust ansver, Questions questions)
    {
        this.questionsUbdate= questions;
        this.text.text=ansver.text;
        this.ansverPont = ansver.point; 
        this.typeQuestion= ansver.type;
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(ClicAnsver);
    }

    private void ClicAnsver()
    {
        if (this.typeQuestion == "lavelGoodAndBead")
            this.questionsUbdate.UpdateLavelGoodAndBead(this.ansverPont);
        if (this.typeQuestion == "lavelOrderAndChaos")
            this.questionsUbdate.UpdateLavelOrederAndChaos(this.ansverPont);
        this.questionsUbdate.LodingNextCard();
    }
}
