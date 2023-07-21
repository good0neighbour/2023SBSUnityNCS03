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
                //SV_POSITION: 정규뷰볼륨상에 근평면 상에 임의의 위치값

                float4 mDiffuse:COLOR0;  //<--난반사광 전달을 위함
                float4 mSpecular:TEXCOORD1;
                //<--정반사광 전달을 위함, 짝수 오 맞추기 위해 float4
                //  float2<--프레그먼트셰이더에서 4자리수랑 연산불가하여 비선택
                //  시멘틱은 임의의 것으로 지정
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

                //lamber light 난반사광량 계산
                float tDot = dot(tWorldNormal, _WorldSpaceLightPos0.xyz);
                float tDotResult = saturate(tDot);
                
                o.mDiffuse = tDotResult;

                //specular light 정반사광량 계산
                o.mSpecular = pow(tDotResult, 80);

                return o;
            }

            //렌더링파이프라인을 모두 거친 픽셀 데이터는
            //더블 퍼퍼(back buffer와 front buffer 두 개로 이루어진다 ) 시스템의
            // 백버퍼에 그려지게 된다.
            //여기에서 이 백버퍼를 흔히 Target이라고 부른다
            //
            //SV_Target : 백버퍼의 임의의 대응되는 픽셀 부분
            fixed4 frag (v2f i) : SV_Target//
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                //난반사광 적용, 정반사광 적용
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
