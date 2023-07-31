/*
    step_3

    물이 흘러가는 느낌(일렁이는 느낌)이 들도록 하겠다.

    이를 위해서 법선데이터를 조작한다.
    <--uv animation
    
*/
Shader "Ryu/shWater_step_3"
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

            //정지되어 있는 느낌
            //o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            
            //한쪽으로 흐르는 느낌
            //o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap + _Time.x * 0.1));
            //<--- uv animation을 normal map에 적용하여 법선데이터를 조작
            //  <-- 무한 스크롤 알고리즘의 저글링 동작이 법선에 대해 일어나고 있는 것으로 봐도 된다.
            
            //보정
            float3 tNormal_0 = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap + _Time.x * 0.1));
            float3 tNormal_1 = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap - _Time.x * 0.1));
            o.Normal = (tNormal_0 + tNormal_1) / 2;
            //서로 반대방향으로 흐르도록?하고 이 두 벡터를 더해 보정
            //<-- a물결이 일렁이는 느낌을 내고 있다.


            //o.Normal = float3(0, 0, 1);
            float3 tReflectColor = texCUBE(_Cube, WorldReflectionVector(IN, o.Normal));


            //o.Albedo = 0;
            //o.Emission = tReflectColor;
            //o.Alpha = 0.8;
            
            //프레넬 효과를 적용(림라이트)
            float tRim = saturate(dot(o.Normal, IN.viewDir));
            tRim = 1 - tRim;
            tRim = pow(tRim, 1.5);

            o.Albedo = 0;
            o.Emission = tReflectColor * tRim * 1.2; //반사와 프레넬(림라이트)를 결합
            o.Alpha = saturate(tRim + 0.5);
            //<-- 수치조정, 수치범위제한
            //이를 통해 물의 가장자리로 갈수록 완전반사하여 ( 투명하지 않도록 하여 )
            //물밑이 비치지 않도록 강조하고 있다.

        }
        ENDCG
    }
    FallBack "Diffuse"
}
