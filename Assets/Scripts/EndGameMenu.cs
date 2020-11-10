using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
        gameObject.SetActive(false);
    }
}
