/*
    Dissolve Effect

    ������ Ÿ���� ȿ��


    i) main texture
    ii) ������ ���� ���� ����

    iii) Noise Texture( �ұ�Ģ�� ������ ���� �ؽ�ó �̹��� ������ )
    iv) ��踦 ��Ȯ�� �Ͽ�, ���̰� �� ���̰��� ������ �и��Ѵ�. ���ĺ���

*/

Shader "Ryu/shDissolve_step_1"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _NoiseTex ("noise texture", 2D) = "white" {}

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
            tAlpha = step(0.2, tNoise.r);   //tNoise.r >= 0.5 ? 1 : 0
            //��踦 ��Ȯ�� �����Ͽ� ���İ��� �����Ѵ�.

            o.Alpha = tAlpha;
            //o.Alpha = c.a;
            //o.Alpha = 0.5;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
