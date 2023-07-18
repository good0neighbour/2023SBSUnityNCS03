Shader "Ryu/shToonShade"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0

        _ToonShadeLevel ("toon shade level", Range(1,10)) = 5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf RyuToonShade noambient//Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        //half _Glossiness;
        //half _Metallic;
        fixed4 _Color;

        fixed _ToonShadeLevel;

        struct SurfaceOutputToonShade {
            fixed3 Albedo;
            fixed3 Normal;
            fixed3 Emission;
            half Specular;
            fixed Gloss;
            fixed Alpha;
        };


        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        //void surf (Input IN, inout SurfaceOutputStandard o)
        void surf (Input IN, inout SurfaceOutputToonShade o)
        {
            fixed4 c = _Color;

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        //custom lighting
        float4 LightingRyuToonShade(SurfaceOutputToonShade s, float3 lightDir, float3 viewDir, float atten)
        {
            float4 tResult = float4(0, 0, 0, 1);

            //Lambert lighting model
            float tDot = dot(s.Normal, lightDir);   //[-1, 1]
            float tDotResult = saturate(tDot);      //[0, 1]

            float tToonShade = tDotResult * _ToonShadeLevel;//[0, _ToonShadeLevel]  <-- 범위를 늘림
            tToonShade = ceil(tToonShade);   //0, 1, 2, 3, 4, 5
            //<-- ceil함수를 사용하여 불연속적인 값으로 만듦
            //ceil 무조건 올림함수, 셰이더 함수
            /*
                0.1 --> 1
                0.7 --> 1
                1.3 --> 2
                1.9 --> 2
                ...
                4.3 --> 5
            */
            tToonShade = tToonShade / _ToonShadeLevel;    //[0, _ToonShadeLevel]사이에 불연속적인 단계별 값을 만든다.

            tResult.rgb = tToonShade * s.Albedo;
            tResult.a = s.Albedo;

            return tResult;
        }


        ENDCG
    }
    FallBack "Diffuse"
}
