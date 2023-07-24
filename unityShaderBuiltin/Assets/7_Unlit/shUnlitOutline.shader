Shader "Ryu/shUnlitOutline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        //1plass
        Pass
        {
            cull front  //�����ø�, �ĸ鷻����

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;

                //�Ÿ��� ���� �ܰ����� ���Ⱑ ũ�� ���ϵ��� �ʰ� ����
                //<--������ ����� ����� ���̰��� �̿��Ͽ� ������(�� ���� ����(ī�޶� �������)��)�� �����״�.
                float4 tRyu = UnityObjectToClipPos(v.vertex);
                float tDepth = tRyu.w;

                //������ ��ȯ ���
                //1.03��
                float4x4 tMatScale;

                tMatScale[0][0] = 1 + tDepth * 0.01;//1 + 0.03;
                tMatScale[0][1] = 0;
                tMatScale[0][2] = 0;
                tMatScale[0][3] = 0;
                tMatScale[1][0] = 0;
                tMatScale[1][1] = 1 + tDepth * 0.01;//1 + 0.03;
                tMatScale[1][2] = 0;
                tMatScale[1][3] = 0;
                tMatScale[2][0] = 0;
                tMatScale[2][1] = 0;
                tMatScale[2][2] = 1 + tDepth * 0.01;//1 + 0.03;
                tMatScale[2][3] = 0;
                tMatScale[3][0] = 0;
                tMatScale[3][1] = 0;
                tMatScale[3][2] = 0;
                tMatScale[3][3] = 1;

                float4 tScaleV = mul(tMatScale, v.vertex);

                //o.vertex = UnityObjectToClipPos(v.vertex);
                o.vertex = UnityObjectToClipPos(tScaleV);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = fixed4(0,0,0,1);//tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }


        //2pass
        Pass
        {
            cull back

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
