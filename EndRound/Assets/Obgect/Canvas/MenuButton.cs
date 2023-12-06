using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour, IInit
{
    [SerializeField] private GameObject menu;
    public void Init()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
        menu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            menu.SetActive(true);
        }
    }
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        menu.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
