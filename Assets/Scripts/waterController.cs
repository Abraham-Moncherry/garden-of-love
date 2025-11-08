using UnityEngine;

public class waterController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 waterForce = Vector3.zero;

    // A flag to indicate if the character is currently in the river trigger
    private bool isInWater = false; 

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("watertController requires a CharacterController component.");
            enabled = false;
        }
    }

    // RiverCurrent.cs calls this to send the force
    public void ApplyExternalForce(Vector3 force)
    {
        waterForce = force;
        // The river script must call this every FixedUpdate while in water
        isInWater = true; 
    }

    void Update()
    {
        // 1. Only apply water movement when the character is explicitly flagged as being in water.
        // This prevents the water controller from interfering with land movement logic.
        if (isInWater)
        {
            // Apply the force as a movement vector
            characterController.Move(waterForce * Time.deltaTime);
        }
    }
    
    // NEW PUBLIC METHOD: The RiverCurrent script must call this when the character leaves
    public void ExitWater()
    {
        isInWater = false;
        waterForce = Vector3.zero; // Immediately reset the force
    }
}