using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [Header("Plaer")]
    public Plaer Plaer;
    public CharapterBaseData PlaerSpriptableObgect;
    public GameObject PlaerBulletPrefab;
    public BulletBaseData PlaerBulletData;

    [Header("Enemi")]
    public GameObject Enemi;
    public EnemiCharapterData EnemiSpriptableObgect;
    public GameObject EnemiBulletPrefab;
    public BulletBaseData EnemiBulletData;

    [Header("Healsing")]
     public GameObject HealsingPrefab;
     public List<HealsEtemsBaseData> HealsingSpriptableObgect;

    [Header("Spavner")]
    public Spavner Spavner;
    [Header("InputSistem")]
    private InputSistem movePlaer;

    [Header("UI-HealsBar")]
    public UIHeals HealsBar;
    public GameObject prefabHP;
    public GameObject conteinerHP; 
    public Sprite greenHP; 
    public Sprite elloyHP; 
    public Sprite readHP;
    [Header("UI-Scoree")]
    public Score ScorePoint;
    public TextMeshProUGUI Score;
    [Header("UI-GameOver")]
    public GameOver GameOverUI;
    public TextMeshProUGUI TextGameOver;
    public TextMeshProUGUI TextScoreColl;
    public TextMeshProUGUI TextBestScoreColl;
    public Image BeakGround;
    public GameObject Hedder;

    public Sprite BeakGroundStandart;
    public Sprite BeakGroundNewScore;
    public string TextStandart;
    public string TextNewScore;
    void Start()
    {
        movePlaer = new InputSistem();
        Plaer.Initcalizashion(PlaerSpriptableObgect,PlaerBulletPrefab,PlaerBulletData);
        Spavner.Initcalizashion
            (Enemi, EnemiSpriptableObgect, 
            EnemiBulletPrefab, EnemiBulletData, 
            HealsingPrefab, HealsingSpriptableObgect, 
            Plaer);

        HealsBar.Initcalizashion(Plaer, prefabHP, conteinerHP, greenHP, elloyHP, readHP);
        ScorePoint.Initcalizashion(Score);
        GameOverUI.Initcalizashion
            (TextGameOver, TextScoreColl, TextBestScoreColl, BeakGround, Hedder, 
            BeakGroundStandart, BeakGroundNewScore, 
            TextStandart, TextNewScore,
            Plaer);
    }

    void Update()
    {
        Plaer.SetTargetMove(movePlaer.GetPointMove());
    }
}
