using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderAnt : MonoBehaviour
{
    public delegate void LeaderHitEvent();
    public static event LeaderHitEvent OnLeaderHit;

    private bool hasBeenHit = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stone") && !hasBeenHit)
        {
            hasBeenHit = true;
            Debug.Log("Queen ant hit! Loading scene 3 (Checkpoint 2)...");
            OnLeaderHit?.Invoke();  // Notify all ants to disappear

            SceneManager.LoadScene(3);
        }
    }
}
