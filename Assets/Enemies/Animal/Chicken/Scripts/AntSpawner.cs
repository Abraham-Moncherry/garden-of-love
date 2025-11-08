using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject antPrefab;
    public int antCount = 10;  // Increased from 5 to 10 for more ants and more leader spawns
    public float spacing = 1.5f;
    public Material leaderMaterial;  // drag special material in inspector
    public Material regularAntMaterial;  // drag regular ant material in inspector

    [Header("Leader Spawn Settings")]
    [Tooltip("Number of leader ants to spawn (1-5 recommended)")]
    public int leaderCount = 4;  // Spawn 4 leader ants for better visibility (40% of total)

    private GameObject[] leaderAnts;

    void Start()
    {
        // Delete any pre-existing ants in the scene to prevent stacking
        DeletePreExistingAnts();

        GameObject[] ants = new GameObject[antCount];

        Debug.Log($"AntSpawner starting at position: {transform.position}");

        for (int i = 0; i < antCount; i++)
        {
            Vector3 spawnPos = transform.position + new Vector3(0, 0, i * spacing);

            // Raycast downward to find terrain surface
            RaycastHit hit;
            Vector3 rayOrigin = new Vector3(spawnPos.x, spawnPos.y + 50f, spawnPos.z);

            if (Physics.Raycast(rayOrigin, Vector3.down, out hit, 100f))
            {
                // Spawn on terrain surface
                spawnPos = hit.point + new Vector3(0, 0.5f, 0);
                Debug.Log($"Ant {i}: Raycast hit terrain at Y={hit.point.y}, spawning at Y={spawnPos.y}");
            }
            else
            {
                Debug.LogWarning($"Ant {i} RAYCAST FAILED from {rayOrigin} - check terrain collider! Using fallback position {spawnPos}");
            }

            ants[i] = Instantiate(antPrefab, spawnPos, antPrefab.transform.rotation);

            // DON'T apply material here - we'll do it later based on whether it's a leader or not
        }

        // Clamp leader count to valid range
        int actualLeaderCount = Mathf.Clamp(leaderCount, 1, antCount);
        leaderAnts = new GameObject[actualLeaderCount];

        // Keep track of which indices are leaders
        bool[] isLeader = new bool[antCount];

        // Pick multiple random leaders (ensure unique selection)
        for (int i = 0; i < actualLeaderCount; i++)
        {
            int randomIndex;

            // Keep picking until we find an ant that isn't already a leader
            do
            {
                randomIndex = Random.Range(0, antCount);
            } while (isLeader[randomIndex]);

            isLeader[randomIndex] = true;
            leaderAnts[i] = ants[randomIndex];

            // Assign Leader Script
            leaderAnts[i].AddComponent<LeaderAnt>();

            Debug.Log($"Leader ant spawned at index {randomIndex}");
        }

        // Now apply materials to ALL ants based on whether they're leaders
        for (int i = 0; i < antCount; i++)
        {
            if (isLeader[i])
            {
                // This is a leader - apply leader material
                if (leaderMaterial != null)
                {
                    foreach (Renderer rend in ants[i].GetComponentsInChildren<Renderer>())
                    {
                        rend.material = leaderMaterial;
                    }
                }
            }
            else
            {
                // This is a regular ant - apply regular material
                if (regularAntMaterial != null)
                {
                    foreach (Renderer rend in ants[i].GetComponentsInChildren<Renderer>())
                    {
                        rend.material = regularAntMaterial;
                    }
                }
            }
        }

    }

    void DeletePreExistingAnts()
    {
        // Find and DELETE any existing ants in the scene to prevent stacking/duplication
        AntWalker[] existingAnts = FindObjectsOfType<AntWalker>();

        if (existingAnts.Length > 0)
        {
            Debug.LogWarning($"Found {existingAnts.Length} pre-existing ant(s) in scene - DELETING them to prevent issues");

            foreach (AntWalker ant in existingAnts)
            {
                Destroy(ant.gameObject);
            }
        }
    }
}
