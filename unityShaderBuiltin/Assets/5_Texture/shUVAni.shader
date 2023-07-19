/*
    Texture : �̹��� ���� ���̵��� ����ϴ� �̹��� ������

    UV��ǥ: ������ �ؽ����� texel�� ������ �鿡 ������ ������ ������Ű�� ���� ��ǥ����
        <-- ����ȭ�Ǿ� �ִ�.
		( ����ȭ�� ����: ũ�Ⱑ ������ ��� �ٸ� �ؽ��ĸ� �Ϲ�ȭ�Ͽ� �ٷ�� ���ؼ��� )

*/

Shader "Ryu/shUVAni"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _Amplitude ("sin amplitude", Range(0, 5)) = 1
        _Frequency ("sin frequency", Range(0, 5)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert//Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed _Amplitude;
        fixed _Frequency;
        

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //tex2D���̴� �Լ�: UV��ǥ�� �����Ͽ�, �ؽ��� �̹��� �����Ϳ��� ������ �ؼ��� �������� �Լ�<--���ø�sampling
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            //fixed4 c = tex2D (_MainTex, float2(IN.uv_MainTex.x + 0.5, IN.uv_MainTex.y + 0.5));

            //_Time�� �������α׷��� �ð��� �帧�� �˷��ش�.
            //fixed4 c = tex2D (_MainTex, float2(IN.uv_MainTex.x + _Time.y, IN.uv_MainTex.y));
            //<-- UV animation��� : UV ��ǥ���� ���������ν� �ؽ��ĸ� �ִϸ��̼� ��Ű�� ���̴�.

            fixed4 c = tex2D (_MainTex, float2(IN.uv_MainTex.x + _Amplitude * sin(_Time.y * _Frequency), IN.uv_MainTex.y));
            //sin�Լ��� ����� [-1, 1]�̴�.
            //<-- �ֱ������� �ݺ��ȴ�.

            o.Albedo = c.rgb;
            
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
