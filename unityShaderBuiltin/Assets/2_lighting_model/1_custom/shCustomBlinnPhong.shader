/*
    여기서는 BlinnPhong조명모델을 만들어보자.

    blinnphong = 난반사광 조명모델 + 정반사광 조명 모델


*/
Shader "Ryu/shCustomBlinnPhong"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0

        _HighLightColour ("Specular Color", Color) = (1,1,1,1)

        _Glow ("Glow", Range(0,100)) = 30
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf RyuBlinnPhong//Standard fullforwardshadows

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

        fixed4 _HighLightColour;

        fixed _Glow;



        struct SurfaceOutputRyuBlinnPhong {
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

        void surf (Input IN, inout SurfaceOutputRyuBlinnPhong o)
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

        inline fixed4 LightingRyuBlinnPhong(SurfaceOutputRyuBlinnPhong s, fixed3 lightDir, half3 viewDir, fixed tAtten)
        {
            fixed4 tResult;

            //난반사광 조명 모델
            //Lambert
            //<--좀더 완만한 부드러운 음영을 얻는다
            fixed tDot = dot(s.Normal, lightDir);
            fixed tDotResult = max(0, tDot); //[0, 1]의 값


            //정반사광 조명 모델 specular
            //step_0
            //fixed tDotSpec = dot(s.Normal, lightDir);   //[-1, 1]
            //fixed tDotSpecResult = saturate(tDotSpec); //saturate셰이더함수를 사용, [0, 1]의 값
            //fixed tSpecular = pow(tDotSpecResult, 30);   //pow(x, y) x를 y만큼 거듭제곱한다.
            //<-- 0에서 1사이에 수치는 거듭제곱할 수록 작아진다.
            //  이로한 수의 특징을 이용하여 밝은 음영 부분이 적용되는 영역을 좁히는 것이다.( 집중시키는 것이다 )

            //step_1
            //임의의 벡터를 기준으로 high light 효과를 생성
            fixed3 tDir = normalize(lightDir + viewDir);  //normalize 벡터의 정규화 셰이더 함수
            fixed tDotSpec = dot(s.Normal, tDir);   //[-1, 1]
            fixed tDotSpecResult = saturate(tDotSpec); //saturate셰이더함수를 사용, [0, 1]의 값
            //fixed tSpecular = pow(tDotSpecResult, 30);   //pow(x, y) x를 y만큼 거듭제곱한다.
            fixed tSpecular = pow(tDotSpecResult, _Glow);   //pow(x, y) x를 y만큼 거듭제곱한다.


            //표면의 색상에 난반사 조명도 적용, 색상곱셈 연산
            //표면의 색상에 정반사 조명도 적용, '색상덧셈' 연산<--더 밝아지게 하기 위해
            //tResult.rgb = s.Albedo * tDotResult + tSpecular;
            //tResult.rgb = s.Albedo * tDotResult + tSpecular * fixed3(1, 1, 0);
            //<--하일라이트 색상을 변수로 만들어 인스펙터에서 입력받을 수 있게 프로그램 구조를 변경해보세요.
            tResult.rgb = s.Albedo * tDotResult + tSpecular * _HighLightColour;

            tResult.a = s.Alpha;

            return tResult;
        }


        ENDCG
    }
    FallBack "Diffuse"
}
