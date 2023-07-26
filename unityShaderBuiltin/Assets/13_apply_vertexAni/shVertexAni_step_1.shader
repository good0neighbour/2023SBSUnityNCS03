/*
    vertex animation���ø� ���캸��

        Ǯ�� '�ܼ��� �ݺ����� ������ ������'�� ���̸� ��鸲
        �ٴٰ� '�ܼ��� �ݺ����� ������ ������'�� ���̸� �ⷷ��
        <-- �̷� �������̶�� vertex animation�� ȿ�������� ����� �� �ִ�.


    i) �̹� ���ܿ����� ���� �׽�Ʈ�� ��������

        ���ذ� 0.5��� �����ϸ�

        0.7 <--- ǥ��
        0.5 <--- ǥ��
        0.3 <--- ǥ�� ����

    ii) vertex animation�� ��������.
*/
Shader "Ryu/shVertexAni_step_1"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _Cutoff("cut off", float) = 0.5 //�����׽�Ʈ�� ���� ���ذ�


        _Amplitude("amplitude", Range(0.1, 2)) = 0.5
        _Frequency("frequency", Range(0.2, 7)) = 5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alphatest:_Cutoff vertex:DoVert
        //<-- �����׽�Ʈ�� ���� ���̴� ������ �ɼ� ������ ����
        //<--vertex shader�Լ��� ����ϱ� ���� ���̴� ������ �ɼ� ������ ����

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        float _Amplitude;
        float _Frequency;

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


        float random (float2 uv)
        {
            return frac(sin(dot(uv,float2(12.9898,78.233)))*43758.5453123);
            //frac ���̴� �Լ�
            //<-- �־��� ���� �Ҽ��� ���� ���� ���Ѵ�. (0, 1)
        }

        void DoVert(inout appdata_full v)
        {
            //vertex animation ���� �ִϸ��̼�
            //v.vertex.y += sin(_Time.y);   //�ݺ����� ������ ������
            //v.vertex.y += 0.5 * sin(_Time.y); //��������<--�������� ũ�� ����
            //v.vertex.y += sin(_Time.y * 5); //��������<--�������� ������

            //v.vertex.y += 0.5 * sin(_Time.y * 5) * random(v.texcoord); //
            v.vertex.y += _Amplitude * sin(_Time.y * _Frequency) * random(v.texcoord); //
        }


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
