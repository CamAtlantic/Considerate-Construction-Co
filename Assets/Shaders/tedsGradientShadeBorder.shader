
Shader "TED/GradientBorder" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white"{}
		_ColorTwo ("Color Two", Color) = (1,1,1,1)
		_ColorOne ("Color One", Color) = (1,1,1,1)
		[Space(20)]
		_YOffset ("Y Offset", Float) = 0.5
		_YScale ("Gradient Length", Float) = 0.5
		_Emit ("Emit Level", Range(0, 1)) = 0.5
		_Alpha ("Alpha Level", Range(0, 1)) = 1
		[Space(20)]
		_ShadeColor ("Shade Color", Color) = (1,1,1,1)
		[Space(20)]
		_VertOffset("Vert Extrusion", Float) = 0.1
		_VertMotion("Vert Extrusion Sin Move Scale", Float) = 0.1
		[Space(20)]
		_VertWobble("Vert Sin Wobble Scale", Float) = 0.1
		_VertWobbleSpeed("Vert Sin Wobble Speed", Float) = 0.1
		
	}
	
	SubShader {
	
		Tags {"RenderType" = "Opaque"  }
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Back
	
		CGPROGRAM
		#pragma surface surf WrapLambert Lambert vertex:vert 
		#pragma target 3.0
		
		sampler2D _MainTex;
		float4 _ColorOne;
		float4 _ColorTwo;
		float _YOffset;
		float _YScale;
 		float _Emit;
 		float _Alpha;
 		
 		float4 _ShadeColor;
 		
 		float _VertOffset;
 		float _VertMotion;
 		
 		float _VertWobble;
 		float _VertWobbleSpeed;
		
		half4 LightingWrapLambert (SurfaceOutput s, half3 lightDir, half atten) {
	        half NdotL = dot (s.Normal, lightDir);
	        half diff = NdotL * 0.5 + 0.5;
	        half4 c;
	        c.rgb = s.Albedo * _ShadeColor  *  (diff * atten);
	        c.a = s.Alpha;
	        return c;
	    }

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			float3 viewDir;
			float3 worldRefl;
		};
		
 		void vert (inout appdata_full v)
 		{
 			half offsetvert = (abs( sin(_Time.y + v.vertex.y)  * _VertMotion )) + _VertOffset;
 			
 			v.vertex.xyz += v.normal * offsetvert;
 			
 			v.vertex.xyz += sin((_Time.y + v.vertex.y) * _VertWobbleSpeed) * _VertWobble;
 		}
 
		void surf (Input IN, inout SurfaceOutput o) {
			
			if(IN.worldPos.y > _YOffset + (_YOffset * _YScale))
			{
				o.Albedo = _ColorTwo;
			}
			else if(IN.worldPos.y < _YOffset){
				o.Albedo = _ColorOne; 
			}
			else 
			{
				float dist = (_YOffset + (_YOffset * ( _YScale))) - _YOffset;
				float pointDist = IN.worldPos.y - _YOffset;
				float t = (1 / dist) * pointDist;  
				
				o.Albedo = lerp(_ColorOne, _ColorTwo, t).rgb ;
			}
			o.Albedo *= tex2D(_MainTex,IN.viewDir);
			
			o.Albedo = lerp(float4(0,0,0,0), o.Albedo, _Alpha);
			o.Normal = float3(0,0,0) * IN.viewDir;
			o.Emission =  o.Albedo * _Emit;
		}
 		
 		
 		
		ENDCG
	} 
	Fallback "VertexLit"
}