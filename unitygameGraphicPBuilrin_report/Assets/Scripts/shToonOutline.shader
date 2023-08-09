Shader "Custom/shToonOutline"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _ShadowLevel ("ShadowLevel", Range(0,10)) = 5
        _OutlineColour ("OutlineColour", Color) = (0,0,0,1)
        _OutlineWidth ("OutlineWidth", Range(0,1)) = 0.6
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf ToonShade noshadow noambient

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _OutlineColour;
        fixed _ShadowLevel;
        fixed _OutlineWidth;

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
            o.Alpha = c.a;
        }

        fixed4 LightingToonShade(SurfaceOutput s, fixed3 tLightDir, fixed3 tViewDir, fixed tAtten)
        {
            fixed4 tResult;

            fixed tOutlineArea = step(_OutlineWidth, 1 - dot(tViewDir, s.Normal));

            // 검정 림라이트를 적용하기 위해 림라이트 영역이 아닐 때만 Albedo 적용
            tResult.rgb = s.Albedo * ceil(_ShadowLevel * dot(tLightDir, s.Normal)) / _ShadowLevel * (1 - tOutlineArea)
                + tOutlineArea * _OutlineColour.rgb;
            tResult.a = s.Alpha;

            return tResult;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
