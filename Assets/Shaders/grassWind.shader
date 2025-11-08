Shader "Custom/Grass Wind Bender (Simple Unlit)" // Renamed for clarity
{
    Properties
    {
        [Header(Texture)]
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
        [Header(Wind Parameters)]
        _WindMagnitude ("Wind Bend Magnitude", Range(0.0, 1.0)) = 0.5
        _WindSpeed ("Wind Speed", Range(0.1, 5.0)) = 1.0
        _BendCurvePower ("Bend Curve Power (1=Linear, 2+=Curved)", Range(1.0, 5.0)) = 2.0
        
        [Header(Rendering)]
        // Simplified rendering properties
        _Cutoff ("Alpha Cutoff", Range(0.0, 1.0)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="TransparentCutout" "Queue"="AlphaTest" }
        LOD 100

        // Required for alpha testing (transparency with hard edges)
        Cull Off
        
        Pass 
        {
            CGPROGRAM
            // --- SHADING MODEL CHANGE: Now a simple Vertex/Fragment Shader ---
            #pragma vertex vert
            #pragma fragment frag
            // ----------------------------------------------------------------
            #pragma target 3.0
            #pragma multi_compile_fog // Optional, but good practice for Unlit

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            float _WindMagnitude;
            float _WindSpeed;
            float _BendCurvePower;
            float _Cutoff;

            // --- STRUCTS (SIMPLIFIED) ---
            
            // Input: Position and UV are all we need
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            // Output: Clip position, UVs, and Fog coordinates
            struct v2f
            {
                float4 vertex : SV_POSITION; // Final screen position
                float2 uv : TEXCOORD0;       // UVs for texture lookup
                UNITY_FOG_COORDS(1) 
            };

            // --- VERTEX SHADER (Bending Logic) ---
            
            v2f vert (appdata v)
            {
                v2f o;
                
                // 1. Calculate the Normalized Height Factor (0 at base, 1 at tip)
                float heightFactor = saturate(v.vertex.y); 

                // 2. Define Wind Properties and Direction
                float windStrength = sin(_Time.y * _WindSpeed) * _WindMagnitude;
                float2 windDirection = normalize(float2(0.8, 0.4)); 

                // 3. Calculate Curving Displacement
                float curveFactor = pow(heightFactor, _BendCurvePower); 
                float2 horizontalDisplacement = windDirection * windStrength * curveFactor;

                // 4. Apply Displacement to Local Vertex Position (X and Z)
                v.vertex.xz += horizontalDisplacement;

                // 5. Transform to Clip Space (Screen Position)
                o.vertex = UnityObjectToClipPos(v.vertex);

                // 6. Pass UVs and Fog
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);

                return o;
            }

            // --- FRAGMENT SHADER (Minimal Color and Clipping) ---
            
            // This function handles texture lookup and clipping.
            fixed4 frag (v2f i) : SV_Target
            {
                // Sample the texture
                fixed4 c = tex2D (_MainTex, i.uv);
                
                // Apply Alpha Clipping (to remove the square edges of the billboard)
                clip(c.a - _Cutoff);
                
                // Output the final color (Unlit: only texture color)
                fixed4 finalColor = fixed4(c.rgb, c.a);
                
                // Apply fog (if enabled in scene)
                UNITY_APPLY_FOG(i.fogCoord, finalColor);
                
                return finalColor;
            }
            ENDCG
        }
    }
}
