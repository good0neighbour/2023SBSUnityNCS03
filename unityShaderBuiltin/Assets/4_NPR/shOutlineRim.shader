Shader "Ryu/shOutlineRim"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0

        _OutlineWidth ("outline width", Range(0.09, 0.9)) = 0.3
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200


        //아무것도 명시되어있지 않으면 후면컬링이 기본이다.
        //Cull back   //후면 컬링
        //Cull front   //전면 컬링
        Cull off   //컬링 끔, 전면 후면 모두 렌더링 two sided rendering

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf RyuOutlineRim noambient//Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        //half _Glossiness;
        //half _Metallic;
        fixed4 _Color;

        fixed _OutlineWidth;


        struct SurfaceOutputRyuOutlineRim {
            fixed3 Albedo;
            fixed3 Normal;
            fixed3 Emission;
            half Specular;
            fixed Gloss;
            fixed Alpha;
        };

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        //void surf (Input IN, inout SurfaceOutputStandard o)
        void surf (Input IN, inout SurfaceOutputRyuOutlineRim o)
        {
            fixed4 c = _Color;
            o.Albedo = c.rgb;
            
            o.Alpha = c.a;
        }
        //custom lighting model
        float4 LightingRyuOutlineRim(SurfaceOutputRyuOutlineRim s, float3 lightDir, float3 viewDir, float atten)
        {
            float4 tResult = float4(0, 0, 0, 1);


            float tDot = dot(s.Normal, viewDir);
            //float tDotResult = saturate(tDot);//[0, 1]
            float tDotResult = abs(tDot);//[0, 1] <-- saturate를 썼을 때와 다른 결과다.
            //예를 들면,
            //반대쪽을 바라보는 면의 경우 saturate를 사용한 경우 0이 나오지만
            //abs를 쓴 경우는 1이 나온다.
            //전자의 경우 1 - 0 = 1
            //후자의 경우 1 - 1 = 0
            //<--림라이트는 가장자리를 밝게 빛나게 하려는 것이므로 후자의 경우가 옳다
            //림라이트에 해당하는 광량 수치를 구한다.
            //float tRim = 1 - tDotResult;

            //외곽선의 경계를 명확하게 하기 위해
            //판단제어구조가 필요하다
            //<--판단제어구조는 셰이더에 적합하지 않으므로 step함수를 사용하겠다.
            float tOutlineResult = step(_OutlineWidth, tDotResult);  //tDotResult >= _OutlineWidth ? 1 : 0

            tResult.rgb = s.Albedo * tOutlineResult;    //tOutlineResult가 1이면 그냥 색상, 0이면 검정색상
            tResult.a = s.Alpha;


            return tResult;
        }



        ENDCG
    }
    FallBack "Diffuse"
}
