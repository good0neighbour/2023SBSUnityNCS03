/*
    TriPlaner

    �𵨿� �°� �̸� ������uv��ǥ ����
    �����ϰ� �ؽ�ó�� ������ �� �ִ� uv ��ǥ�� ����� ����̴�.
    <-- �ٽ��� World Position UV�� ����ϴ� ���̴�.

    <--����� �������� �Ѵ�.

*/
Shader "Ryu/shTriPlaner"
{
    Properties
    {
        _MainTexTopBottom ("top texture", 2D) = "white" {}

        _MainTexFrontBack ("top texture", 2D) = "white" {}

        _MainTexRtLt ("top texture", 2D) = "white" {}
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

        sampler2D _MainTexTopBottom;
        sampler2D _MainTexFrontBack;
        sampler2D _MainTexRtLt;

        struct Input
        {
            //float2 uv_MainTex;

            float3 worldPos;    //<--������ǥ�� ������ ������ ��ġ ����
            float3 worldNormal; //<--������ǥ�� ������ �������� ����
        };


        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //������ǥ�� ���ؿ� ���� ��ġ���� UV������ ����Ѵ�`
            float2 tTopBottomUV = float2(IN.worldPos.x, IN.worldPos.z);
            float2 tFrontBackUV = float2(IN.worldPos.x, IN.worldPos.y);
            float2 tRtLtUV = float2(IN.worldPos.z, IN.worldPos.y);

            //�̷��� ���� UV��ǥ�� ������� ������ ��ġ�� �ش��ϴ� ������ �ؼ������� ��´�.
            fixed4 tColorTB = tex2D (_MainTexTopBottom, tTopBottomUV);
            fixed4 tColorFB = tex2D (_MainTexFrontBack, tFrontBackUV);
            fixed4 tColorRL = tex2D (_MainTexRtLt, tRtLtUV);

            //������ ���� ���� ����� ��� ���� ���������� �ش��ϴ� ������ �����ϰ�(����ŷmasking)
            //���� ���� �ؼ��� ����
            //������ �鿡 �˸´� ���� ������ ���������� ����Ͽ���.
            fixed4 c = tColorTB * abs(IN.worldNormal.y) + tColorFB * abs(IN.worldNormal.z) + tColorRL * abs(IN.worldNormal.x);

            //fixed4 c = tex2D (_MainTexTopBottom, tTopBottomUV);

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
