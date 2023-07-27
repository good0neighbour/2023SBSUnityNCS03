/*
    물을 표현하는 재질을 만들어보자.

    step_0

    하늘이 반사되는 느낌의 반사맵을 구현하자
    <--큐브맵을 이용하겠다.

*/
Shader "Ryu/shWater_step_0"
{
    Properties
    {
        _Cube("cube map", Cube) = ""{}
        //큐브맵 형태로 저장되어있는 텍스처 데이터를 이용하겠다.
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0


        samplerCUBE _Cube;
        //큐브맵 형태의 텍스처 데이터

        struct Input
        {
            float2 uv_MainTex;
            float3 worldRefl;//<--반사 벡터 정보, 큐브맵을 이용하여 반사맵을 표현하기 위해 필요
            INTERNAL_DATA//<-- WorldReflectionVector를 사용하기 위해 표기
        };

        

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            //o.Albedo = c.rgb;
            //// Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            //o.Alpha = c.a;
            o.Normal = float3(0, 0, 1);
            float3 tReflectColor = texCUBE(_Cube, WorldReflectionVector(IN, o.Normal));


            o.Albedo = 0;
            o.Emission = tReflectColor;
            o.Alpha = 0.8;

        }
        ENDCG
    }
    FallBack "Diffuse"
}
