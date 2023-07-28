/*
    step_1

    물은 '프레넬 효과'의 관찰이 용이한 매질이다.

    프레넬 효과: 문체의 매질에 따라 반사율, 굴절울이 모두 달라서 나타나는 현상
    <-- 관찰자의 시선벡터와 반사벡터의 각도에 따라 반사와 굴절이 일어나는 현상

    물같은 경우 가장자리로 갈 수록 완전반사되는 특징이 있다.
    중심으로 올 수록 반사가 일어나지 않는다

    이것은 림라이트 효과와 매우 유사하다.

    그러므로 여기서는
    림라이트를 만들어
    프레넬 효과를 적용하자.

    

*/
Shader "Ryu/shWater_step_1"
{
    Properties
    {
        _Cube("cube map", Cube) = ""{}
        //큐브맵 형태로 저장되어있는 텍스처 데이터를 이용하겠다.

        //노말맵 이용
        _BumpMap("Normal Map", 2D) = "bump"{}
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0


        samplerCUBE _Cube;
        //큐브맵 형태의 텍스처 데이터

        sampler2D _BumpMap;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;//노멀맵의 UV좌표 정보

            float3 viewDir;
            //<--시선벡터

            float3 worldRefl;//<--반사 벡터 정보, 큐브맵을 이용하여 반사맵을 표현하기 위해 필요
            INTERNAL_DATA//<-- WorldReflectionVector를 사용하기 위해 표기
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
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            //o.Albedo = c.rgb;
            //// Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            //o.Alpha = c.a;

            //반사를 만듦
            //텍셀을 샘플링하고, 접선공간 변환을 적용
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            //o.Normal = float3(0, 0, 1);
            float3 tReflectColor = texCUBE(_Cube, WorldReflectionVector(IN, o.Normal));


            //o.Albedo = 0;
            //o.Emission = tReflectColor;
            //o.Alpha = 0.8;
            
            //프레넬 효과를 적용(림라이트)
            float tRim = saturate(dot(o.Normal, IN.viewDir));
            tRim = 1 - tRim;

            o.Albedo = 0;
            o.Emission = pow(tRim, 3);
            o.Alpha = 1;//0.8;

        }
        ENDCG
    }
    FallBack "Diffuse"
}
