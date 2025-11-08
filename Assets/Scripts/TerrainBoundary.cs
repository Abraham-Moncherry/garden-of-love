using UnityEngine;

public class TerrainBoundary : MonoBehaviour
{
    [Header("Boundary Settings")]
    [Tooltip("The terrain that defines the play area")]
    [SerializeField] private Terrain terrain;

    [Tooltip("Buffer distance from terrain edges (in units)")]
    [SerializeField] private float edgeBuffer = 0f;

    [Header("Boundary Limits (if not using terrain)")]
    [SerializeField] private bool useManualBoundaries = false;
    [SerializeField] private float minX = -50f;
    [SerializeField] private float maxX = 50f;
    [SerializeField] private float minZ = -50f;
    [SerializeField] private float maxZ = 50f;

    private float terrainMinX;
    private float terrainMaxX;
    private float terrainMinZ;
    private float terrainMaxZ;

    void Start()
    {
        // If terrain is assigned, calculate boundaries from it
        if (!useManualBoundaries && terrain != null)
        {
            TerrainData terrainData = terrain.terrainData;
            Vector3 terrainPos = terrain.transform.position;

            terrainMinX = terrainPos.x + edgeBuffer;
            terrainMaxX = terrainPos.x + terrainData.size.x - edgeBuffer;
            terrainMinZ = terrainPos.z + edgeBuffer;
            terrainMaxZ = terrainPos.z + terrainData.size.z - edgeBuffer;

            Debug.Log($"Terrain Boundaries Set - X: {terrainMinX} to {terrainMaxX}, Z: {terrainMinZ} to {terrainMaxZ}");
        }
        else if (useManualBoundaries)
        {
            terrainMinX = minX;
            terrainMaxX = maxX;
            terrainMinZ = minZ;
            terrainMaxZ = maxZ;

            Debug.Log($"Manual Boundaries Set - X: {terrainMinX} to {terrainMaxX}, Z: {terrainMinZ} to {terrainMaxZ}");
        }
        else
        {
            Debug.LogWarning("TerrainBoundary: No terrain assigned and manual boundaries not enabled!");
        }
    }

    void LateUpdate()
    {
        // Clamp the player's position to stay within boundaries
        Vector3 currentPos = transform.position;

        currentPos.x = Mathf.Clamp(currentPos.x, terrainMinX, terrainMaxX);
        currentPos.z = Mathf.Clamp(currentPos.z, terrainMinZ, terrainMaxZ);

        transform.position = currentPos;
    }

    // Optional: Draw boundary lines in the editor for visualization
    void OnDrawGizmos()
    {
        if (terrain != null && !useManualBoundaries)
        {
            TerrainData terrainData = terrain.terrainData;
            Vector3 terrainPos = terrain.transform.position;

            float minX = terrainPos.x + edgeBuffer;
            float maxX = terrainPos.x + terrainData.size.x - edgeBuffer;
            float minZ = terrainPos.z + edgeBuffer;
            float maxZ = terrainPos.z + terrainData.size.z - edgeBuffer;

            // Draw boundary box
            Gizmos.color = Color.yellow;
            Vector3[] corners = new Vector3[4];
            corners[0] = new Vector3(minX, terrainPos.y + 5, minZ);
            corners[1] = new Vector3(maxX, terrainPos.y + 5, minZ);
            corners[2] = new Vector3(maxX, terrainPos.y + 5, maxZ);
            corners[3] = new Vector3(minX, terrainPos.y + 5, maxZ);

            for (int i = 0; i < 4; i++)
            {
                Gizmos.DrawLine(corners[i], corners[(i + 1) % 4]);
            }
        }
        else if (useManualBoundaries)
        {
            Gizmos.color = Color.yellow;
            Vector3[] corners = new Vector3[4];
            corners[0] = new Vector3(minX, transform.position.y + 5, minZ);
            corners[1] = new Vector3(maxX, transform.position.y + 5, minZ);
            corners[2] = new Vector3(maxX, transform.position.y + 5, maxZ);
            corners[3] = new Vector3(minX, transform.position.y + 5, maxZ);

            for (int i = 0; i < 4; i++)
            {
                Gizmos.DrawLine(corners[i], corners[(i + 1) % 4]);
            }
        }
    }
}
