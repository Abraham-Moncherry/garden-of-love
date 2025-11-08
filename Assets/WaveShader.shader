//UNITY_SHADER_NO_UPGRADE

Shader "Unlit/WaveShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		//_FlowSpeed ("FlowSpeed", Vector3) = (0,0,-1) 
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		Pass
		{
			Cull Off
			Blend SrcAlpha OneMinusSrcAlpha //

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;	

			struct vertIn
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 color : COLOR; //
			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 color : COLOR; //
			};

			// MVP
			// Model coord -> Model Matrix -> World Coords -> View Matrix -> position? coords -> PRojection MAtrix -> P coords
			// Implementation of the vertex shader
			vertOut vert(vertIn v)
			{	
				// Displace the original vertex in view space
				//v.vertex = mul(unity_ObjectToWorld, v.vertex);
				v.vertex = mul(UNITY_MATRIX_MV, v.vertex);

				//float4 displacement = float4(0.0f, sin(v.vertex.x +_Time.y), 0.0f, 0.0f);
				//float4 displacement = float4(0.0f, 0.5*sin(v.vertex.x +_Time.y), 0.0f, 0.0f); //amplitude halved
				float4 displacement = float4(0.0f, sin(v.vertex.x + 2*_Time.y), 0.0f, 0.0f); //speed doubled (v.vertex.x + _Time.z)
				//float4 displacement = float4(0.0f, sin(v.vertex.x + _Time.y*_Time.y), 0.0f, 0.0f); //speed increases wit time
				//float4 displacement = float4(0.0f, sin(v.vertex.x ), 0.0f, 0.0f); //speed doubled

				
				//float4 newVertex = float4((v.vertex.x), sin(v.vertex.x *_Time.y), (v.vertex.z), (v.vertex.w));
				//v.vertex = newVertex;
				v.vertex += displacement;

				vertOut o;
				o.color.a = 0.5;
				//o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				//o.vertex = mul(UNITY_MATRIX_VP, v.vertex); 
				//o.vertex = mul(UNITY_MATRIX_P, mul(unity_ObjectToWorld, v.vertex)); //MP
				o.vertex = mul(UNITY_MATRIX_P, v.vertex); 
				//o.vertex = v.vertex;

				o.uv = v.uv;
				return o;
			}
			
			// Implementation of the fragment shader
			fixed4 frag(vertOut v) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, v.uv);
				return col;
			}
			ENDCG
		}
	}
}