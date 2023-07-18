/*

    이번 예시에서는 Rim Light의 개념을 살펴보도록 하자.

        또한
        프레넬 효과(Fresnel Effect)에 대해서도 살펴보자.


    --Rim Light: 물체의 가장가지를 따라 경계가 밝게 빛나는 조명 '효과'--
        프레넬 효과(Fresnel Effect): 물체의 '매질'에 따라 '반사율', '굴절율' 등이 달라 일어나는 현상

        <-- rim light는 프레넬 효과에 의해 일어난다고 볼 수 있다.


        <--림라이트를 구현하면 즉, 프레넬 효과의 '결과'를 만든 것이다.

*/
Shader "Custom/shRimLight"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0

        _RimWidth ("rim width", Range(0,10)) = 4.5

        [HDR]_RimColor ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //sampler2D _MainTex;

        //랜더링 파이프라인에서 전달받은 데이터를 선언하여 정의한다.
        struct Input
        {
            //float2 uv_MainTex;
            float3 viewDir; //렌더링 파이프라인에서 전달받은 '시선벡터(카메라벡터)'
        };

        //half _Glossiness;
        //half _Metallic;
        fixed4 _Color;

        fixed _RimWidth;
        fixed4 _RimColor;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //관찰자<--카메라
            //step_0
            //N dot V   법선벡터 dot 시선벡터
            //fixed tDot = dot(o.Normal, IN.viewDir);
            //fixed tDotResult = saturate(tDot);//[0, 1]

            //step_1
            //fixed tDot = dot(o.Normal, IN.viewDir);
            //fixed tDotResult = saturate(tDot);//[0, 1]
            //fixed tRim = 1 - tDotResult;

            //step_2
            fixed tDot = dot(o.Normal, IN.viewDir);
            fixed tDotResult = saturate(tDot);//[0, 1]
            fixed tRim = 1 - tDotResult;
            fixed tRimLight = pow(tRim, _RimWidth);    //거듭제곱하여 영역을 좁힌다.


            fixed4 c = _Color;
            o.Albedo = c.rgb;
            
            o.Emission = tRimLight * _RimColor;    //밝게 빛나는, 림라이트 색상도 적용( 색상곱셈연산 )

            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
