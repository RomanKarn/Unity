using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour,IInit
{
    public bool startTimer = false;
    public bool canSpavnNewDead=true;
    public RelegiAtributs nowAtrebutsReligion;
    public RelegiAtributs needAtrebutsReligion;

    private TrigerPointCrest crest;
    private TriggerPointGrob grob;
    private GameObject[] clous;
    private TriggerpointClouse[] clousTriget;
    private GameObject[] vepon;
    private TriggerPointVepon[] veponTriget;
    private TriggerOtpivanPiple otpivanPiple;

    private int liveColl = 3;
    private GameObject liveCollImag;

    private Image temerImag;
    [SerializeField] private float timeAll; 
    private float time;

    [SerializeField] private int haveCollDeadPiple=0;
    [SerializeField] private int needCollDeadPiple;
    private GameObject nedCollPiple;

    private GameObject gameOver;
    private GameObject gameWin;
    public void Init()
    {
        gameWin = GameObject.FindGameObjectWithTag("GameWin");
        gameWin.SetActive(false);
        gameOver = GameObject.FindGameObjectWithTag("GameOver");
        gameOver.SetActive(false);
        liveCollImag = GameObject.FindGameObjectWithTag("LiveColl");

        nedCollPiple = GameObject.FindGameObjectWithTag("NedCollDead");

        time = timeAll;
        temerImag = GameObject.FindGameObjectWithTag("Timer").GetComponent<Image>();

        crest = GameObject.FindGameObjectWithTag("TriggerPointCrest").GetComponent<TrigerPointCrest>();
        crest.EnableCrest += SwitchAtrebutCrest;
        grob = GameObject.FindGameObjectWithTag("TriggerPointGrob").GetComponent<TriggerPointGrob>();
        grob.EnableGrob += SwitchAtrebutGrob;

        clous = GameObject.FindGameObjectsWithTag("TriggerPointClouse");
        clousTriget=new TriggerpointClouse[clous.Length];
        for (int i = 0; i < clous.Length; i++) 
        {
            clousTriget[i] = clous[i].GetComponent<TriggerpointClouse>();
            clousTriget[i].EnableClouse += SwitchAtrebutClouse;
        }

        vepon = GameObject.FindGameObjectsWithTag("TriggerPointVepon");
        veponTriget = new TriggerPointVepon[vepon.Length];
        for (int i = 0; i < vepon.Length; i++)
        {
            veponTriget[i] = vepon[i].GetComponent<TriggerPointVepon>();
            veponTriget[i].EnableVepon += SwitchAtrebutVepon;
        }

        otpivanPiple= GameObject.FindGameObjectWithTag("Otpivanie").GetComponent<TriggerOtpivanPiple>();
        otpivanPiple.OtpetPiple += Otpevan;
    }
    private void SwitchAtrebutGrob(RelegiAtributs nowGrob)
    {
        needAtrebutsReligion = nowGrob;
    }
    private void SwitchAtrebutCrest(EnumCrest nowCrest)
    {
        nowAtrebutsReligion.crest = nowCrest;
    }
    private void SwitchAtrebutClouse(EnumClouse nowClouse)
    {
        nowAtrebutsReligion.close = nowClouse;
    }
    private void SwitchAtrebutVepon(EnumVapen nowVepon)
    {
        nowAtrebutsReligion.vapen = nowVepon;
    }

    private void Otpevan(int live)
    {
        if(live<0)
        {
            liveColl--;
            liveCollImag.transform.GetChild(liveColl).gameObject.SetActive(false);
        }
        else
        {
            haveCollDeadPiple++;
            nedCollPiple.GetComponent<TextMeshProUGUI>().text = haveCollDeadPiple + "/" + needCollDeadPiple;
        }
        if(needCollDeadPiple== haveCollDeadPiple)
        {
            GameWin();
        }
        if (liveColl <= 0)
        {
            GameOver();
        }
    }
    private void Update()
    {
        if(startTimer)
            Timer();
    }
    private void Timer()
    {
        time -= Time.deltaTime;
        temerImag.fillAmount=(time/timeAll);
        if (time < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }
    private void GameWin()
    {
        Time.timeScale = 0;
        gameWin.SetActive(true);
    }
}
