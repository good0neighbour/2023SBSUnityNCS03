/*

    ����refraction ������ �䳻�����

*/
Shader "Ryu/shRefraction_step_3"
{
    Properties
    {
        _RefractionTex("Refraction Texture", 2D) = "white"{}
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        GrabPass{} //<--��ũ�� ȭ�� ĸ�� ��ɹ�

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf NoLight noambient alpha:fade//Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _RefractionTex;

        sampler2D _GrabTexture; //<-- GrabPass�� �����ʹ� �� �ؽ��Ŀ� ����

        struct Input
        {
            float2 uv_MainTex;
            float4 screenPos;   //<--��ũ��(��üȭ��, 2D)�� ��ǥ�� ���´�.
        };


        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            //o.Emission = IN.screenPos.rgb; //��ũ���� ��ǥ�� �����ϱ� ���� �������� �ٷﺸ�Ҵ�.
            //���� ��ġ
            //��ũ�� ��ǥ�� ��ġ
            //<-- ��� ����� ���� ������


            float4 tRyu = tex2D(_RefractionTex, IN.uv_MainTex);
            //<-- uv animation�� ��ġ ���μ� ������ �ؽ�ó �̹��� �����͸� ���

            float3 tScreenUV = IN.screenPos.rgb;
            o.Emission = tex2D(_GrabTexture, tScreenUV.xy + tRyu.x * sin(_Time.y) * 0.1);
            //�ݺ����� ������ ������, �ð��� �帧�� ���� uv animation
        }
        //custom light model
        float4 LightingNoLight(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
        {
            return float4(0, 0, 0, 1);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
