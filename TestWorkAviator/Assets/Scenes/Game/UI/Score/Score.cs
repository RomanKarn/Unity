using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private static TextMeshProUGUI scoreText;
    private static int scoreNow = 0;
    public void Initcalizashion(TextMeshProUGUI scoreUI)
    {
        scoreText = scoreUI;
    }
    public static void AddScore(int collScore)
    {
        scoreNow += collScore;
        scoreText.text = scoreNow.ToString();
    }
    public static void ResetScore()
    {
        scoreNow = 0;
    }
    public static int GetScore()
    {
        return scoreNow;
    }
}
