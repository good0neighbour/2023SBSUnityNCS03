/*

    굴절refraction 현상을 흉내내어보자

*/
Shader "Ryu/shRefraction_step_3"
{
    Properties
    {
        _RefractionTex("Refraction Texture", 2D) = "white"{}
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        GrabPass{} //<--스크린 화면 캡춰 명령문

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf NoLight noambient alpha:fade//Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _RefractionTex;

        sampler2D _GrabTexture; //<-- GrabPass한 데이터는 이 텍스쳐에 담긴다

        struct Input
        {
            float2 uv_MainTex;
            float4 screenPos;   //<--스크린(전체화면, 2D)의 좌표를 얻어온다.
        };


        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            //o.Emission = IN.screenPos.rgb; //스크린의 좌표를 관찰하기 위해 색상값으로 다뤄보았다.
            //색상도 수치
            //스크린 좌표도 수치
            //<-- 모두 수라는 것이 공통점


            float4 tRyu = tex2D(_RefractionTex, IN.uv_MainTex);
            //<-- uv animation의 수치 재료로서 임의의 텍스처 이미지 데이터를 사용

            float3 tScreenUV = IN.screenPos.rgb;
            o.Emission = tex2D(_GrabTexture, tScreenUV.xy + tRyu.x * sin(_Time.y) * 0.1);
            //반복적인 패턴의 움직임, 시간의 흐름에 따라 uv animation
        }
        //custom light model
        float4 LightingNoLight(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
        {
            return float4(0, 0, 0, 1);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
