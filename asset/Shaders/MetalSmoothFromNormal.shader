
Shader "appalachia/utility/MetalSmoothFromNormal" 
{
   // generate a full smoothness texture from just a normal image
   Properties {
      _MainTex ("Normal (RGB)", 2D) = "bump" {}
      _Metallic("Metallic", Range( 0 , 1)) = 0
      _Smoothness("Smoothness", Range( 0.001 , 1)) = .07
   }

   SubShader {
      Pass {
         ZTest Always Cull Off ZWrite Off
            
         CGPROGRAM
         #pragma vertex vert_img
         #pragma fragment frag
         #include "UnityCG.cginc"
   
      struct v2f {
         float4 pos : SV_POSITION;
         float2 uv : TEXCOORD0;
      };
      
      sampler2D _MainTex;
	  uniform float _Metallic;
	  uniform float _Smoothness;

      fixed4 frag(v2f_img i) : SV_Target
      {
         half4 norm = tex2D(_MainTex, i.uv);

         half3 un = UnpackNormal(norm);
         un.xy = un.xy * 0.5 + 0.5;

         // smoothness, be conservative
         half smooth = saturate(un.z * _Smoothness);

         return fixed4(saturate(_Metallic),0,0,smooth);
      }
         ENDCG
      }

   }

   Fallback off

}