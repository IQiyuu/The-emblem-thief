using UnityEngine.SceneManagement;
using UnityEngine;


public class EndMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject EndMenuUI;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _endTheme;

    void Paused()
    {
        EndMenuUI.SetActive(true);
        Time.timeScale = 0;
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
       if(collision.CompareTag("Exit")) {
            _audioSource.Stop();
            _audioSource.clip = _endTheme;
            _audioSource.Play();
            Paused();
        }
    }

    public void LoadMainMenu() 
    {
        _audioSource.Stop();
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay() 
    {
        _audioSource.Stop();
        Resume();
        SceneManager.LoadScene("GameScene");
    }
}