Shader "Ryu/shTwinkle"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _MaskTex ("mask tex", 2D) = "white" {}
        //'임의의 부위만 선별하기 위한 데이터'로서의 텍스쳐
        _RampTex ("mask tex", 2D) = "white" {}
        //'불규칙적인 주기를 가지는 신호용 데이터' 용도로서의 텍스쳐

        //<--색상도 수치다. 그러므로 임의의 데이터 용도로 사용가능하다.

        _Frequency("frequency", Range(0.03, 2)) = 0.09
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

        sampler2D _MainTex;
        sampler2D _MaskTex;
        //'임의의 부위만 선별하기 위한 데이터'로서의 텍스쳐
        sampler2D _RampTex;
        //'불규칙적인 주기를 가지는 신호용 데이터' 용도로서의 텍스쳐

        float _Frequency;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MaskTex;  //<--_MaskTex를 위한 uv 좌표정보
        };

        

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 tMask = tex2D (_MaskTex, IN.uv_MaskTex);
            //임의의 부위 선별 데이터

            fixed4 tFrequency = tex2D (_RampTex, float2(_Time.y * _Frequency, 0.5));
            //불규칙적인 주기적 데이터

            o.Albedo = c.rgb;
            
            o.Emission = c.rgb * tMask.r * 0.5, tFrequency.r;
            //눈 형태는 그대로 유지되어야 하므로 c.rgb
            //임의의 부위에 불규칙적인 주기로 깜빡임(반짝임) 적용

            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
