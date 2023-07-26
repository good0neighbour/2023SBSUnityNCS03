/*
    Dissolve Effect

    ������ Ÿ���� ȿ��


    i) main texture
    ii) ������ ���� ���� ����

    iii) Noise Texture( �ұ�Ģ�� ������ ���� �ؽ�ó �̹��� ������ )
    iv) ��踦 ��Ȯ�� �Ͽ�, ���̰� �� ���̰��� ������ �и��Ѵ�. ���ĺ�����


    v)��踦 ���� ũ�� �����Ͽ� �� ���� ������ Ȯ���Ѵ�
    vi) v)�� ������ Emission���� ó���Ѵ�

    vii) ���������δ� Albedo, Emission, Alpha�� ������ ���յǾ� dissolveȿ���� �����.
        Albedo <--��ü�� ���� �ܰ�
        Emission <--Ÿ���� �����ڸ�
        Alpha <-- ���̴�, �� ���̴�(Ÿ���� �� ���̴�) ���� ǥ��

*/

Shader "Ryu/shDissolve_step_2"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _NoiseTex ("noise texture", 2D) = "white" {}


        _EdgeCut("edge cut", Range(0, 1)) = 0.2
        //�����ڸ� Ÿ���� �κ��� �ʺ�� ����
        _OutlineWidth("outline width", Range(1, 2)) = 1.9
        [HDR]_OutlineColor("outline color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Tranparent" "Queue"="Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade//Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _NoiseTex;    //������(�ұ�Ģ�� ����) ������ ���� �ؽ���

        float _EdgeCut;
        //�����ڸ� Ÿ���� �κ��� �ʺ�� ����
        float _OutlineWidth;
        float4 _OutlineColor;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NoiseTex; //������ �ؽ�ó�� uv��ǥ ����
        };

        

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;


            fixed4 tNoise = tex2D (_NoiseTex, IN.uv_NoiseTex);
            //�ұ�Ģ ������ ������ ���� ���

            float tAlpha = 0;
            //tAlpha = step(0.2, tNoise.r);   //tNoise.r >= 0.2 ? 1 : 0
            tAlpha = step(_EdgeCut, tNoise.r);   //tNoise.r >= 0.2 ? 1 : 0
            //��踦 ��Ȯ�� �����Ͽ� ���İ��� �����Ѵ�.

            o.Alpha = tAlpha;
            //o.Alpha = c.a;
            //o.Alpha = 0.5;

            //�����ڸ� ����� Ÿ���� �κ�
            //float tOutline = 1 - step(0.2 * 1.9, tNoise.r);   //tNoise.r >= 0.2 * 1.9 ? 1 : 0
            //o.Emission = tOutline * fixed3(1, 1, 1);

            float tOutline = 1 - step(_EdgeCut * _OutlineWidth, tNoise.r);   //tNoise.r >= 0.2 * 1.9 ? 1 : 0
            o.Emission = tOutline * _OutlineColor;

        }
        ENDCG
    }
    FallBack "Diffuse"
}