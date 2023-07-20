/*
    Unlit 셰이더 기본 프로그램 구조

    ShaderLab + CG

        vertex shader
        fragment shader


    Pass
    '렌더링에 필요한 데이터를 조직화하고
    렌더링에 필요한 상태를 설정하고
    렌더링에서 그리기 명령 한 번 호출'을 'pass'라고 한다.

    <---즉, 렌더링에 사용할 색상, 텍스쳐, 조명 등을 설정하고
        렌더링에 사용할 상태( 이를테면 무슨 셰이더프로그램을 사용할 것이냐 )를 설정하고
        렌더링하는 것을 말하는 것이다.
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
            #pragma vertex vert         //<--vertex shader함수 설정
            #pragma fragment frag       //<--pixel shader함수 설정
            /*
                fragment:
                    스크린에 표시되는 pixel이 되기 전까지의 데이터를 원래는 fragment라고 불렀다.
                    하지만 요즈음에는 거의 pixel과 혼용되어 사용된다.

                    OpenGL에서는 fragment라고 부르고
                    DirectX에서는 pixel이라고 부른다

                    유니티에서는 fragment라는 용어를 채택했다.
            */
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct appdata  //응용프로그램에서 전달받은 데이터
            {
                float4 vertex : POSITION;   //<--시맨틱semantic : 렌더링 파이프라인에서 무슨 용도의 데이터인지 표시
                float2 uv : TEXCOORD0;//텍스쳐좌표정보 슬롯 첫 번째

                //조명 연산을 하기 위해 법선 데이터가 필요하므로 appdata에 병시해준다.
                float3 normal:NORMAL;
            };

            struct v2f //<-- from vertex to fragment
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;    //SystemValue 시스템에서 요구하는 값

                //광량을 전달하기 위해 변수를 만듦, 정해진 시맨틱을 적용하기 위해 COLOR0을 선택, 그리고 컬러이므로 float로 타입 선택
                float mDiffuse:COLOR0;
            };

            fixed4 _Color;

            sampler2D _MainTex;
            float4 _MainTex_ST;

            //vertex shader 함수
            //<--정점 단위의 데이터를 다룬다.
            v2f vert (appdata v)
            {
                v2f o;
                
                //UnityObjectToClipPos: 월드변환, 뷰변환, 투영변환 적용
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                //<--UV좌표를 그대로 다음단계로 전달

                UNITY_TRANSFER_FOG(o,o.vertex);


                //v.normal 로컬좌표계 상에 법선 정보( MVP가 적용되지 않은 )
                //그러므로 원드좌표계 상의 법선 정보로 바꾸어야 한다.
                float3 tWorldNormal = UnityObjectToWorldNormal(v.normal);

                //lamber light
                //월드좌표계 상의 정점의 법선 정보와 directional light의 방향만 취했다.
                float tDot = dot(tWorldNormal, _WorldSpaceLightPos0.xyz);
                float tDotResult = saturate(tDot);
                
                //다음단계로 전달
                o.mDiffuse = tDotResult;

                return o;
            }
            //fragment(pixel) shader함수
            //<-- 픽셀 단위의 데이터를 다룬다
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 tTexColor = tex2D(_MainTex, i.uv);

                fixed4 col = _Color * tTexColor;//fixed4(1, 1, 1, 1);

                //vertex shader 단계에서 계산된 diffuse광량을 픽셀의 색상에 적용
                col = col * i.mDiffuse;

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);

                return col;
            }
            ENDCG
        }
    }
}
