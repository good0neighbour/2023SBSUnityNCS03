/*
    ���⼭�� BlinnPhong������� ������.

    blinnphong = ���ݻ籤 ����� + ���ݻ籤 ���� ��


*/
Shader "Ryu/shCustomBlinnPhong"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0

        _HighLightColour ("Specular Color", Color) = (1,1,1,1)

        _Glow ("Glow", Range(0,100)) = 30
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf RyuBlinnPhong//Standard fullforwardshadows

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

        fixed4 _HighLightColour;

        fixed _Glow;



        struct SurfaceOutputRyuBlinnPhong {
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

        void surf (Input IN, inout SurfaceOutputRyuBlinnPhong o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 c = _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }

        inline fixed4 LightingRyuBlinnPhong(SurfaceOutputRyuBlinnPhong s, fixed3 lightDir, half3 viewDir, fixed tAtten)
        {
            fixed4 tResult;

            //���ݻ籤 ���� ��
            //Lambert
            //<--���� �ϸ��� �ε巯�� ������ ��´�
            fixed tDot = dot(s.Normal, lightDir);
            fixed tDotResult = max(0, tDot); //[0, 1]�� ��


            //���ݻ籤 ���� �� specular
            //step_0
            //fixed tDotSpec = dot(s.Normal, lightDir);   //[-1, 1]
            //fixed tDotSpecResult = saturate(tDotSpec); //saturate���̴��Լ��� ���, [0, 1]�� ��
            //fixed tSpecular = pow(tDotSpecResult, 30);   //pow(x, y) x�� y��ŭ �ŵ������Ѵ�.
            //<-- 0���� 1���̿� ��ġ�� �ŵ������� ���� �۾�����.
            //  �̷��� ���� Ư¡�� �̿��Ͽ� ���� ���� �κ��� ����Ǵ� ������ ������ ���̴�.( ���߽�Ű�� ���̴� )

            //step_1
            //������ ���͸� �������� high light ȿ���� ����
            fixed3 tDir = normalize(lightDir + viewDir);  //normalize ������ ����ȭ ���̴� �Լ�
            fixed tDotSpec = dot(s.Normal, tDir);   //[-1, 1]
            fixed tDotSpecResult = saturate(tDotSpec); //saturate���̴��Լ��� ���, [0, 1]�� ��
            //fixed tSpecular = pow(tDotSpecResult, 30);   //pow(x, y) x�� y��ŭ �ŵ������Ѵ�.
            fixed tSpecular = pow(tDotSpecResult, _Glow);   //pow(x, y) x�� y��ŭ �ŵ������Ѵ�.


            //ǥ���� ���� ���ݻ� ���� ����, ������� ����
            //ǥ���� ���� ���ݻ� ���� ����, '���󵡼�' ����<--�� ������� �ϱ� ����
            //tResult.rgb = s.Albedo * tDotResult + tSpecular;
            //tResult.rgb = s.Albedo * tDotResult + tSpecular * fixed3(1, 1, 0);
            //<--���϶���Ʈ ������ ������ ����� �ν����Ϳ��� �Է¹��� �� �ְ� ���α׷� ������ �����غ�����.
            tResult.rgb = s.Albedo * tDotResult + tSpecular * _HighLightColour;

            tResult.a = s.Alpha;

            return tResult;
        }


        ENDCG
    }
    FallBack "Diffuse"
}
