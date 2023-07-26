/*
    vertex animation예시를 살펴보자

        풀이 '단순한 반복적인 패턴의 움직임'을 보이며 흔들림
        바다가 '단순한 반복적인 패턴의 움직임'을 보이며 출렁임
        <-- 이런 움직임이라면 vertex animation이 효율적으로 적용될 수 있다.


    i) 이번 스텝에서는 일파 테스트를 적용하자

        기준값 0.5라고 가정하면

        0.7 <--- 표시
        0.5 <--- 표시
        0.3 <--- 표시 안함

    ii) vertex animation을 수행하자.
*/
Shader "Ryu/shVertexAni_step_1"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _Cutoff("cut off", float) = 0.5 //알파테스트를 위한 기준값


        _Amplitude("amplitude", Range(0.1, 2)) = 0.5
        _Frequency("frequency", Range(0.2, 7)) = 5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alphatest:_Cutoff vertex:DoVert
        //<-- 알파테스트를 위해 셰이더 컴파일 옵션 지시자 설정
        //<--vertex shader함수를 사용하기 위해 셰이더 컴파일 옵션 지시자 설정

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        float _Amplitude;
        float _Frequency;

        struct Input
        {
            float2 uv_MainTex;
        };

        

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)


        float random (float2 uv)
        {
            return frac(sin(dot(uv,float2(12.9898,78.233)))*43758.5453123);
            //frac 셰이더 함수
            //<-- 주어진 수에 소수점 이하 값만 취한다. (0, 1)
        }

        void DoVert(inout appdata_full v)
        {
            //vertex animation 정점 애니메이션
            //v.vertex.y += sin(_Time.y);   //반복적인 패턴의 움직임
            //v.vertex.y += 0.5 * sin(_Time.y); //진폭조정<--움직임의 크기 조정
            //v.vertex.y += sin(_Time.y * 5); //진폭조정<--움직임의 빠르기

            //v.vertex.y += 0.5 * sin(_Time.y * 5) * random(v.texcoord); //
            v.vertex.y += _Amplitude * sin(_Time.y * _Frequency) * random(v.texcoord); //
        }


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
