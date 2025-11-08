using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Needed for IEnumerator

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlayGame()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        audioManager.PlaySFX(audioManager.button);
        yield return new WaitForSeconds(1f); // waits 1 second
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        audioManager.PlaySFX(audioManager.button);
        Application.Quit();
    }
}
