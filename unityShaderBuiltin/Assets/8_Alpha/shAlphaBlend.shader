/*
    AlphaBlend

    �������� ��ü������

    �� -----> ��

    ���� ���ĵǾ� �־�߸�

    �ڿ��ִ� ��ü�� ��ġ�� ������ ȿ���� �� �� �ִ�.

    ���� �տ� �ִ� ���� ���� �׸��ٸ�
    Depth-Buffer�˰��� ���� �ڿ� �ִ� ��ü�� �׸� �� ����.
    �׷��Ƿ� �翬��

    �� -----> ��

    ���� ���ĵǾ�߸� �Ѵ�.

    �̰��� Alpha Sorting�̶�� �Ѵ�.


     �������� ��ü�� �������ϴ� �Ͱ� ���غ����� ��
     �ȼ��� ���� ȥ�տ���( ���׸��Ⱑ �Ͼ�� )�� �Ͼ�Ƿ�
     �翬�� ���� ���尡 ������ ���� �Ҹ��ϴ�.


     ���귮 ��

     PC:    ������ < �����׽�Ʈ < ���ĺ���

     mobile: ������ < ���ĺ��� < �����׽�Ʈ
        <--- ����� ����̽��� Ÿ�� ������ �ؽ�ó ó�� ��� ������( Ÿ�� ������ ó���ϰ� ���� �۾��� �ٲٴµ� ��� ������ �� ���Ƽ� ) �����׽�Ʈ�� �ξ� ������ ���ٰ� �Ѵ�.

        <-- ���Ǽ�. �������� ������� ��� Ÿ�� ������ �ɰ��� ������ �����׽�Ʈ�� �⺻������ �б�Ƿ�
        �б� * Ÿ�ϰ����� �бⰡ ���������.
        �׷��� ó����ġ�� �б⿬�꿡 ���ϰ� ���� �ɸ���.
        �׷��Ƿ� ����� ��⿡�� �����׽�Ʈ�� �ξ� ������ ���� ��� ���� �ƴѰ� �����Ѵ�.
*/
Shader "Ryu/shAlphaBlend"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        //�������� Transparent
        //����ť�� Transparent
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha:fade
        //<--������ �� Fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        
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
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            
            o.Alpha = c.a;
            //o.Alpha = 0.5;//c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
    FallBack "Legacy Shaders/Transparent/VertexLit"
}
