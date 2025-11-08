using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float respawnDelay = 0.5f; // Time before new stone appears after pickup

    [Header("Visual Settings")]
    [SerializeField] private bool showSpawnIndicator = true;
    [SerializeField] private Color indicatorColor = Color.cyan;
    [SerializeField] private float indicatorRadius = 0.3f;

    private Stone currentStone;
    private bool stoneAvailable = true;

    void Start()
    {
        // Use this object's position if no spawn point is set
        if (spawnPoint == null)
        {
            spawnPoint = transform;
        }

        // Spawn initial stone
        SpawnStone();
    }

    void Update()
    {
        // Check if current stone was picked up or destroyed
        if (currentStone == null && stoneAvailable)
        {
            // Stone was picked up or thrown, spawn a new one after delay
            Invoke(nameof(SpawnStone), respawnDelay);
            stoneAvailable = false;
        }
    }

    void SpawnStone()
    {
        if (stonePrefab == null)
        {
            Debug.LogError("StoneSpawner: No stone prefab assigned!");
            return;
        }

        // Spawn new stone at spawn point
        GameObject stoneObj = Instantiate(stonePrefab, spawnPoint.position, spawnPoint.rotation);
        currentStone = stoneObj.GetComponent<Stone>();

        if (currentStone == null)
        {
            Debug.LogError("StoneSpawner: Spawned prefab doesn't have a Stone component!");
            Destroy(stoneObj);
            return;
        }

        // Link stone to this spawner
        currentStone.SetSpawner(this);

        stoneAvailable = true;
    }

    // Called by Stone when it's picked up
    public void OnStonePickedUp()
    {
        currentStone = null;
    }

    // Optional: Draw gizmo to show spawn location
    void OnDrawGizmos()
    {
        if (showSpawnIndicator)
        {
            Gizmos.color = indicatorColor;
            Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
            Gizmos.DrawWireSphere(position, indicatorRadius);
        }
    }
}
