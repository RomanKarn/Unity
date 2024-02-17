using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OpenMenu()
    {
        Time.timeScale = 0;
    }
    public void Continuu()
    {
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
