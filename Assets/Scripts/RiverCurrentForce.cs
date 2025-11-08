using UnityEngine;
using StarterAssets;


using System.Collections.Generic; // Required for Dictionary

public class RiverCurrent : MonoBehaviour
{
    // ... (Your existing public properties remain here: currentStrength, etc.)
    public Vector3 currentStrength = new Vector3(0, 0, 5);
    public float entryRampTime = 1.0f;
    public float buoyancyForceMagnitude = 5f;
    public float waterDragMultiplier = 0.5f;

    // Use a Dictionary to track the ramp timer for every character in the water
    private Dictionary<Rigidbody, float> bodiesInCurrent = new Dictionary<Rigidbody, float>();

    // --- TRIGGER ENTER ---
    // In RiverCurrent.cs, inside the OnTriggerExit function:

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        waterController controller = other.GetComponent<waterController>();

        if (rb != null && bodiesInCurrent.ContainsKey(rb))
        {
            // 🛑 Send a zero force AND call the new ExitWater method
            if (controller != null)
            {
                controller.ApplyExternalForce(Vector3.zero);
                controller.ExitWater(); // <--- CALL THE NEW RESET METHOD
            }

            bodiesInCurrent.Remove(rb);
            Debug.Log(other.gameObject.name + " left the river current.");
        }
    }

    // --- APPLY FORCE (Physics Update) ---
    private void FixedUpdate()
    {
        // Create a list of bodies to process (copy keys to avoid modifying collection while iterating)
        List<Rigidbody> bodiesToProcess = new List<Rigidbody>(bodiesInCurrent.Keys);

        foreach (Rigidbody rb in bodiesToProcess)
        {
            // Update the ramp timer for this body
            bodiesInCurrent[rb] += Time.fixedDeltaTime;
            float rampTimer = bodiesInCurrent[rb];
            float rampFactor = Mathf.Clamp01(rampTimer / entryRampTime);

            // 1. Force Calculations
            Vector3 currentForce = currentStrength * rampFactor;
            Vector3 buoyancyForce = Vector3.up * buoyancyForceMagnitude;
            Vector3 dragForce = -rb.linearVelocity * waterDragMultiplier; // Use linearVelocity from the Rigidbody

            Vector3 totalExternalForce = currentForce + buoyancyForce + dragForce;

            // 2. Get the specific controller for this body
            waterController controller = rb.GetComponent<waterController>();

            if (controller != null)
            {
                // 3. Call the public method on the new script to apply force
                controller.ApplyExternalForce(totalExternalForce);
            }
        }
    }

    
}

