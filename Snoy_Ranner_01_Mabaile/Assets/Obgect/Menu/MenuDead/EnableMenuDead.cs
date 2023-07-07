using State;
using UnityEngine;
using UnityEngine.SceneManagement;
using Score;
using TMPro;

public class EnableMenuDead : MonoBehaviour
{
    [SerializeField] private StateMashin plaer;
    [SerializeField] private GameObject menuDead;

    [SerializeField] private ScoreCalkulateByTruks score;
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI bestScore;
    void Start()
    {
        plaer.svitchStateDaed += Dead;
    }
    private void Dead()
    {
        menuDead.SetActive(true);
        textScore.text=score.allScore.ToString();
        if(PlayerPrefs.HasKey("Score"))
        {
            if(PlayerPrefs.GetInt("Score")< score.allScore)
            {
                bestScore.text = "Best: " + score.allScore.ToString();
                PlayerPrefs.SetInt("Score", score.allScore);
            }
            else
            {
                bestScore.text = "Best: " + PlayerPrefs.GetInt("Score").ToString();
            }
        }
        else
        {
            bestScore.text="Best: "+score.allScore.ToString();
            PlayerPrefs.SetInt("Score", score.allScore);
        }
    }

    public void ResrartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
