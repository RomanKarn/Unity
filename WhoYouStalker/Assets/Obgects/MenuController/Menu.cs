using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public struct BottonData
{
    public string selectGame;
    public int maxGB;
    public int maxOC;
    public int minGB;
    public int minOC;
}

public class Menu : MonoBehaviour
{

    [SerializeField] private Animator questionAnimashion;
    [SerializeField] private GameObject startButton;
    [SerializeField] private Questions questions;
    [SerializeField] private List<BottonData> listButton;
    [SerializeField] private YandexSDK reclama;
    public void WhoYouStalker()
    {
        questions.StartWhoYouStalker(listButton[0].selectGame, listButton[0].maxGB, listButton[0].maxOC, listButton[0].minGB, listButton[0].minOC);
        questionAnimashion.SetTrigger("StartPoint");
        startButton.SetActive(false);
    }
    public void WhoYouLavelStalker()
    {
        questions.StartWhoYouStalker(listButton[1].selectGame, listButton[1].maxGB, listButton[1].maxOC, listButton[1].minGB, listButton[1].minOC);
        questionAnimashion.SetTrigger("StartPoint");
        startButton.SetActive(false);
    }
    public void WhoYoubBaseStalker()
    {
        reclama.PlayNotClipReclama();
        questions.StartWhoYouStalker(listButton[2].selectGame, listButton[2].maxGB, listButton[2].maxOC, listButton[2].minGB, listButton[2].minOC);
        questionAnimashion.SetTrigger("StartPoint");
        startButton.SetActive(false);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
