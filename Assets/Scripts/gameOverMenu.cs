using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject textToHide;

    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        // Ensure game over panel is hidden at start
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(false);
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void ReturnToHome()
    {
        audioManager.PlaySFX(audioManager.button);
        // Added cursor control
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadSceneAsync(0);
    }

    public void Checkpoint()
    {
        audioManager.PlaySFX(audioManager.button);

        // Reset time scale and cursor
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Restart the current scene
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("Restarting current scene: " + currentScene);
        SceneManager.LoadScene(currentScene);
    }

    public void TriggerGameOver()
    {
        audioManager.PlaySFX(audioManager.button);
        Debug.Log("Game Over triggered!");

        GameOverPanel.SetActive(true);

        // Hide the text when game over menu appears
        if (textToHide != null)
        {
            textToHide.SetActive(false);
        }

        Time.timeScale = 0f;
        GameIsPaused = true;

        // Show cursor for menu interaction
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
