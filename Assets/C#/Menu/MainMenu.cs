using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingMenu()
    {
        SceneManager.LoadScene("SeetingMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("je suis plus la");
    }
}
