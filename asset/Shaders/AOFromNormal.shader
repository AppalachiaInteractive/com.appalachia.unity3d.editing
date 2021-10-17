
Shader "appalachia/utility/AOFromNormal" 
{
   // generate a full AO texture from just a normal image
   Properties {
      _MainTex ("Normal (RGB)", 2D) = "bump" {}
      _AO("Global Tiling", Range( .1 , 5)) = 1
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
      uniform float _AO;

      fixed4 frag(v2f_img i) : SV_Target
      {
         half4 norm = tex2D(_MainTex, i.uv);

         half3 un = UnpackNormal(norm);
         un.xy = un.xy * 0.5 + 0.5;

         // ao is just the normal maps length
         half ao = saturate(un.z * un.z * _AO);

         return fixed4(ao,ao,ao,1);
      }
         ENDCG
      }

   }

   Fallback off

}