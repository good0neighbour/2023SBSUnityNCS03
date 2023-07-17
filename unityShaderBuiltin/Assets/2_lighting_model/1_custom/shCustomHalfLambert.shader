/*
    i) surface shader에서 물리기반 엔더링에서 Custom Light 모델을 만드는 방법을 살펴보자
        <-- surface shader는 조명 모델이랑 연동해서 같이 작동하는 셰이더

        가) 사용할 구조체의 정의를 선언

        나) 커스텀 라이트 함수의 정의를 만든다

        다) 셰이더 컴파일 옵션 지시자에 커스텀 라이트 함수 사용을 지시한다


    ii) Lambert 조명 모델
    : 법선 벡터와 조명벡터의 내적을 이용하여 광량을 결정하는 조명모델

        N dot L

        Normal Vector
        Light Vector

    ii) 몇 가지 셰이더 함수 살펴보기


    iv) 셰이더 코드에서는 판단제어구조를 지양한다( 되도록 쓰지 않도록 한다 )
    <-- 왜냐하면, GPU는 CPU와 달리 범용적인 명령어 처리 프로세서가 아니기 때문이다.
        그래서 분기가 들어간 코드의 실행에 적합하지 않다

        CPU: '명령어'를 처리하기 위해 만들어진 범용적인 프로세서
        GPU: 단위시간당 데이터를 대량으로 처리하기 위해 만들어진 특수화된 프로세서

*/

Shader "Ryu/shCustomHalfLambert"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        //#pragma surface surf RyuLambert//Standard fullforwardshadows
        #pragma surface surf RyuHalfLambert
        //<----custom light model을 명시해준다.

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


        struct SurfaceOutputRyuLambert
        {
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
        //<---- 구조체 형식을 맞춰준다
        void surf (Input IN, inout SurfaceOutputRyuLambert o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 c = _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        

        //custom lighting model
        //조명 모델 함수: 조명(빛)에 대한 처리를 수행하는 셰이더 함수의 정의
        //Lighting~ 형태로 이름을 맞추어야 한다.
        //<--매뉴얼에 제작방법이 있으므로 살펴보고 맞추면 된다.
        //lightDir: 조명벡터    <-- 유니티엔진이 뒤집어서 넣어준다
        //viewDir: 시선벡터     <-- 유니티엔진이 뒤집어서 넣어준다
        //tAtten: 감쇄
        inline fixed4 LightingRyuHalfLambert(SurfaceOutputRyuLambert s, fixed3 lightDir, half3 viewDir, fixed tAtten)
        {
            fixed4 tResult;
            //Half Lambert (N dot L) * 0.5 + 0.5
            //<--좀더 완만한 부드러운 음영을 얻는다
            fixed tDot = dot(s.Normal, lightDir) * 0.5 + 0.5;//N dot L  [-1, 1]의 값 ---> [-0.5, 0.5] ---> [0, 1]
            
            //fixed tDotResult = max(0, tDot); //[0, 1]의 값

            tResult.rgb = s.Albedo * tDot;  //표면의 색상에 조명도 적용, 색상곱셈 연산
            tResult.a = s.Alpha;

            return tResult;
        }




        ENDCG
    }
    FallBack "Diffuse"
}
