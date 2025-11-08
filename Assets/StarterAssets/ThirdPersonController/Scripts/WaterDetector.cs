using UnityEngine;

namespace StarterAssets
{
    public class WaterDetector : MonoBehaviour
    {
        [Header("Buoyancy Settings")]
        [Tooltip("The upward force applied when fully submerged.")]
        public float BuoyancyForce = 10f;

        [Header("Current Settings")]
        [Tooltip("The strength of the pushing force applied by the current.")]
        public float CurrentStrength = 5.0f; // New public variable for current force

        [Header("Rippling")]
        [Tooltip("Drag the water Material Asset here.")]
        public Material WaterMaterial;
        // Shader property ID for the character position (Fixes CS0103)
        private static readonly int CharacterWorldPosID = Shader.PropertyToID("_CharacterWorldPos"); // <--- NEW
        private Vector3 _offScreenPos = new Vector3(10000f, 0f, 10000f); // Far away position to disable ripple // <--- NEW

        // Get the water plane's Y-position
        private float _waterSurfaceY;

        private void Start()
        {
            Collider waterCollider = GetComponent<Collider>();

            if (waterCollider == null)
            {
                Debug.LogError("WaterDetector requires a Collider component on the same GameObject!");
                enabled = false;
                return;
            }
            
            if (WaterMaterial == null)
            {
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    // IMPORTANT: Use .material to get a unique instance, or assign the shared asset
                    // If you use an asset, make sure it's applied correctly to the Plane's Renderer.
                    // For simplicity, ensure you assign the Material asset in the Inspector.
                }
            }

            // Initialize the ripple position far away so it's not active at start
            if (WaterMaterial != null)
            {
                WaterMaterial.SetVector(CharacterWorldPosID, _offScreenPos);
            }
            // FIX: Calculate the true World Y surface by getting the top edge of the collider's bounds.
            _waterSurfaceY = waterCollider.bounds.max.y;
        }

        private void OnTriggerEnter(Collider other)
        {
            // Check if the character has entered the water
            if (other.TryGetComponent(out ThirdPersonController characterController))
            {
                characterController.InWater = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // Check if the character has left the water
            if (other.TryGetComponent(out ThirdPersonController characterController))
            {
                characterController.InWater = false;
                characterController.SetBuoyancyForce(0.0f); // Reset force
            }

            // --- NEW: RESET RIPPLE ---
            if (WaterMaterial != null)
            {
                // Set the position far away to turn the ripple effect off in the shader
                WaterMaterial.SetVector(CharacterWorldPosID, _offScreenPos);
            }
            Debug.Log("Exited from water!");
        }

        private void OnTriggerStay(Collider other)
        {
            // Check if the character is in the water and has the controller script
            if (other.TryGetComponent(out ThirdPersonController characterController))
            {
                // Add this line to confirm detection:
                Debug.Log("Character Detected at: " + other.transform.position, other.gameObject); // <--- ADD THIS
                if (!characterController.InWater) return;

                // 1. Calculate Submersion Depth
                // We use the bottom of the character controller for a more stable buoyancy
                float characterBottomY = other.transform.position.y - (other.bounds.size.y / 2f);
                float depth = _waterSurfaceY - characterBottomY;
                
                // Use the character's full height to normalize the depth
                float characterHeight = other.bounds.size.y;
                float immersionRatio = Mathf.Clamp01(depth / characterHeight);

                // 2. Calculate Buoyant Force
                // Force increases as more of the character is submerged.
                float currentBuoyancy = BuoyancyForce * immersionRatio;
                
                // --- NEW: RIPPLE EFFECT UPDATE ---
                if (WaterMaterial != null)
                {
                    // Pass the character's world position to the shader
                    WaterMaterial.SetVector(CharacterWorldPosID, other.transform.position);
                }

                // 3. Apply the force to the character controller
                characterController.SetBuoyancyForce(currentBuoyancy);

                // --- PUSHING FORCE (NEW) ---
                // 1. Define the force vector (World Z direction)
                Vector3 pushDirection = Vector3.back; // This is (0, 0, 1) in World Space

                // 2. Apply the current strength, scaled by immersion (push is stronger when submerged)
                Vector3 currentForce = pushDirection * CurrentStrength * immersionRatio;

                // 3. Apply the force using the CharacterController's Move function.
                // We use Time.deltaTime here, but since the CharacterController handles movement,
                // we will pass the force directly for the controller to integrate.

                // Note: Since CharacterController's Move uses Time.deltaTime internally 
                // and often smooths movement, we apply the force as a velocity offset.

                // The CharacterController does not have a public method to add an external force directly.
                // We need to modify the ThirdPersonController to accept a velocity offset.
                // However, the *simplest* way is to apply the force directly to the character's position
                // via the CharacterController's Move method, if not already moving, or to modify the 
                // *input* velocity.

                // Alternative 1 (Simple Push using Move):
                //characterController._controller.Move(currentForce * Time.deltaTime);

                // Apply the velocity to the character controller
                characterController.SetCurrentVelocity(currentForce);
            }
        }
    }
}