using UnityEngine;
using System.Collections;

public class AntWalker : MonoBehaviour
{
    [Header("Movement (Z-axis, TOWARD girl)")]
    public float speed = 1f;

    [Tooltip("Back boundary (respawn behind stream)")]
    public float minZ = -50f;

    [Tooltip("Front boundary (girl region, loop trigger)")]
    public float maxZ = 1f;

    public bool isPaused = false;

    private Renderer[] renderers;
    private Collider[] colliders;

    void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
    }

    void Start()
    {
        if (AntManager.Instance != null)
            AntManager.Instance.RegisterAnt(this);
    }

    void OnEnable()  => LeaderAnt.OnLeaderHit += ClearPathTemporarily;
    void OnDisable() => LeaderAnt.OnLeaderHit -= ClearPathTemporarily;

    void Update()
    {
        if (isPaused) return;

        // March TOWARD the girl (positive Z)
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        // Loop when passing front boundary (maxZ)
        Vector3 pos = transform.position;
        if (pos.z > maxZ)
        {
            float newZ = (AntManager.Instance != null)
                ? AntManager.Instance.GetBackOfLineZ(minZ)
                : minZ;

            transform.position = new Vector3(pos.x, pos.y, newZ);
        }
    }

    void ClearPathTemporarily() => StartCoroutine(PauseAndReturn());

    IEnumerator PauseAndReturn()
    {
        isPaused = true;

        foreach (var r in renderers) r.enabled = false;
        foreach (var c in colliders) c.enabled = false;

        yield return new WaitForSeconds(5f);

        foreach (var r in renderers) r.enabled = true;
        foreach (var c in colliders) c.enabled = true;

        isPaused = false;
    }
}