/*
public class RiverCurrent : ThirdPersonController
{
    [Tooltip("The direction and strength of the river current.")]
    public Vector3 currentStrength = new Vector3(0, 0, 5); // Example: 5 units of force along the Z-axis

    [Tooltip("The time it takes for the current force to fully ramp up, creating a smooth entry.")]
    public float entryRampTime = 1.0f;

    [Tooltip("The upward force applied to simulate buoyancy (floating).")]
    public float buoyancyForceMagnitude = 5f; // New configurable property for buoyancy force

    [Tooltip("The multiplier for a simple water drag force.")]
    public float waterDragMultiplier = 0.5f;

    // A variable to track the player's controller script (which should have ApplyExternalForce).
    // We use a general MonoBehaviour since we don't know the exact class name.
    private MonoBehaviour currentController = null;
    private Rigidbody currentBody = null; // Still needed to get linearVelocity for drag
    private float rampTimer = 0.0f;

    // --- TRIGGER ENTER ---
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        // **IMPORTANT:** Get the component that has the ApplyExternalForce method.
        // Replace 'YOUR_CONTROLLER_SCRIPT_NAME' with the actual name of your script class!
        MonoBehaviour controller = other.GetComponent<MonoBehaviour>(); // Placeholder: you must find the right component

        if (rb != null && controller != null)
        {
            currentBody = rb;
            currentController = controller;
            rampTimer = 0.0f;
            Debug.Log(other.gameObject.name + " entered the river current.");
        }
    }

    // --- APPLY FORCE (Physics Update) ---
    private void FixedUpdate()
    {
        // Check if both the controller (to apply force) and the body (to calculate drag) exist
        if (currentController != null && currentBody != null)
        {
            // 1. Calculate ramp-up for smooth entry
            rampTimer += Time.fixedDeltaTime;
            float rampFactor = Mathf.Clamp01(rampTimer / entryRampTime);

            // 2. Calculate the total force vector (Current + Buoyancy + Drag)

            // Current Force: (Strength * Ramp Factor)
            Vector3 currentForce = currentStrength * rampFactor;

            // Buoyancy Force: (Upward push)
            Vector3 buoyancyForce = Vector3.up * buoyancyForceMagnitude;

            // Water Drag: (Opposite to velocity)
            // NOTE: Rigidbody.velocity is now currentBody.linearVelocity
            Vector3 dragForce = -currentBody.linearVelocity * waterDragMultiplier;

            // Total force to be applied externally
            Vector3 totalExternalForce = currentForce + buoyancyForce + dragForce;

            // 3. Apply the consolidated force using SendMessage to call ApplyExternalForce
            // SendMessage is used because we don't know the specific class type of currentController.
            currentController.SendMessage("ApplyExternalForce", totalExternalForce, SendMessageOptions.DontRequireReceiver);
        }
    }

    // --- TRIGGER EXIT ---
    private void OnTriggerExit(Collider other)
    {
        // This check ensures we only clear the references if the exiting body is the one we are tracking.
        if (other.GetComponent<Rigidbody>() == currentBody)
        {
            currentBody = null;
            currentController = null;
            Debug.Log(other.gameObject.name + " left the river current.");
        }
    }
}

/*

public class RiverCurrent : MonoBehaviour
{
    [Tooltip("The direction and strength of the river current.")]
    public Vector3 currentStrength = new Vector3(0, 0, 5); // Example: 5 units of force along the Z-axis

    [Tooltip("The time it takes for the current force to fully ramp up, creating a smooth entry.")]
    public float entryRampTime = 1.0f;

    [Tooltip("The upward force applied to simulate buoyancy (floating).")]
    public float buoyancyForceMagnitude = 5f; // New configurable property for buoyancy force

    [Tooltip("The multiplier for a simple water drag force.")]
    public float waterDragMultiplier = 0.5f;

    // A variable to track which object is currently being affected.
    private Rigidbody currentBody = null;
    private float rampTimer = 0.0f;

    // --- TRIGGER ENTER ---
    // Called when another collider enters this trigger.
    private void OnTriggerEnter(Collider other)
    {
        // 1. Check if the entering object has a Rigidbody (essential for physics).
        // 2. You might also want to check for a specific tag (e.g., "Player") to ensure only characters are affected.
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Store the body and reset the ramp timer for a smooth start.
            currentBody = rb;
            rampTimer = 0.0f;
            Debug.Log(other.gameObject.name + " entered the river current.");
        }
    }

    // --- APPLY FORCE (Physics Update) ---
    // FixedUpdate is used for physics calculations to ensure consistent application of force.
    private void FixedUpdate()
    {
        if (currentBody != null)
        {
            // 1. Calculate ramp-up for smooth entry
            rampTimer += Time.fixedDeltaTime;
            float rampFactor = Mathf.Clamp01(rampTimer / entryRampTime);

            // 2. Calculate the force vector (Strength * Ramp Factor)
            Vector3 forceVector = currentStrength * rampFactor;

            // 3. Apply the continuous current force to the Rigidbody.
            currentBody.AddForce(forceVector, ForceMode.Acceleration);

            // 4. Apply Buoyancy and Water Resistance (Expanded Physics)

            // 4a. Apply Buoyancy Force (Makes the object float)
            // This force is constant upward acceleration, helping the object rise.
            Vector3 buoyancyForce = Vector3.up * buoyancyForceMagnitude;
            currentBody.AddForce(buoyancyForce, ForceMode.Acceleration);

            // 4b. Apply Water Drag (Simulates resistance to slow down movement other than the current)
            // This is a simple force opposite to the object's velocity, making movement difficult.
            Vector3 dragForce = -currentBody.linearVelocity * waterDragMultiplier;
            currentBody.AddForce(dragForce, ForceMode.Force);
        }
    }

    // --- TRIGGER EXIT ---
    // Called when the other collider stops touching the trigger.
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>() == currentBody)
        {
            // Stop applying force to the exiting body.
            currentBody = null;
            Debug.Log(other.gameObject.name + " left the river current.");
        }
    }
}
*/