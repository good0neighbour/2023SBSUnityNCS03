/*
    Texture : 이미지 참조 셰이딩에 사용하는 이미지 데이터

    UV좌표: 임의의 텍스쳐의 texel을 임의의 면에 임의의 지점에 대응시키기 위한 좌표정보
        <-- 정규화되어 있다.
		( 정규화의 이유: 크기가 제각각 모두 다른 텍스쳐를 일반화하여 다루기 위해서다 )

*/

Shader "Ryu/shUVAni"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _Amplitude ("sin amplitude", Range(0, 5)) = 1
        _Frequency ("sin frequency", Range(0, 5)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert//Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed _Amplitude;
        fixed _Frequency;
        

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //tex2D셰이더 함수: UV좌표를 참고하여, 텍스쳐 이미지 데이터에서 임의의 텍셀을 가져오는 함수<--샘플링sampling
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            //fixed4 c = tex2D (_MainTex, float2(IN.uv_MainTex.x + 0.5, IN.uv_MainTex.y + 0.5));

            //_Time은 응용프로그램의 시간의 흐름을 알려준다.
            //fixed4 c = tex2D (_MainTex, float2(IN.uv_MainTex.x + _Time.y, IN.uv_MainTex.y));
            //<-- UV animation기법 : UV 좌표값을 조작함으로써 텍스쳐를 애니메이션 시키는 것이다.

            fixed4 c = tex2D (_MainTex, float2(IN.uv_MainTex.x + _Amplitude * sin(_Time.y * _Frequency), IN.uv_MainTex.y));
            //sin함수의 결과는 [-1, 1]이다.
            //<-- 주기적으로 반복된다.

            o.Albedo = c.rgb;
            
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
