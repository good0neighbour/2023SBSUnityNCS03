/*

    Opaque

    Depth Buffer 알고리즘으로
    아주 정직하게
    픽셀의 색상을 칠할 때

    overdraw(덧그리기) 현상이 발생한다
    <--이미 칠한 픽셀을 다시 또 칠하는 현상

    불투명한 물체의 경우
    어차피 가려지는 부분은 맨 앞에 있는 물체의 픽셀로 결정될 것이므로
    아예 불투명 렌더큐에

    앞 ----> 뒤

    순서로 정렬되어 넣어진다
    그러면 overdraw현상이 일어나지 않는다

    그러므로
    불투명 물체는
    앞 ----> 뒤
    로 정렬되어 있다.
*/

Shader "Ryu/shOpaque"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }//<-- 불투명한 물체를 랜더링하는 모드 옵션
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

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
        }
        ENDCG
    }
    FallBack "Diffuse"
}
