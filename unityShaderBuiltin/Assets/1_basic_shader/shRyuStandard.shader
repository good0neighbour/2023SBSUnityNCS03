/*
    ������ ����Ƽ���� �����ϴ� surface shader���� �ڵ��.

    surface shader��
    built-in render pipeline���� �����ϴ� shader �����̴�.



    surface shader�� ���α׷� ������
    ShaderLab + CG
    �� �̷������.


    ShaderLab <--����Ƽ���� ��ü������ ���� ���̴� ���α׷��� ���
    <-- ������ ���� ���µǾ���, built-in renderpipeline�� ���̴� ���α׷��� �⺻������ �����ϴµ� ������ ���δ�.

    ���̴� ���α׷��� ����� ����
    Opengl <-- glsl
    DirectX <-- hlsl
    ������ <--cg

*/
//��ü ������ shaderlab ���� ��������ִ�.
Shader "Ryu/shRyuStandard"
{
    //Properties ����Ƽ �ν����� �� ����� ������ �����ϴ� ���̴�.
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        //<--_Color�� �ҽ��ڵ� �󿡼� ���� ������ �̸�
        //<-- "Color"�� ����Ƽ �ν����� �� ����� ���ڿ�
        //<-- Color�� shaderlab���� ���� Ÿ��
        //<-- (1, 1, 1, 1) �� �ʱⰪ
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
    }
    //SubShader ���̵��� �����ϴ� ���̴� ���α׷� ���� �κ�(��ɹ��� ����)�̴�.
    SubShader
    {
        Tags { "RenderType"="Opaque" } //<--��Ʃ�� �ɼ����� ������ ����
        LOD 200 //<-- LOD Level Of Detail �Ÿ��� ���� ������ ����

        
        CGPROGRAM//<-- ���⼭���ʹ� cg�����̴�.
        //���̴� ������ �ɼ� ����
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows
            //<--Standard����𵨻��, ��� ���� ���� �׸��� ���� �ɼ����� ������
            //<-- surface shader�� �Լ��� surf�� ����

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //-----ShaderLab���� ���� ���� �̸��� CG���� ���� �̸��� '�����ϰ� ����� �Ѵ�.'
        //sampler2D _MainTex;

        struct Input
        {
            //UV��ǥ( �ؽ��� ��ǥ )
            //�ؼ��� ������ ǥ�鿡 �ȼ��� ���� ��
            //������ �̹����� ��� �ؼ��� ������ ��ǥ�� �����ϴµ�
            //�̹������� ��� ũ��(�ʺ�, ����)�� �ٸ��Ƿ� ��ǥ�� ��� �޶����� ������ �ִ�.
            //�̸� �ذ��ϱ� ����
            //����ȭ�� �������� ��ǥ�� �ٷ��.
            //�̷��� ��ǥ�踦 UV��ǥ���� �Ѵ�.

            float2 uv_MainTex;  //float �ε� �Ҽ�, �ڿ� ���� ���ڴ� �������� ����
        };

        //float 4byte( 32bit )

        //half _Glossiness;   //half 2byte( 16bit )
        //half _Metallic;
        fixed4 _Color;      //fixed ���� �Ҽ��� ���� ǥ��, �ڿ� ���� ���ڴ� �������� ����

        //fixed 11byte

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        //inout �Է°� ����� ���ÿ� ����ϴ� �������� ��Ÿ����.
        //SurfaceOutputStandard <--ǥ���� ��� �����Ǿ� �ִ����� ���� ����ü<--����Ƽ���� �����صξ���.
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            //_Color <-- �ν����Ϳ��� �Է·¹��� ��ü�� ����
            //_MainTex <--�ν����Ϳ��� �Է¹��� �ؽ��� ������
            //  ������ �ؼ��� ���ø��Ͽ� �����´�.(�ؼ�Texel �ý�ó�� �ȼ�<--��������)
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 c = _Color;
            //<--�ؽ�ó�� ����� ��ü�� ������ ����

            o.Albedo = c.rgb;//<--������ swizzle ����
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            o.Alpha = c.a;
            //<--�̷��� �ϼ��� o�� ������ ������ ������ ���� �ܰ�� ���޵ȴ�.
        }
        ENDCG//<-- ������� ���� cg�����̴�.

    }
    FallBack "Diffuse"
    //Fallback<-- subshader�� �������� ������ ������ �������� �� ���̴��� �����ϰڴ�.
}
