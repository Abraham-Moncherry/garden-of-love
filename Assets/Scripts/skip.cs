using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Needed for IEnumerato

public class skip : MonoBehaviour
{
    AudioManager audioManager;
    public void LoadGameScene()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        audioManager.PlaySFX(audioManager.button);

    }
}
