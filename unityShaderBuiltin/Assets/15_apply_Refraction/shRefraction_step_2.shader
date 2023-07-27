/*

    ĸ���� ��ũ�� ȭ����
    �ش� ǥ�鿡 �ؽ�ó ��������.

*/
Shader "Ryu/shRefraction_step_2"
{
    Properties
    {

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        GrabPass{} //<--��ũ�� ȭ�� ĸ�� ��ɹ�

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf NoLight noambient//Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

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

            float2 tScreenUV = IN.screenPos.rg;
            o.Emission = tex2D(_GrabTexture, tScreenUV);
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
