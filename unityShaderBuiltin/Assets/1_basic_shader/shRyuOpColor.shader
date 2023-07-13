/*

    컴퓨터의 정수 표현
    :컴퓨터는 정수를 어떻게 표현하는가?

	'수'란 무엇인가?
        <--추상화된 개념적인 그 무엇

	숫자
        <-- '수'라는 개념을 표현(표기)하는 문자(기호)

    위치기수법
        기수에 따라 자리(위치)바꿈을 통해
        수를 숫자를 이용하여 표기하는 방법

    기수
        위치기수법에서 자리바꿈의
        기준이 되는 수

    예) 112
    112 = 10^2 * 1 + 10^1 * 1 + 10^0 * 2
    <--십진 위치기수법에서 해당 수를 분해해본 것


    사람은 손가락이 열개이므로( 카운팅 수단 ) 십진법을 편리하게 느껴 주로 사용한다.

    컴퓨터: 원래 태생이 계산기(수의 연산의 결과를 얻는 기계장치)이다.
    <-- 수라는 개념을 다뤄야 한다.( 머리가 없는데 수를 다뤄? )
    <-- '거꾸로 발상'하여 '숫자표기를 컴퓨터가 다룰 수 있게 한다면' 곧 그것이 '수를 다루는 것'이다.

    ---> 그렇다면, 컴퓨터가 숫자표기를 다룰 수 있게 하려면 어떻게 해야할까?( 손가락이 없는데? )

    컴퓨터는 손가락이 없지만
    전기의 on/off 동작이 있다.
    --->그렇다면 2를 기수로 하는 이진법 체계를 사용하면 (숫자 표기를 다루므로) 수를 다룰 수 있다.


    <-- 컴퓨터는 비트bit를 이용하여 이진수표기를 사용하여 정수를 표현가능하다.


    컴퓨터의 실수 표현

        고정(fixed) 소수점 표현
        <--소수점 위치가 고정되어 있는 표기법

        <--
            장점: 수를 해석하는데 들어가는 연산이 비교적 적다.
                왜냐하면, 각각의 정수부, 소수점 이하부, 부호비트를 담당하는 비트를 그냥 그대로 해석하기 때문이다.
            단점: 정해진 비트를 그냥 그대로 해석하므로
                정밀도가 낮다.

        
        부동(floating) 소수점 표현
        <--소수점 위치가 고정되어 있지 않은 표기법




        이번 예시에서는 색상연산을 살펴보자
*/
Shader "Ryu/shRyuOpColor"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard noambient noshadow//fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            //float2 uv_MainTex;
            fixed4 mColor : Color;
            //시맨틱semantic: 해당 데이터가 렌더링 파이프라인에서 그 용도가 무엇인지 의도를 밝히는 것이다.
            //일종의 용도 꼬리표
        };

        //half _Glossiness;
        //half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            //o.Albedo = c.rgb;
            //// Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            //o.Alpha = c.a;

            fixed4 c = _Color;

            //색상 연산
            //<--빛의 삼원색, 즉 가산혼합이 기본

            //step_0 swizzle
            //o.Emission = c.rgb;
            //o.Emission = c.bgr;
            //o.Emission = c.brg;
            //o.Emission = c.rrr;
            //o.Emission = c.ggg;

            //step_1 덧셈
            // //각각의 구성성분끼리 더한다.
            //o.Emission = fixed3(0.0f, 0.1f, 0.5f);
            //o.Emission = fixed3(1.0f, 0.0f, 0.0f) + fixed3(0.0f, 1.0f, 0.0f);
            //o.Emission = fixed3(1.0f, 0.0f, 0.0f) + fixed3(0.5f, 0.5f, 0.0f);
            //<--(1.5, 0.5, 0) 수치는 남아있지만 최종적으로 출력은 정규화되어 출력되므로
            //(1, 0.5, 0)으로 색상이 출력된다.

            //step_2 곱셈
            //각각의 구성성분끼리 곱한다.
            //o.Emission = fixed3(1.0f, 0.0f, 0.0f) * fixed3(0.0f, 0.0f, 0.0f);
            //o.Emission = fixed3(1.0f, 0.0f, 0.0f) * fixed3(0.0f, 1.0f, 0.0f);
            o.Emission = fixed3(0.5f, 0.5f, 0.0f) * fixed3(0.2f, 1.0f, 0.0f);
            //<-- (0.1, 0.5, 0)


        }
        ENDCG
    }
    FallBack "Diffuse"
}
