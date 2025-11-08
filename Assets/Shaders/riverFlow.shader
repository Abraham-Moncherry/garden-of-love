Shader "River Flow (Procedural - Lit Final)"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Color ("Color Tint", Color) = (0.1, 0.4, 0.6, 0.9)

		_NormalMap ("Normal Map", 2D) = "bump" {}
		_NormalTiling ("Normal Tiling", Float) = 1.0
		_NormalStrength ("Normal Strength", Range(0.0, 2.0)) = 1.54
		
		_SpecularColor ("Specular Color (Reflection)", Color) = (1.0, 1.0, 1.0, 1.0)
		_Glossiness ("Glossiness (Sharpness)", Range(0.0, 1.0)) = 0.926
		_Opacity ("Opacity (1=Opaque)", Range(0.0, 1.0)) = 0.88 
		
		_NoiseScale ("Noise Scale (Tiling)", Range(0.1, 10.0)) = 8.55
		_NoiseFrequency ("Noise Speed Multiplier", Range(0.1, 5.0)) = 2.06
		_NormalStrength ("Normal Strength", Range(0.0, 5.0)) = 1.54

		_FlowSpeed ("Flow Speed", Range(0.01, 20.0)) = 20.0
		_FlowDirection ("Flow Direction (UV)", Vector) = (0.0, 1.0, 0.0, 0.0)
		
		_DistortionStrength ("Ripple Distortion Strength", Range(0.0, 0.1)) = 0.1

		[Header(Ripple Interaction)]
		_RippleRadius ("Interaction Radius", Range(0.1, 5.0)) = 2.61
		_RippleStrength ("Interaction Strength", Range(0.0, 0.5)) = 0.253
		_RippleFrequency ("Wave Frequency", Range(1.0, 50.0)) = 10.5
		_RippleSpeed ("Wave Speed", Range(1.0, 10.0)) = 6.55
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="AlphaTest" } 
        LOD 100

        Pass
        {
			// Settings for visibility and blending
			Cull Off
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha // Enables transparency blending
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "Lighting.cginc" // Crucial for _LightColor0, UNITY_LIGHTMODEL_AMBIENT

			uniform sampler2D _MainTex;	

			uniform fixed4 _Color;        // Corresponds to _Color ("Water Color", Color)
			uniform float _Opacity;       // Corresponds to _Opacity ("Opacity", Range(0.0, 1.0))
			uniform fixed4 _SpecularColor; // Corresponds to _SpecularColor ("Specular Color", Color)
			uniform float _Glossiness;    

			// Ripple Effect
			float _RippleRadius;
			float _RippleStrength;
			float _RippleFrequency;
			float _RippleSpeed;

			// Set globally by the C# script
			uniform float3 _CharacterWorldPos;
			uniform float4 _MainTex_ST;

			uniform sampler2D _NormalMap;
			uniform float4 _NormalMap_ST; // Auto-generated for tiling/offset
			uniform float _NormalStrength;

			// Ripple function: calculates the vertical displacement (height) from the character interaction.
			float GetRippleDisplacement(float3 worldPos)
			{
				// 1. Calculate distance from current water point to the character (on the XZ plane)
				float2 charXZ = _CharacterWorldPos.xz;
				float2 waterXZ = worldPos.xz;
				
				float rippleDistance = distance(charXZ, waterXZ);
				
				// 2. Check if the point is outside the ripple radius
				if (rippleDistance > _RippleRadius)
					return 0.0;

				// 3. Ripple Decay/Falloff
				// Scale the ripple strength based on distance (strongest at center, zero at radius edge)
				float falloffT =rippleDistance / _RippleRadius;
				float smoothFalloff = 1.0 - (falloffT * falloffT);
				
				// 4. Time and Wave Calculation
				float time = _Time.x * _RippleSpeed;
				
				// Calculate the sinusoidal wave based on time and distance
				float wave = cos(rippleDistance * _RippleFrequency - time);

				return wave * smoothFalloff * _RippleStrength;
			}

			struct vertIn
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 worldPos : TEXCOORD1; // World Position for ripple calculation
				float3 worldNormal : NORMAL; // for Normal map and 3D effect
			};

			// MVP
			// Model coord -> Model Matrix -> World Coords -> View Matrix -> position? coords -> PRojection MAtrix -> P coords
			// Implementation of the vertex shader
			vertOut vert(vertIn v)
			{	
				
				vertOut o;
				// 1. Calculate and store the World Position
				float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.worldPos = worldPos.xyz;

				// --- Calculate ALL World-Space Displacements ---
				float rippleOffset = GetRippleDisplacement(o.worldPos);

				// Calculate the existing sine wave using World Position X
				// NOTE: the original sine wave was using View X, but we must use World X for stability
				//float existingWave = 0.5 * sin((worldPos.x + _Time.y)*0.1);

				float totalOffset = rippleOffset ;

				// 2. Apply displacement to the World Position Y component
				worldPos.y += totalOffset; 

				// ... before the projection (mul(UNITY_MATRIX_P, viewPos);) ...

				// --- NEW: Recalculate World Normal (Requires calculating the slope/derivative) ---
				// To calculate the slope, we sample the displacement function slightly offset
				// in X and Z and use the difference to create the new normal.

				// 1. Sample displacement at nearby points
				float2 epsilon = float2(0.01, 0.01); // A small distance to sample the slope

				// Displacement at WorldPos + small offset in X
				float offset_x = GetRippleDisplacement(o.worldPos + float3(epsilon.x, 0, 0)); // Add base wave displacement
								
				// Displacement at WorldPos + small offset in Z
				float offset_z = GetRippleDisplacement(o.worldPos + float3(0, 0, epsilon.y)); // Add base wave displacement

				// Current displacement 
				float offset_c = totalOffset; // Already calculated above

				// 2. Calculate the slope (tangents)
				// Tweak the x and z components of the normal based on the slope/difference.
				float3 newNormal;
				newNormal.x = -(offset_x - offset_c) / epsilon.x; // Slope in X
				newNormal.y = 1.0;                             // Standard Y up
				newNormal.z = -(offset_z - offset_c) / epsilon.y; // Slope in Z

				// 3. Transform new normal to World Space and Normalize
				// The calculation above gives us the normal in Object/Tangent space, but since 
				// the displacement is along the Y-axis of the *World* plane, it's effectively 
				// the new World Normal in a simplified scenario.

				o.worldNormal = normalize(newNormal); 
				// We are skipping transforming the normal from tangent space for simplicity, 
				// as the water mesh is usually a flat plane aligned to the world axes.

				// 3. Project the displaced vertex to Clip Space (Screen Position)

				// Transform the displaced World Position to View Space, then to Clip Space
				float4 viewPos = mul(UNITY_MATRIX_V, worldPos);
				o.vertex = mul(UNITY_MATRIX_P, viewPos); 

				// Pass UVs
				o.uv = v.uv;

				return o;
			}
			
			// Implementation of the fragment shader
			// --- FRAGMENT SHADER ---
			fixed4 frag(vertOut v) : SV_Target
			{
				// 1. TEXTURE UVs AND NORMAL MAPPING (from the current shader)
				
				// Rescaling the texture image
				float2 worldUV = v.worldPos.xz;
				float2 finalUV = worldUV * _MainTex_ST.xy + _MainTex_ST.zw;
				
				// Normal map UVs
				float2 normalUV = v.worldPos.xz * _NormalMap_ST.xy + _NormalMap_ST.zw;
				
				// Sample, decode, and strengthen normal map
				float4 packedNormal = tex2D(_NormalMap, normalUV);
				float3 localNormal = UnpackNormal(packedNormal);
				localNormal.xy *= _NormalStrength;
				localNormal.z = sqrt(1.0 - saturate(dot(localNormal.xy, localNormal.xy)));
				
				// Combine the normal map with the ripple-displaced world normal
				// NOTE: This assumes v.worldNormal is the displaced normal from the vertex shader.
				float3 normalDirection = normalize(v.worldNormal + localNormal); 


				// --- 2. BASE COLOR AND OPACITY (from the other shader, using the simple UV)
				
				// Use the calculated UV for the main texture
				fixed4 albedo = tex2D(_MainTex, finalUV) * _Color;
				
				// APPLY OPACITY from the _Opacity property
				albedo.a = _Opacity; 


				// --- 3. LIGHTING SETUP (from the other shader)
				
				float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - v.worldPos);
				float3 lightDir = _WorldSpaceLightPos0.xyz; 
				// The normalDirection is already calculated above (Step 1)
				
				// 4. Lighting Components (Diffuse, Ambient, Specular)
				float NdotL = max(0.0, dot(normalDirection, lightDir));
				float3 diffuse = (NdotL * _LightColor0.rgb) *1;
				float3 ambient = (UNITY_LIGHTMODEL_AMBIENT.xyz) * 4;
				
				float3 halfDir = normalize(viewDir + lightDir);
				float NdotH = max(0.0, dot(normalDirection, halfDir));
				float specular = pow(NdotH, _Glossiness * 128.0) * NdotL;
				float3 finalSpecular = specular * _SpecularColor.rgb;

				// 5. Combine and Output
				fixed3 finalColor = (ambient + diffuse) * albedo.rgb + finalSpecular;
				
				fixed4 col = fixed4(finalColor, albedo.a);

				// apply fog
				UNITY_APPLY_FOG(v.fogCoord, col);
				return col;
			}
			ENDCG
        }
    }
}