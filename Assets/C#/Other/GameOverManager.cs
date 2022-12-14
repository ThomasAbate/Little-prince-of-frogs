using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la sc?ne");
            return;
        }

        instance = this;
    }

    public void OnPlayerDeath()
    {
        if(CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestoryOnLoad();
        }
        gameOverUI.SetActive(true); 
    }

    public void RetryButton()
    {
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
        SceneManager.LoadScene("Lvl 1");
        gameOverUI.SetActive(false);
        PlayerHealth.instance.Respawn();
    }

    public void MainMenuButton()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestoryOnLoad();
        SceneManager.LoadScene("Main Menu");
    }
}
