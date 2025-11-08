using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject pausePanel;

    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        // Ensure pause panel is hidden at start
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

        // Added cursor control
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Using Escape key for pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        audioManager.PlaySFX(audioManager.button);
        if (pausePanel == null)
        {
            return;
        }
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        // Added cursor control
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        audioManager.PlaySFX(audioManager.button);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        // Added cursor control
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
}