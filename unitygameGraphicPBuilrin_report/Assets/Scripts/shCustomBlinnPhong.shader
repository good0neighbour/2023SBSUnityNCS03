Shader "Custom/shCustomBlinnPhong"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Glow ("Glow", Range(0,100)) = 50
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf CustomBlinnPhong noabient noshadow

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _Color;
        fixed _Glow;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color.rgb;
            o.Alpha = _Color.a;
        }

        fixed4 LightingCustomBlinnPhong(SurfaceOutput s, fixed3 tLightDir, fixed3 tViewDir, fixed tAtten)
        {
            fixed4 tResult;

            tResult.rgb = s.Albedo * dot(tLightDir, s.Normal)
                + pow(saturate(dot(normalize(tLightDir + tViewDir), s.Normal)), _Glow);
            tResult.a = s.Alpha;

            return tResult;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
