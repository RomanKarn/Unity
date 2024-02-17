using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private TextMeshProUGUI textGameOver;
    private TextMeshProUGUI textScoreColl;
    private TextMeshProUGUI textBestScoreColl;
    private int bestScore;
    private Image beakGround;
    private GameObject hedder;

    private Sprite beakGroundStandart;
    private Sprite beakGroundNewScore;
    private string textStandart;
    private string textNewScore;
    public void Initcalizashion(TextMeshProUGUI textGameOver, TextMeshProUGUI textScoreColl, TextMeshProUGUI textBestScoreColl,
        Image beakGround, GameObject hedder, Sprite beakGroundStandart, Sprite beakGroundNewScore, string textStandart, string textNewScore,Plaer plaer)
    {
        this.textGameOver = textGameOver;
        this.textScoreColl = textScoreColl;
        this.textBestScoreColl = textBestScoreColl;
        this.beakGround = beakGround;
        this.hedder = hedder;
        this.beakGroundStandart = beakGroundStandart;
        this.beakGroundNewScore = beakGroundNewScore;
        this.textStandart = textStandart;
        this.textNewScore = textNewScore;

        if(PlayerPrefs.HasKey("Score"))
        {
            bestScore = PlayerPrefs.GetInt("Score");
        }
        else
        {
            PlayerPrefs.SetInt("Score", 0);
            bestScore = 0;
        }
        plaer.PlaerGameOver += PlaerGameOver;
        
        this.gameObject.SetActive(false);
    }

    private void PlaerGameOver()
    {
        this.gameObject.SetActive(true);
        if (bestScore< Score.GetScore())
        {
            NewBastScoreGameOver();
            PlayerPrefs.SetInt("Score", Score.GetScore());
        }
        else
        {
            StandartGameOver();
        }
        Score.ResetScore();
    }
    private void StandartGameOver()
    {
        textGameOver.text = textStandart.ToUpper();
        textScoreColl.text = Score.GetScore().ToString();
        textBestScoreColl.text = bestScore.ToString();
        beakGround.sprite = beakGroundStandart;
        hedder.SetActive(false);
    }
    private void NewBastScoreGameOver()
    {
        textGameOver.text = textNewScore.ToUpper();
        textScoreColl.text = Score.GetScore().ToString();
        textBestScoreColl.text = Score.GetScore().ToString();
        beakGround.sprite = beakGroundNewScore;
        hedder.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
