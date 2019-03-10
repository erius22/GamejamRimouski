﻿Shader "PeerPlay/FogEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		
	}
	SubShader
	{
			// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
		
			sampler2D _CameraDepthTexture;



            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float4 scrPos : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				o.scrPos = ComputeScreenPos(o.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : COLOR
            {
				float depthValue = Linear01Depth(tex2Dproj(_CameraDepthTexture , UNITY_PROJ_COORD(i.scrPos)).r);
                return fixed4(depthValue,depthValue,depthValue,1);
            }
            ENDCG
        }
    }
}
