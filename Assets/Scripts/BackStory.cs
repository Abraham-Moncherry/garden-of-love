using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStory : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
