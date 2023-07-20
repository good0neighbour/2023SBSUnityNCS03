/*
    Unlit ���̴� �⺻ ���α׷� ����

    ShaderLab + CG

        vertex shader
        fragment shader


    Pass
    '�������� �ʿ��� �����͸� ����ȭ�ϰ�
    �������� �ʿ��� ���¸� �����ϰ�
    ���������� �׸��� ��� �� �� ȣ��'�� 'pass'��� �Ѵ�.

    <---��, �������� ����� ����, �ؽ���, ���� ���� �����ϰ�
        �������� ����� ����( �̸��׸� ���� ���̴����α׷��� ����� ���̳� )�� �����ϰ�
        �������ϴ� ���� ���ϴ� ���̴�.
*/

Shader "Ryu/shUnlitLambert"
{
    Properties
    {
        _Color ("color", Color) = (1, 1, 1, 1)

        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass//<---
        {
            CGPROGRAM
            #pragma vertex vert         //<--vertex shader�Լ� ����
            #pragma fragment frag       //<--pixel shader�Լ� ����
            /*
                fragment:
                    ��ũ���� ǥ�õǴ� pixel�� �Ǳ� �������� �����͸� ������ fragment��� �ҷ���.
                    ������ ���������� ���� pixel�� ȥ��Ǿ� ���ȴ�.

                    OpenGL������ fragment��� �θ���
                    DirectX������ pixel�̶�� �θ���

                    ����Ƽ������ fragment��� �� ä���ߴ�.
            */
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct appdata  //�������α׷����� ���޹��� ������
            {
                float4 vertex : POSITION;   //<--�ø�ƽsemantic : ������ ���������ο��� ���� �뵵�� ���������� ǥ��
                float2 uv : TEXCOORD0;//�ؽ�����ǥ���� ���� ù ��°

                //���� ������ �ϱ� ���� ���� �����Ͱ� �ʿ��ϹǷ� appdata�� �������ش�.
                float3 normal:NORMAL;
            };

            struct v2f //<-- from vertex to fragment
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;    //SystemValue �ý��ۿ��� �䱸�ϴ� ��

                //������ �����ϱ� ���� ������ ����, ������ �ø�ƽ�� �����ϱ� ���� COLOR0�� ����, �׸��� �÷��̹Ƿ� float�� Ÿ�� ����
                float mDiffuse:COLOR0;
            };

            fixed4 _Color;

            sampler2D _MainTex;
            float4 _MainTex_ST;

            //vertex shader �Լ�
            //<--���� ������ �����͸� �ٷ��.
            v2f vert (appdata v)
            {
                v2f o;
                
                //UnityObjectToClipPos: ���庯ȯ, �亯ȯ, ������ȯ ����
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                //<--UV��ǥ�� �״�� �����ܰ�� ����

                UNITY_TRANSFER_FOG(o,o.vertex);


                //v.normal ������ǥ�� �� ���� ����( MVP�� ������� ���� )
                //�׷��Ƿ� ������ǥ�� ���� ���� ������ �ٲپ�� �Ѵ�.
                float3 tWorldNormal = UnityObjectToWorldNormal(v.normal);

                //lamber light
                //������ǥ�� ���� ������ ���� ������ directional light�� ���⸸ ���ߴ�.
                float tDot = dot(tWorldNormal, _WorldSpaceLightPos0.xyz);
                float tDotResult = saturate(tDot);
                
                //�����ܰ�� ����
                o.mDiffuse = tDotResult;

                return o;
            }
            //fragment(pixel) shader�Լ�
            //<-- �ȼ� ������ �����͸� �ٷ��
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 tTexColor = tex2D(_MainTex, i.uv);

                fixed4 col = _Color * tTexColor;//fixed4(1, 1, 1, 1);

                //vertex shader �ܰ迡�� ���� diffuse������ �ȼ��� ���� ����
                col = col * i.mDiffuse;

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);

                return col;
            }
            ENDCG
        }
    }
}
