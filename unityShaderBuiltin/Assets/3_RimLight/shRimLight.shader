/*

    �̹� ���ÿ����� Rim Light�� ������ ���캸���� ����.

        ����
        ������ ȿ��(Fresnel Effect)�� ���ؼ��� ���캸��.


    --Rim Light: ��ü�� ���尡���� ���� ��谡 ��� ������ ���� 'ȿ��'--
        ������ ȿ��(Fresnel Effect): ��ü�� '����'�� ���� '�ݻ���', '������' ���� �޶� �Ͼ�� ����

        <-- rim light�� ������ ȿ���� ���� �Ͼ�ٰ� �� �� �ִ�.


        <--������Ʈ�� �����ϸ� ��, ������ ȿ���� '���'�� ���� ���̴�.

*/
Shader "Custom/shRimLight"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0

        _RimWidth ("rim width", Range(0,10)) = 4.5

        [HDR]_RimColor ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //sampler2D _MainTex;

        //������ ���������ο��� ���޹��� �����͸� �����Ͽ� �����Ѵ�.
        struct Input
        {
            //float2 uv_MainTex;
            float3 viewDir; //������ ���������ο��� ���޹��� '�ü�����(ī�޶���)'
        };

        //half _Glossiness;
        //half _Metallic;
        fixed4 _Color;

        fixed _RimWidth;
        fixed4 _RimColor;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //������<--ī�޶�
            //step_0
            //N dot V   �������� dot �ü�����
            //fixed tDot = dot(o.Normal, IN.viewDir);
            //fixed tDotResult = saturate(tDot);//[0, 1]

            //step_1
            //fixed tDot = dot(o.Normal, IN.viewDir);
            //fixed tDotResult = saturate(tDot);//[0, 1]
            //fixed tRim = 1 - tDotResult;

            //step_2
            fixed tDot = dot(o.Normal, IN.viewDir);
            fixed tDotResult = saturate(tDot);//[0, 1]
            fixed tRim = 1 - tDotResult;
            fixed tRimLight = pow(tRim, _RimWidth);    //�ŵ������Ͽ� ������ ������.


            fixed4 c = _Color;
            o.Albedo = c.rgb;
            
            o.Emission = tRimLight * _RimColor;    //��� ������, ������Ʈ ���� ����( ����������� )

            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
