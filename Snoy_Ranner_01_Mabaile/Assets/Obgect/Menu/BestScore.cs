using UnityEngine;
using TMPro;
public class BestScore : MonoBehaviour
{
   [SerializeField] private TextMeshPro textScore;
    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            textScore.text = PlayerPrefs.GetInt("Score").ToString();
        }
        else
        {
            textScore.text = "0";
        }
    }
}
