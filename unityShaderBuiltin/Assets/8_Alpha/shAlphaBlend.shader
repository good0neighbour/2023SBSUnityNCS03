/*
    AlphaBlend

    반투명한 물체끼리는

    뒤 -----> 앞

    으로 정렬되어 있어야만

    뒤에있는 물체가 비치는 반투명 효과를 낼 수 있다.

    만약 앞에 있는 것을 먼저 그린다면
    Depth-Buffer알고리즘에 의해 뒤에 있는 물체를 그릴 수 없다.
    그러므로 당연히

    뒤 -----> 앞

    으로 정렬되어야만 한다.

    이것을 Alpha Sorting이라고 한다.


     불투명한 물체를 렌더링하는 것과 비교해보았을 때
     픽셀의 색상 혼합연산( 덧그리기가 일어나며 )이 일어나므로
     당연히 알파 블랜드가 연산이 많아 불리하다.


     연산량 비교

     PC:    불투명 < 알파테스트 < 알파블랜드

     mobile: 불투명 < 알파블랜드 < 알파테스트
        <--- 모바일 디바이스에 타일 형태의 텍스처 처리 방식 때문에( 타일 단위로 처리하고 나서 작업을 바꾸는데 드는 연산이 더 많아서 ) 알파테스트가 훨씬 연산이 많다고 한다.

        <-- 뇌피셜. 추정컨데 모바일의 경우 타일 단위로 쪼개기 때문에 알파테스트는 기본적으로 분기므로
        분기 * 타일개수의 분기가 만들어진다.
        그래픽 처리장치는 분기연산에 부하가 많이 걸린다.
        그러므로 모바일 기기에서 알파테스트가 훨씬 연산이 많이 드는 것이 아닌가 추정한다.
*/
Shader "Ryu/shAlphaBlend"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        //렌더모드는 Transparent
        //렌더큐는 Transparent
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha:fade
        //<--반투명 중 Fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        
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
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            
            o.Alpha = c.a;
            //o.Alpha = 0.5;//c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
    FallBack "Legacy Shaders/Transparent/VertexLit"
}
