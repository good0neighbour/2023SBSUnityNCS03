/*
    다음은 유니티에서 지원하는 surface shader예시 코드다.

    surface shader는
    built-in render pipeline에서 지원하는 shader 형식이다.



    surface shader의 프로그램 구조는
    ShaderLab + CG
    로 이루어진다.


    ShaderLab <--유니티에서 자체적으로 만든 셰이더 프로그래밍 언어
    <-- 하지만 거의 도태되었고, built-in renderpipeline에 셰이더 프로그램의 기본구조를 제공하는데 정도만 쓰인다.

    셰이더 프로그래밍 언어의 종류
    Opengl <-- glsl
    DirectX <-- hlsl
    엔비디아 <--cg

*/
//전체 구조는 shaderlab 언어로 만들어져있다.
Shader "Ryu/shRyuStandard"
{
    //Properties 유니티 인스펙터 상에 노출될 변수를 지정하는 것이다.
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        //<--_Color는 소스코드 상에서 쓰일 변수의 이름
        //<-- "Color"는 유니티 인스펙터 상에 노출될 문자열
        //<-- Color는 shaderlab문법 상의 타입
        //<-- (1, 1, 1, 1) 는 초기값
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
    }
    //SubShader 셰이딩을 수행하는 셰이더 프로그램 동작 부분(명령문의 집합)이다.
    SubShader
    {
        Tags { "RenderType"="Opaque" } //<--불튜명 옵션으로 렌더링 설정
        LOD 200 //<-- LOD Level Of Detail 거리에 따른 디테일 수준

        
        CGPROGRAM//<-- 여기서부터는 cg문법이다.
        //셰이더 컴파일 옵션 지정
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows
            //<--Standard조명모델사용, 모든 조명에 대한 그림자 가능 옵션으로 컴파일
            //<-- surface shader의 함수는 surf로 설정

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //-----ShaderLab에서 만든 변수 이름과 CG블럭의 변수 이름은 '동일하게 맞춰야 한다.'
        //sampler2D _MainTex;

        struct Input
        {
            //UV좌표( 텍스쳐 좌표 )
            //텍셀을 임의의 표면에 픽셀로 취할 때
            //임의의 이미지의 어느 텍셀을 취할지 좌표로 참고하는데
            //이미지마다 모두 크기(너비, 높이)가 다르므로 좌표가 모두 달라지는 문제가 있다.
            //이를 해결하기 위해
            //정규화된 형식으로 좌표를 다룬다.
            //이러한 좌표계를 UV좌표계라고 한다.

            float2 uv_MainTex;  //float 부동 소수, 뒤에 적인 숫자는 데이터의 개수
        };

        //float 4byte( 32bit )

        //half _Glossiness;   //half 2byte( 16bit )
        //half _Metallic;
        fixed4 _Color;      //fixed 고정 소수점 형식 표기, 뒤에 적인 숫자는 데이터의 개수

        //fixed 11byte

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        //inout 입력과 출력을 동시에 담당하는 변수임을 나타낸다.
        //SurfaceOutputStandard <--표면이 어떻게 구성되어 있는지에 대한 구조체<--유니티에서 정의해두었다.
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            //_Color <-- 인스펙터에서 입력력받은 물체의 색상값
            //_MainTex <--인스펙터에서 입력받은 텍스쳐 데이터
            //  임의의 텍셀을 샘플링하여 가져온다.(텍셀Texel 택스처의 픽셀<--색상정보)
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 c = _Color;
            //<--텍스처의 색상과 물체의 색상을 결합

            o.Albedo = c.rgb;//<--색상의 swizzle 연산
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            o.Alpha = c.a;
            //<--이렇게 완성된 o는 렌더링 파이프 라인의 다음 단계로 전달된다.
        }
        ENDCG//<-- 여기까지 위가 cg문법이다.

    }
    FallBack "Diffuse"
    //Fallback<-- subshader가 동작하지 않으면 최후의 수단으로 이 셰이더를 수행하겠다.
}
