Shader "Custom/Outline"
{
	Properties
	{
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_OutlineWidth("Outline Width", Range(0, 4)) = 0
	}
 
	CGINCLUDE

	#include "UnityCG.cginc"
	
	struct appdata {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};
 
	struct v2f {
		float4 pos : POSITION;
		float4 color : COLOR;
	};
 
	uniform float _OutlineWidth;
	uniform float4 _OutlineColor;

	ENDCG
	
	SubShader
	{

		Tags
		{
			"Queue" = "Geometry"
			"RenderType" = "Overlay"
			"IgnoreProjector" = "True"
			"DisableBatching" = "True"
			"RenderPipeline" = "LightweightPipeline"
		}
		LOD 300

		Pass
		{
			Name "BASE"
			ColorMask 0
			ZWrite On
		}
 
		Pass
		{
			Name "OUTLINE"

			Tags
			{
				"LightMode" = "LightweightForward"
			}
			
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Front
			ZTest On
			
			Stencil {
				Ref 2
				Comp always
				Pass replace
			}

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			half4 frag(v2f i) : COLOR {
				return i.color;
			}

			v2f vert(appdata v) {
				// just make a copy of incoming vertex data but scaled according to normal direction
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);

				//float3 norm = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
				/*float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
				float2 offset = TransformViewToProjection(norm.xy);*/
				//o.pos.xy += offset * o.pos.z * _OutlineWidth;

				o.pos.z += (_OutlineWidth / 100);
				o.color = _OutlineColor;
				return o;
			}

			ENDCG

		}
	}
	Fallback "Hidden/InternalErrorShader"
}