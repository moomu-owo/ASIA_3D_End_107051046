using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("3DEND");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("END");
    }

    public void QuitGame()
    {
        print("離開遊戲");
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("open");
    }

    public void Lose()
    {
        SceneManager.LoadScene("lose");
    }
}