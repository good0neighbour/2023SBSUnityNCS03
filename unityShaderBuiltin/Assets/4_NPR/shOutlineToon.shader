//
//Outline2Pass와 ToonShade를 결합해보세요.

Shader "Ryu/shOutlineToon"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        
        _OutlineColor ("outline Color", Color) = (0,0,0,1)
        _OutlineWidth ("outline width", Range(0,0.1)) = 0.01

        _ToonShadeLevel ("toon shade level", Range(1,10)) = 5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        cull front//전면 컬링, 후면만 렌더링

        //1 pass
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf NoLighting vertex:vert noambient noshadow

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _Color;

        fixed4 _OutlineColor;
        fixed _OutlineWidth;


        struct SurfaceOutputNoLight {
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

        void vert(inout appdata_full v)
        {
            //정점의 위치 v.vertex를 정점의 법선벡터 v.normal 방향으로 이동
            v.vertex.xyz = v.vertex.xyz + v.normal.xyz * _OutlineWidth;//<--벡터의 스칼라곱셈
                //<-- 벡터의 덧셈 연산
        }

        void surf (Input IN, inout SurfaceOutputNoLight o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = _Color;
            //o.Albedo = c.rgb;
            
            //o.Alpha = c.a;
        }
        //조명은 적용하지 않겠다
        float4 LightingNoLighting(SurfaceOutputNoLight s, float3 lightDir, float3 viewDir, float attenu)
        {
            return _OutlineColor; //검정색, 즉 조명을 적용하지 않겠다
        }
        ENDCG



        cull back   ///후면 컬링, 전면을 렌더링한다.

        //2 pass
        CGPROGRAM
        #pragma surface surf RyuToonShade noambient
        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
        };

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
            tToonShade = tToonShade / _ToonShadeLevel;    //[0, _ToonShadeLevel]사이에 불연속적인 단계별 값을 만든다.

            tResult.rgb = tToonShade * s.Albedo;
            tResult.a = s.Albedo;

            return tResult;
        }
        ENDCG



    }
    FallBack "Diffuse"
}
