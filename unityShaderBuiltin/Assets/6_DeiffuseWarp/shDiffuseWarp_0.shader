/*

    Ramp Texture 기법
        <-- '텍스쳐(이미지) 기반 라이팅 기법'이다.

    Diffuse Warp 기법

        <-- 밸브 사가 발표한 팀포트리스2의 그래픽 톤앤매너를 만들어내기 위한 방법 중 하나
        <-- '텍스쳐(이미지) 기반 라이팅 기법'이다.
        <-- Half Lambert 기법도 섞여있다.

*/



Shader "Ryu/shDiffuseWarp_0"
{
    Properties
    {
        //_Color ("Color", Color) = (1,1,1,1)
        _RampTex ("Ramp Texture", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf DiffuseWarp noambient//Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _RampTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        //half _Glossiness;
        //half _Metallic;
        //fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = fixed4(1,1,1,1);//<--흰색을 결정. 왜냐하면 그래야 조명색상을 정확히 관찰 가능
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        float4 LightingDiffuseWarp(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
        {
            float4 tResult = float4(0, 0, 0, 1);

            //Half Lambert
            float tDot = dot(s.Normal, lightDir) * 0.5 + 0.5;


            float4 tTexColor = tex2D(_RampTex, float2(tDot, 0.5));

            tResult.rgb = tTexColor;//tDot;
            tResult.a = s.Albedo;


            return tResult;
        }


        ENDCG
    }
    FallBack "Diffuse"
}
