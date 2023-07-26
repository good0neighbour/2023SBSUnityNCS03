/*
    Dissolve Effect

    서서히 타들어가는 효과


    i) main texture
    ii) 반투명 렌더 모드로 설정

    iii) Noise Texture( 불규칙한 패턴을 갖는 텍스처 이미지 데이터 )
    iv) 경계를 명확히 하여, 보이고 안 보이고의 영역을 분리한다. 알파블랜드


    v)경계를 좀더 크게 조정하여 더 넓은 범위를 확보한다
    vi) v)의 영역은 Emission으로 처리한다

    vii) 최종적으로는 Albedo, Emission, Alpha의 성분이 결합되어 dissolve효과를 만든다.
        Albedo <--물체의 원래 외관
        Emission <--타들어가는 가장자리
        Alpha <-- 보이는, 안 보이는(타들어가서 안 보이는) 영역 표현

*/

Shader "Ryu/shDissolve_step_2"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _NoiseTex ("noise texture", 2D) = "white" {}


        _EdgeCut("edge cut", Range(0, 1)) = 0.2
        //가장자리 타들어가는 부분의 너비와 색상
        _OutlineWidth("outline width", Range(1, 2)) = 1.9
        [HDR]_OutlineColor("outline color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Tranparent" "Queue"="Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade//Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _NoiseTex;    //노이즈(불규칙한 패턴) 정보를 위한 텍스쳐

        float _EdgeCut;
        //가장자리 타들어가는 부분의 너비와 색상
        float _OutlineWidth;
        float4 _OutlineColor;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NoiseTex; //노이즈 텍스처의 uv좌표 정보
        };

        

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;


            fixed4 tNoise = tex2D (_NoiseTex, IN.uv_NoiseTex);
            //불규칙 패턴의 노이즈 정보 얻기

            float tAlpha = 0;
            //tAlpha = step(0.2, tNoise.r);   //tNoise.r >= 0.2 ? 1 : 0
            tAlpha = step(_EdgeCut, tNoise.r);   //tNoise.r >= 0.2 ? 1 : 0
            //경계를 명확히 설정하여 알파값을 결정한다.

            o.Alpha = tAlpha;
            //o.Alpha = c.a;
            //o.Alpha = 0.5;

            //가장자리 경계의 타들어가는 부분
            //float tOutline = 1 - step(0.2 * 1.9, tNoise.r);   //tNoise.r >= 0.2 * 1.9 ? 1 : 0
            //o.Emission = tOutline * fixed3(1, 1, 1);

            float tOutline = 1 - step(_EdgeCut * _OutlineWidth, tNoise.r);   //tNoise.r >= 0.2 * 1.9 ? 1 : 0
            o.Emission = tOutline * _OutlineColor;

        }
        ENDCG
    }
    FallBack "Diffuse"
}
