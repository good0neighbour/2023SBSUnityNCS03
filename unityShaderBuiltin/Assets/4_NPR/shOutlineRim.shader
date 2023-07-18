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


        //�ƹ��͵� ��õǾ����� ������ �ĸ��ø��� �⺻�̴�.
        //Cull back   //�ĸ� �ø�
        //Cull front   //���� �ø�
        Cull off   //�ø� ��, ���� �ĸ� ��� ������ two sided rendering

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
            float tDotResult = abs(tDot);//[0, 1] <-- saturate�� ���� ���� �ٸ� �����.
            //���� ���,
            //�ݴ����� �ٶ󺸴� ���� ��� saturate�� ����� ��� 0�� ��������
            //abs�� �� ���� 1�� ���´�.
            //������ ��� 1 - 0 = 1
            //������ ��� 1 - 1 = 0
            //<--������Ʈ�� �����ڸ��� ��� ������ �Ϸ��� ���̹Ƿ� ������ ��찡 �Ǵ�
            //������Ʈ�� �ش��ϴ� ���� ��ġ�� ���Ѵ�.
            //float tRim = 1 - tDotResult;

            //�ܰ����� ��踦 ��Ȯ�ϰ� �ϱ� ����
            //�Ǵ�������� �ʿ��ϴ�
            //<--�Ǵ�������� ���̴��� �������� �����Ƿ� step�Լ��� ����ϰڴ�.
            float tOutlineResult = step(_OutlineWidth, tDotResult);  //tDotResult >= _OutlineWidth ? 1 : 0

            tResult.rgb = s.Albedo * tOutlineResult;    //tOutlineResult�� 1�̸� �׳� ����, 0�̸� ��������
            tResult.a = s.Alpha;


            return tResult;
        }



        ENDCG
    }
    FallBack "Diffuse"
}
