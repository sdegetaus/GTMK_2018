Shader "Custom/Color Inverter"
{
    Properties
    {
		_Color("Tint", Color) = (1, 1, 1, 1)
    }

	CGINCLUDE

	#include "UnityCG.cginc"

	uniform float4 _Color;

	struct appdata
	{
		float4 vertex : POSITION;
		float4 color : COLOR;
	};

	struct v2f
	{
		float4 pos : SV_POSITION;
		float4 color : COLOR0;
	};

	ENDCG

    SubShader
    {
        Tags
		{
			"Queue" = "Transparent"
			"RenderPipeline" = "LightweightPipeline"
		}

		Pass
		{
			ColorMask 0
			ZWrite Off
			ZTest Greater
		}

		Blend OneMinusDstColor OneMinusSrcAlpha

        Pass
        {
			Name "INVERSION"

			Tags
			{
				"LightMode" = "LightweightForward"
			}

			/*Stencil {
				Ref 2
				Comp equal
				Pass keep
				ZFail decrWrap
			}*/
		
            CGPROGRAM
            
			#pragma vertex vert
			#pragma fragment frag

			v2f vert(appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = _Color;
				return o;
			}

			half4 frag(v2f input) : COLOR
			{
				return input.color;
			}

            ENDCG
        }
    }
}
