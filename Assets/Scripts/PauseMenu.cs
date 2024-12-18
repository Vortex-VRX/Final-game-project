using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pauseMenuCanvas; // Assign this in Inspector

    private bool isPaused = false;

    void Update()
    {
        // Press "Escape" to toggle Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f; // Stop the game
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Ensure time is running again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure time is running again
        SceneManager.LoadSceneAsync(0); // Replace with your main menu scene name
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
