Shader "Custom/Skybox"
{
    Properties
    {
		_Color0 ("Color 1", Color) = (1, 1, 1, 0)
		_Color1 ("Color 2", Color) = (0, 0, 0, 0)
		_Position("Position", Vector) = (0, 1, 0, 0)
    }

	CGINCLUDE
	
	#include "UnityCG.cginc"

	half4 _Color0;
	half4 _Color1;
	half4 _Position;

	struct appdata
	{
		float4 position : POSITION;
		float3 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 position : SV_POSITION;
		float3 texcoord : TEXCOORD0;
	};
	
	ENDCG

    SubShader
    {
		Tags
		{
			"IgnoreProjector" = "True"
			"Queue" = "Background"
			"RenderType" = "Opaque"
			"PreviewType" = "Skybox"
			"RenderPipeline" = "LightweightPipeline"
		}

        Pass
        {
			/*Stencil{
				Ref 2
				Comp notequal
				Pass keep
				ZFail decrWrap
			}*/

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            v2f vert (appdata v)
            {
				v2f o;
				o.position = UnityObjectToClipPos(v.position);
				o.texcoord = v.texcoord;
                return o;
            }

            fixed4 frag (v2f i) : COLOR
            {
				half d = dot(normalize(i.texcoord), _Position) * 0.5f + 0.5f;
				return lerp(_Color0, _Color1, pow(d, 1));
            }

            ENDCG
        }
    }
}
