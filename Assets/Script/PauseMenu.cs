using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] AudioSource _musicPlayer;

    public bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject settingsWindow;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        _musicPlayer.Pause();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        _musicPlayer.Play();
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void LoadMainMenu() 
    {
        Resume();
        _musicPlayer.Stop();
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }
}
