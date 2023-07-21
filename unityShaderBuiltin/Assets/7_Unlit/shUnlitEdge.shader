/*
Shader�Լ��� Ȱ���� ���캸��

step
lerp
*/

Shader "Ryu/shUnlitEdge"
{
    Properties
    {
        _Color("face color", Color) = (1, 0, 0, 0)
        _EdgeColor("edge color", Color) = (0, 1, 0, 1)

        _Width("edge width", Range(0.1, 0.9)) = 0.1

        //_MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        //"RenderType"="Transparent" �������� ������
        //"Queue"="Transparent" ����ť�� Transparent�� ���
        LOD 100

        Pass
        {
            Cull Off

            Blend SrcAlpha OneMinusSrcAlpha
            //blend factor�� ��������
            //SRCCOLOR * SrcAlpha + DSTCOLOR * OneMinusSrcAlpha


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


            fixed4 _Color;
            fixed4 _EdgeColor;

            fixed _Width;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;    //uv��ǥ�� ���� �ܰ迡 ����
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = fixed4(0, 0, 0, 1);

                float tLowX = step(_Width, i.uv.x);

                //��������
                col = lerp(_EdgeColor, _Color, tLowX);

                return col;
            }
            ENDCG
        }
    }
}
