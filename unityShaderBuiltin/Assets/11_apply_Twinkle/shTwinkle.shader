Shader "Ryu/shTwinkle"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _MaskTex ("mask tex", 2D) = "white" {}
        //'������ ������ �����ϱ� ���� ������'�μ��� �ؽ���
        _RampTex ("mask tex", 2D) = "white" {}
        //'�ұ�Ģ���� �ֱ⸦ ������ ��ȣ�� ������' �뵵�μ��� �ؽ���

        //<--���� ��ġ��. �׷��Ƿ� ������ ������ �뵵�� ��밡���ϴ�.

        _Frequency("frequency", Range(0.03, 2)) = 0.09
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

        sampler2D _MainTex;
        sampler2D _MaskTex;
        //'������ ������ �����ϱ� ���� ������'�μ��� �ؽ���
        sampler2D _RampTex;
        //'�ұ�Ģ���� �ֱ⸦ ������ ��ȣ�� ������' �뵵�μ��� �ؽ���

        float _Frequency;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MaskTex;  //<--_MaskTex�� ���� uv ��ǥ����
        };

        

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 tMask = tex2D (_MaskTex, IN.uv_MaskTex);
            //������ ���� ���� ������

            fixed4 tFrequency = tex2D (_RampTex, float2(_Time.y * _Frequency, 0.5));
            //�ұ�Ģ���� �ֱ��� ������

            o.Albedo = c.rgb;
            
            o.Emission = c.rgb * tMask.r * 0.5, tFrequency.r;
            //�� ���´� �״�� �����Ǿ�� �ϹǷ� c.rgb
            //������ ������ �ұ�Ģ���� �ֱ�� ������(��¦��) ����

            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
