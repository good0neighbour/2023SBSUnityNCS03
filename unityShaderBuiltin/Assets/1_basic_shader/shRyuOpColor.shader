/*

    ��ǻ���� ���� ǥ��
    :��ǻ�ʹ� ������ ��� ǥ���ϴ°�?

	'��'�� �����ΰ�?
        <--�߻�ȭ�� �������� �� ����

	����
        <-- '��'��� ������ ǥ��(ǥ��)�ϴ� ����(��ȣ)

    ��ġ�����
        ����� ���� �ڸ�(��ġ)�ٲ��� ����
        ���� ���ڸ� �̿��Ͽ� ǥ���ϴ� ���

    ���
        ��ġ��������� �ڸ��ٲ���
        ������ �Ǵ� ��

    ��) 112
    112 = 10^2 * 1 + 10^1 * 1 + 10^0 * 2
    <--���� ��ġ��������� �ش� ���� �����غ� ��


    ����� �հ����� �����̹Ƿ�( ī���� ���� ) �������� ���ϰ� ���� �ַ� ����Ѵ�.

    ��ǻ��: ���� �»��� ����(���� ������ ����� ��� �����ġ)�̴�.
    <-- ����� ������ �ٷ�� �Ѵ�.( �Ӹ��� ���µ� ���� �ٷ�? )
    <-- '�Ųٷ� �߻�'�Ͽ� '����ǥ�⸦ ��ǻ�Ͱ� �ٷ� �� �ְ� �Ѵٸ�' �� �װ��� '���� �ٷ�� ��'�̴�.

    ---> �׷��ٸ�, ��ǻ�Ͱ� ����ǥ�⸦ �ٷ� �� �ְ� �Ϸ��� ��� �ؾ��ұ�?( �հ����� ���µ�? )

    ��ǻ�ʹ� �հ����� ������
    ������ on/off ������ �ִ�.
    --->�׷��ٸ� 2�� ����� �ϴ� ������ ü�踦 ����ϸ� (���� ǥ�⸦ �ٷ�Ƿ�) ���� �ٷ� �� �ִ�.


    <-- ��ǻ�ʹ� ��Ʈbit�� �̿��Ͽ� ������ǥ�⸦ ����Ͽ� ������ ǥ�������ϴ�.


    ��ǻ���� �Ǽ� ǥ��

        ����(fixed) �Ҽ��� ǥ��
        <--�Ҽ��� ��ġ�� �����Ǿ� �ִ� ǥ���

        <--
            ����: ���� �ؼ��ϴµ� ���� ������ ���� ����.
                �ֳ��ϸ�, ������ ������, �Ҽ��� ���Ϻ�, ��ȣ��Ʈ�� ����ϴ� ��Ʈ�� �׳� �״�� �ؼ��ϱ� �����̴�.
            ����: ������ ��Ʈ�� �׳� �״�� �ؼ��ϹǷ�
                ���е��� ����.

        
        �ε�(floating) �Ҽ��� ǥ��
        <--�Ҽ��� ��ġ�� �����Ǿ� ���� ���� ǥ���




        �̹� ���ÿ����� ���󿬻��� ���캸��
*/
Shader "Ryu/shRyuOpColor"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard noambient noshadow//fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            //float2 uv_MainTex;
            fixed4 mColor : Color;
            //�ø�ƽsemantic: �ش� �����Ͱ� ������ ���������ο��� �� �뵵�� �������� �ǵ��� ������ ���̴�.
            //������ �뵵 ����ǥ
        };

        //half _Glossiness;
        //half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            //o.Albedo = c.rgb;
            //// Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            //o.Alpha = c.a;

            fixed4 c = _Color;

            //���� ����
            //<--���� �����, �� ����ȥ���� �⺻

            //step_0 swizzle
            //o.Emission = c.rgb;
            //o.Emission = c.bgr;
            //o.Emission = c.brg;
            //o.Emission = c.rrr;
            //o.Emission = c.ggg;

            //step_1 ����
            // //������ �������г��� ���Ѵ�.
            //o.Emission = fixed3(0.0f, 0.1f, 0.5f);
            //o.Emission = fixed3(1.0f, 0.0f, 0.0f) + fixed3(0.0f, 1.0f, 0.0f);
            //o.Emission = fixed3(1.0f, 0.0f, 0.0f) + fixed3(0.5f, 0.5f, 0.0f);
            //<--(1.5, 0.5, 0) ��ġ�� ���������� ���������� ����� ����ȭ�Ǿ� ��µǹǷ�
            //(1, 0.5, 0)���� ������ ��µȴ�.

            //step_2 ����
            //������ �������г��� ���Ѵ�.
            //o.Emission = fixed3(1.0f, 0.0f, 0.0f) * fixed3(0.0f, 0.0f, 0.0f);
            //o.Emission = fixed3(1.0f, 0.0f, 0.0f) * fixed3(0.0f, 1.0f, 0.0f);
            o.Emission = fixed3(0.5f, 0.5f, 0.0f) * fixed3(0.2f, 1.0f, 0.0f);
            //<-- (0.1, 0.5, 0)


        }
        ENDCG
    }
    FallBack "Diffuse"
}
