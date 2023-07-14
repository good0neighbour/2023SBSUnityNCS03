Shader "Custom/shBuiltinBlinnPhong"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        
        //------------------------
        //���ݻ縦 ǥ���ϱ� ���� ����
        _SpecColor("spec color", Color) = (1, 1, 1, 1)
        //<--- built-in BlinnPhong����𵨿��� ���ݻ籤�� Ȱ��ȭ��Ű����
        //  �� ������ ������Ƽ ������ �����
        //  ������Ƽ �������� �����.
        //------------------------

        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf BlinnPhong//Standard fullforwardshadows
        //<-- built-in ����Ʈ ������� ����ϱ� ���� ���̴� ������ �ɼ� ������ ����
        /*
            �������� ����� �߿� �ϳ�
            BlinnPhong�����: ���ݻ�diffuse + ���ݻ� specular
        */

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

        //fixed4 _SpecColor;
        //���⵵ �����ϸ� ������

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

            //<-- built-in BlinnPhong ������� ����ϱ� ���� ����ü Ÿ���� ����
        //void surf (Input IN, inout SurfaceOutputStandard o)
        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 c = _Color;
            o.Albedo = c.rgb;
            //------------------------
            //���ݻ縦 ǥ���ϱ� ���� ����
            o.Specular = 0.5;  //�ݻ��� ������ �󸶳�
            o.Gloss = 1;        //������ ������ �󸶳�
            //------------------------
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
