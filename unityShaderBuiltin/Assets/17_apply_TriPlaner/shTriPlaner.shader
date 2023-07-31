/*
    TriPlaner

    모델에 맞게 미리 만들어둔uv좌표 없이
    균일하게 텍스처를 매핑할 수 있는 uv 좌표를 만드는 기법이다.
    <-- 핵심은 World Position UV로 사용하는 것이다.

    <--삼면을 기준으로 한다.

*/
Shader "Ryu/shTriPlaner"
{
    Properties
    {
        _MainTexTopBottom ("top texture", 2D) = "white" {}

        _MainTexFrontBack ("top texture", 2D) = "white" {}

        _MainTexRtLt ("top texture", 2D) = "white" {}
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

        sampler2D _MainTexTopBottom;
        sampler2D _MainTexFrontBack;
        sampler2D _MainTexRtLt;

        struct Input
        {
            //float2 uv_MainTex;

            float3 worldPos;    //<--월드좌표계 기준의 정점의 위치 정보
            float3 worldNormal; //<--월드좌표계 기준의 법선벡터 정보
        };


        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //월드좌표계 기준에 정점 위치값을 UV값으로 사용한다`
            float2 tTopBottomUV = float2(IN.worldPos.x, IN.worldPos.z);
            float2 tFrontBackUV = float2(IN.worldPos.x, IN.worldPos.y);
            float2 tRtLtUV = float2(IN.worldPos.z, IN.worldPos.y);

            //이렇게 구한 UV좌표를 기반으로 각각의 위치에 해당하는 정점에 텍셀정보를 얻는다.
            fixed4 tColorTB = tex2D (_MainTexTopBottom, tTopBottomUV);
            fixed4 tColorFB = tex2D (_MainTexFrontBack, tFrontBackUV);
            fixed4 tColorRL = tex2D (_MainTexRtLt, tRtLtUV);

            //각각에 면이 속한 평면을 얻기 위해 법선벡터의 해당하는 성분을 곱셈하고(마스킹masking)
            //각각 구한 텍셀을 더해
            //각각에 면에 알맞는 색상 정보를 최종적으로 계산하였다.
            fixed4 c = tColorTB * abs(IN.worldNormal.y) + tColorFB * abs(IN.worldNormal.z) + tColorRL * abs(IN.worldNormal.x);

            //fixed4 c = tex2D (_MainTexTopBottom, tTopBottomUV);

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
