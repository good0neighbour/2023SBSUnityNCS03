Shader "Ryu/sh2passblend"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Opaque" "Queue"="Transparent" }
        LOD 200



        //1pass
        zwrite on
        //<-- depth buffer에 깊이값 기록 켜기
        ColorMask 0
        //<-- color buffer에 픽셀값 가록을 끄기( 컬러 버퍼에 기록하지 않음, 렌더링하지 않음 )

        CGPROGRAM
        #pragma surface surf NoLight keepalpha noambient noforwardadd nolightmap novertexlights noshadow

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
        struct Input
        {
            float2 uv_MainTex;
        };
        void surf (Input IN, inout SurfaceOutput o)
        {
            //렌더링하지 않을 것이므로 색상연산 없음
        }
        float4 LightingNoLight(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
        {
            //렌더링하지 않을 것이므로 색상연산 없음
            return float4(0, 0, 0, 0);
        }
        ENDCG


        //첫번째 pass를 거치고 나면
        //depth buffer에 맨 앞에 있는 물체에 해당하는 깊이값만이 남게 된다.

        //아래의 두번째 pass에서는
        //깊이값을 갱신하지 않고 비교용으로 읽오반 올 것인데
        //이 때 깊이버퍼에는 맨 앞에 있는 깊이값만 있으므로
        //이 것보다 뒤에 있는 것은 아예 렌더링되지 않는다
        //  그러므로 색상이 혼합되지 않는다


        //2pass
        
        zwrite off
        //<-- depth buffer에 깊이값 기록 꺼버리기

        //정직하게 반투명으로 그리기
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade//Standard fullforwardshadows

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
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            
            o.Albedo = c.rgb;
            //o.Alpha = c.a;
            o.Alpha = 0.5;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
