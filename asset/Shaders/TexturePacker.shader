Shader "Hidden/TexturePacker"
{
	Properties
	{
		_Input00Tex ("Input00", 2D) = "black" {}
		_Input01Tex ("Input01", 2D) = "black" {}
		_Input02Tex ("Input02", 2D) = "black" {}
		_Input03Tex ("Input03", 2D) = "black" {}

		_Input00In ("Input00In", Vector) = (0,0,0,0)
		_Input01In ("Input01In", Vector) = (0,0,0,0)
		_Input02In ("Input02In", Vector) = (0,0,0,0)
		_Input03In ("Input03In", Vector) = (0,0,0,0)

		_Input00Invert ("Input00Invert", Vector) = (0,0,0,0)
		_Input01Invert ("Input01Invert", Vector) = (0,0,0,0)
		_Input02Invert ("Input02Invert", Vector) = (0,0,0,0)
		_Input03Invert ("Input03Invert", Vector) = (0,0,0,0)
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
			#pragma target 4.6
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			sampler2D _Input00Tex;
			sampler2D _Input01Tex;
			sampler2D _Input02Tex;
			sampler2D _Input03Tex;
			
			float4 _Input00In;
			float4 _Input01In;
			float4 _Input02In;
			float4 _Input03In;
			
			float4 _Input00Invert;
			float4 _Input01Invert;
			float4 _Input02Invert;
			float4 _Input03Invert;
			
			float4x4 _Input00Out;
			float4x4 _Input01Out;
			float4x4 _Input02Out;
			float4x4 _Input03Out;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			float4 SwapChannels(sampler2D tex, float2 uv, float4 e, float4x4 v, float4 invert)
			{
				float4 inColor = tex2D(tex, uv);
				
				float4 r = (invert.r ? (float4(1,1,1,1)-inColor.rrrr) : inColor.rrrr) * v[0] * e.r;
				float4 g = (invert.g ? (float4(1,1,1,1)-inColor.gggg) : inColor.gggg) * v[1] * e.g;
				float4 b = (invert.b ? (float4(1,1,1,1)-inColor.bbbb) : inColor.bbbb) * v[2] * e.b;
				float4 a = (invert.a ? (float4(1,1,1,1)-inColor.aaaa) : inColor.aaaa) * v[3] * e.a;

				return r + g + b + a;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float4 c00 = SwapChannels(_Input00Tex, i.uv, _Input00In, _Input00Out, _Input00Invert);
				float4 c01 = SwapChannels(_Input01Tex, i.uv, _Input01In, _Input01Out, _Input01Invert);
				float4 c02 = SwapChannels(_Input02Tex, i.uv, _Input02In, _Input02Out, _Input02Invert);
				float4 c03 = SwapChannels(_Input03Tex, i.uv, _Input03In, _Input03Out, _Input03Invert);
				return c00 + c01 + c02 + c03;
			}
			ENDCG
		}
	}
}
