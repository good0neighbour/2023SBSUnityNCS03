Shader "Unlit/shUnlitBlinnPhong"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Albedo", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;

                float3 normal:NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;    //SV_ System Value
                //SV_POSITION: ���Ժ亼���� ����� �� ������ ��ġ��

                float4 mDiffuse:COLOR0;  //<--���ݻ籤 ������ ����
                float4 mSpecular:TEXCOORD1;
                //<--���ݻ籤 ������ ����, ¦�� �� ���߱� ���� float4
                //  float2<--�����׸�Ʈ���̴����� 4�ڸ����� ����Ұ��Ͽ� ����
                //  �ø�ƽ�� ������ ������ ����
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);


                float3 tWorldNormal = UnityObjectToWorldNormal(v.normal);

                //lamber light ���ݻ籤�� ���
                float tDot = dot(tWorldNormal, _WorldSpaceLightPos0.xyz);
                float tDotResult = saturate(tDot);
                
                o.mDiffuse = tDotResult;

                //specular light ���ݻ籤�� ���
                o.mSpecular = pow(tDotResult, 80);

                return o;
            }

            //������������������ ��� ��ģ �ȼ� �����ʹ�
            //���� ����(back buffer�� front buffer �� ���� �̷������ ) �ý�����
            // ����ۿ� �׷����� �ȴ�.
            //���⿡�� �� ����۸� ���� Target�̶�� �θ���
            //
            //SV_Target : ������� ������ �����Ǵ� �ȼ� �κ�
            fixed4 frag (v2f i) : SV_Target//
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                //���ݻ籤 ����, ���ݻ籤 ����
                //col = col * i.mDiffuse * _Color;
                col = col * i.mDiffuse * _Color + i.mSpecular;

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
