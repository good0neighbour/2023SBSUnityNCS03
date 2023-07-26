/*
    flaat shading
    gourad shading


    �� �� ������(�׸���)�� ���� �ܰ����� ǥ������

    i) ������ ���� ������� �������Ѵ�.

        ��) �����ø�, �� �ĸ��� �׸���.( ����� �׸��� )
        ��) ������ ������ �������� �������� ������ �̵����� Ȯ��? ��Ų��.
            <--���� ���̴� vertext shader �Լ��� �ʿ��ϴ�.

    ii) ���������� �������Ѵ�

*/

Shader "Ryu/shOutline2Pass"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        
        _OutlineColor ("outline Color", Color) = (0,0,0,1)
        _OutlineWidth ("outline width", Range(0.005,0.02)) = 0.01
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        cull front//���� �ø�, �ĸ鸸 ������

        //1 pass
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf NoLighting vertex:vert noambient noshadow

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        //half _Glossiness;
        //half _Metallic;
        fixed4 _Color;

        fixed4 _OutlineColor;
        fixed _OutlineWidth;


        struct SurfaceOutputNoLight {
            fixed3 Albedo;
            fixed3 Normal;
            fixed3 Emission;
            half Specular;
            fixed Gloss;
            fixed Alpha;
        };

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        //vertex shader�Լ�
        void vert(inout appdata_full v)
        {
            //�Ÿ��� ���� �ܰ����� ���Ⱑ ũ�� ���ϵ��� �ʰ� ����
            //<--������ ����� ����� ���̰��� �̿��Ͽ� ������������ �����̵�(�� ���� ����(ī�޶� �������)��)�� �����״�.
            float4 tRyu = UnityObjectToClipPos(v.vertex);
            float tDepth = tRyu.w * 0.5;


            //������ ��ġ v.vertex�� ������ �������� v.normal �������� �̵�
            v.vertex.xyz = v.vertex.xyz + v.normal.xyz * _OutlineWidth * tDepth;//<--������ ��Į�����
                //<-- ������ ���� ����
        }

        //void surf (Input IN, inout SurfaceOutputStandard o)
        void surf (Input IN, inout SurfaceOutputNoLight o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = _Color;
            o.Albedo = c.rgb;
            
            o.Alpha = c.a;
        }
        //������ �������� �ʰڴ�
        float4 LightingNoLighting(SurfaceOutputNoLight s, float3 lightDir, float3 viewDir, float attenu)
        {
            return _OutlineColor; //������, �� ������ �������� �ʰڴ�
        }
        ENDCG



        cull back   ///�ĸ� �ø�, ������ �������Ѵ�.

        //2 pass
        CGPROGRAM
        #pragma surface surf Lambert//Standard fullforwardshadows
        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
        };
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = _Color;
            
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG



    }
    FallBack "Diffuse"
}