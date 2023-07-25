/*
    Alpha Blend를 제어하는 옵션을 살펴보자.

        SRCCOLOR * SrcAlpha + DSTCOLOR * OneMinusSrcAlpha

    Blend Factor를 살펴보자

    블렌딩 펙터의 종류

        One         1
        Zero        0

        SrcColr     소스의 컬러
        SrcAlpha    소스의 알파

        DstColr     배경의 컬러
        DstAlpha    배경의 알파

        OneMinusSrcColor    1 - 소스의 컬러
        OneMinusSrcAlpha    1 - 소스의 알파

        OneMinusDstColor    1 - 배경의 컬러
        OneMinusDstAlpha    1 - 배경의 컬러


    주요한 매뉴얼 추천 조합
        Blend SrcAlpha OneMinusSrcAlpha // AlphaBlending( Traditional transparency )

        Blend SrcAlpha One              //Additive
        Blend One One                   // Additive No Alpha, Black is Transparent
        
        Blend DstColor Zero // Multiplicative
        Blend DstColor SrcColor // 2x multiplicative



        이번 예시에서는

            Blend One One                   // Additive No Alpha, Black is Transparent

        이 블랜딩 조합을 보겠다.
*/
Shader "Ryu/shCustomAlphaBlend_2"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        zwrite off
        Blend One One
        //<--- SRCCOLOR * 1 + DSTCOLOR * 1 = SRCCOLOR * 1 + DSTCOLOR * 1
        //  이러한 경우 src의 컬러 색상이 검정색(0, 0, 0)이면 뒤에 배경이 온전히 보인다.
        //  그러므로 검정색상이 알파(투명도)의 역할을 하게 된다.
        //  <--- 알파 채널에 해당하는 메모리를 아낄 수 있다.

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert keepalpha noambient//Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

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

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            
            
            o.Albedo = c.rgb;
            o.Alpha = c.a;
            //o.Alpha = 0.5;
        }
        ENDCG
    }
    //FallBack "Diffuse"
    FallBack "Legacy Shaders/Transparent/VertexLit"
}
