using UnityEngine.SceneManagement;
using UnityEngine;


public class EndMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject EndMenuUI;

    void Paused()
    {
        EndMenuUI.SetActive(true);
        // Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        EndMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Exit")) 
       {
           if(!gameIsPaused)
                Paused();
       }
    }

    public void LoadMainMenu() 
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay() 
    {
        print("lol");
        Resume();
        SceneManager.LoadScene("GameScene");
    }
}