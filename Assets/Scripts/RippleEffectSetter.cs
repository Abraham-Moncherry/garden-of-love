using UnityEngine;

public class RippleEffectSetter : MonoBehaviour
{
    // The name of the property MUST match the uniform in the shader.
    private readonly int ShaderCharacterPosID = Shader.PropertyToID("_CharacterWorldPos");

    void Update()
    {
        // Pass the character's current World Position to the shader every frame.
        // The Y component is the water surface, so we often ignore the character's Y.
        Shader.SetGlobalVector(ShaderCharacterPosID, transform.position);
    }
}