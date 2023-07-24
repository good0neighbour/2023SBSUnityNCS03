/*
    AlphaTest

    임의의 기준값인 알파값을 경계로
    해당 기준값 미만이면
        픽셀을 칠하지 않고
    이상이면
        픽셀을 칠한다.




        AlphaTest 렌더큐에 넣어질 때

        앞 ------> 뒤

        정렬되어 넣어진다

        왜냐하면
        어차피 불투명한 부분을 칠하는 방법은 Opaque와 같기 때문이다.
        ( 그러면 overdraw가 발생하지 않는다 )
        투명한 부분은 아예 칠하지 않으므로 상관없다
*/
Shader "Ryu/shAlphaTest"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
        //경계가 될 기준값
        _Cutoff("Alpha cutoff", Range(0, 1)) = 0.5
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="TransparentCutout" "Queue" = "AlphaTest" }
        //alphatest를 위한 설정
        //랜더모드는 TransparentCutout
        //랜더큐는 AlphaTest
        //를 사용하도록 설정
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alphatest:_Cutoff
            //<---해당 기준값을 경계로 alphatest수행을 설정해줌

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
            

            //o.Alpha = 0.7;//c.a;
            //o.Alpha = 0.5;//c.a;
            //o.Alpha = 0.4;//c.a;

            o.Alpha = c.a;
        }
        ENDCG
    }
    //FallBack "Diffuse"
    FallBack "Legacy Shaders/Transparent/Cutout/VertexLit"
    //<-- alphatest이므로 폴백은 이것으로 하자
}
