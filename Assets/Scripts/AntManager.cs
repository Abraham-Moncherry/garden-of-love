using System.Collections.Generic;
using UnityEngine;

public class AntManager : MonoBehaviour
{
    public static AntManager Instance;

    [Tooltip("Distance between ants in the marching stream.")]
    public float spacing = 2f;

    private readonly List<AntWalker> ants = new List<AntWalker>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RegisterAnt(AntWalker ant)
    {
        if (ant != null && !ants.Contains(ant))
            ants.Add(ant);
    }

    // For FORWARD marching (Vector3.forward):
    // We want the ant with the LOWEST Z (tail).
    public float GetBackOfLineZ(float minZ)
    {
        if (ants.Count == 0) return minZ;

        float lowestZ = float.MaxValue;
        foreach (var a in ants)
        {
            if (!a || !a.isActiveAndEnabled) continue;
            float z = a.transform.position.z;
            if (z < lowestZ) lowestZ = z;
        }

        if (lowestZ == float.MaxValue)
            return minZ;

        return Mathf.Max(lowestZ - spacing, minZ);
    }
}
