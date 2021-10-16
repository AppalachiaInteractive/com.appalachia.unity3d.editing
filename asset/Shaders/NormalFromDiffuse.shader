
Shader "internal/utility/NormalFromDiffuse" 
{
   // generate a full Normal texture from just a diffuse image
   Properties {
      _MainTex ("Base (RGB)", 2D) = "white" {}
      
      _NormalScale("Normal Scale", Range( 0 , 4)) = 4
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
	  uniform float _NormalScale;
   
    
      float4 _MainTex_TexelSize;

      float4 GenerateNormal(float2 uv, float uvOffset, float amplitude, float bias)
      {
         float pixX = _MainTex_TexelSize.x;
         float pixY = _MainTex_TexelSize.y;

         float3 gx = tex2Dbias(_MainTex, float4(uv + float2(pixX, 0), 0, bias)).rgb;
         float3 gy = tex2Dbias(_MainTex, float4(uv + float2(0, pixY), 0, bias)).rgb; 
         float3 gxb = tex2Dbias(_MainTex, float4(uv + float2(-pixX, 0), 0, bias)).rgb;
         float3 gyb = tex2Dbias(_MainTex, float4(uv + float2(0, -pixY), 0, bias)).rgb;

         gx  = saturate( Luminance(gx + uvOffset));
         gy  = saturate( Luminance(gy + uvOffset));
         gxb = saturate( Luminance(gxb + uvOffset));
         gyb = saturate( Luminance(gyb + uvOffset));


         gx = (gx - gxb) * -1;
         gy = (gy - gyb) * -1;

         half4 ret = half4(0.5, 0.5, 0, 1);

         float len = sqrt( gx * gx + gy * gy + 1 );

         if(len > 0)
         {
            ret.r = 10*amplitude*gx/len * 0.5 + 0.5;
            ret.g = 10*amplitude*gy/len * 0.5 + 0.5;
            ret.b = 1.0 / len;
         } 
         return ret;
      }
          
      fixed4 frag(v2f_img i) : SV_Target
      {
         float4 finalNorm = 0;
         finalNorm += GenerateNormal(i.uv, 0.1, 0.8, 6) * 6;
         finalNorm += GenerateNormal(i.uv, 0.2, 0.7, 5) * 5;
         finalNorm += GenerateNormal(i.uv, 0.3, 0.6, 4) * 4;
         finalNorm += GenerateNormal(i.uv, 0.4, 0.5, 3) * 3;
         finalNorm += GenerateNormal(i.uv, 0.5, 0.4, 2) * 2;
         finalNorm += GenerateNormal(i.uv, 0.6, 0.3, 1);
         finalNorm += GenerateNormal(i.uv, 0.7, 0.2, 0) * 2;
         finalNorm /= 23.0;

         finalNorm.xy = (finalNorm.xy * 2 - 1);       
         
         finalNorm.xy = finalNorm.xy * _NormalScale * 12;         
         
         finalNorm.z = sqrt(1.0 - saturate(dot(finalNorm.xy, finalNorm.xy)));         
         finalNorm = normalize(finalNorm);
         
         finalNorm = .5 + (finalNorm / 2);

         return finalNorm;
      }
         ENDCG
      }

   }

   Fallback off

}