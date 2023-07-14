Shader "Custom/shBuiltinBlinnPhong"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        
        //------------------------
        //정반사를 표현하기 위해 설정
        _SpecColor("spec color", Color) = (1, 1, 1, 1)
        //<--- built-in BlinnPhong조명모델에서 정반사광을 활성화시키려면
        //  이 변수를 프로퍼티 영역에 만든다
        //  프로퍼티 영역에만 만든다.
        //------------------------

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
        #pragma surface surf BlinnPhong//Standard fullforwardshadows
        //<-- built-in 램버트 조명모델을 사용하기 위해 셰이더 컴파일 옵션 지시자 수정
        /*
            고전적인 조명모델 중에 하나
            BlinnPhong조명모델: 난반사diffuse + 정반사 specular
        */

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

        //fixed4 _SpecColor;
        //여기도 선언하면 에러다

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

            //<-- built-in BlinnPhong 조명모델을 사용하기 위해 구조체 타입을 수정
        //void surf (Input IN, inout SurfaceOutputStandard o)
        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 c = _Color;
            o.Albedo = c.rgb;
            //------------------------
            //정반사를 표현하기 위해 설정
            o.Specular = 0.5;  //반사의 정도가 얼마냐
            o.Gloss = 1;        //광택의 정도는 얼마냐
            //------------------------
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
