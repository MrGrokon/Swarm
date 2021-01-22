// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Custom/Grass"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.86
		_GrassMask("Grass Mask", 2D) = "white" {}
		_GrassColor("Grass Color", 2D) = "white" {}
		_ColorTint("Color Tint", Color) = (1,1,1,1)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest+0" "IgnoreProjector" = "True" }
		Cull Off
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows noshadow 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float4 _ColorTint;
		uniform sampler2D _GrassColor;
		uniform float4 _GrassColor_ST;
		uniform sampler2D _GrassMask;
		uniform float4 _GrassMask_ST;
		uniform float _Cutoff = 0.86;


		struct Gradient
		{
			int type;
			int colorsLength;
			int alphasLength;
			float4 colors[8];
			float2 alphas[8];
		};


		Gradient NewGradient(int type, int colorsLength, int alphasLength, 
		float4 colors0, float4 colors1, float4 colors2, float4 colors3, float4 colors4, float4 colors5, float4 colors6, float4 colors7,
		float2 alphas0, float2 alphas1, float2 alphas2, float2 alphas3, float2 alphas4, float2 alphas5, float2 alphas6, float2 alphas7)
		{
			Gradient g;
			g.type = type;
			g.colorsLength = colorsLength;
			g.alphasLength = alphasLength;
			g.colors[ 0 ] = colors0;
			g.colors[ 1 ] = colors1;
			g.colors[ 2 ] = colors2;
			g.colors[ 3 ] = colors3;
			g.colors[ 4 ] = colors4;
			g.colors[ 5 ] = colors5;
			g.colors[ 6 ] = colors6;
			g.colors[ 7 ] = colors7;
			g.alphas[ 0 ] = alphas0;
			g.alphas[ 1 ] = alphas1;
			g.alphas[ 2 ] = alphas2;
			g.alphas[ 3 ] = alphas3;
			g.alphas[ 4 ] = alphas4;
			g.alphas[ 5 ] = alphas5;
			g.alphas[ 6 ] = alphas6;
			g.alphas[ 7 ] = alphas7;
			return g;
		}


		float4 SampleGradient( Gradient gradient, float time )
		{
			float3 color = gradient.colors[0].rgb;
			UNITY_UNROLL
			for (int c = 1; c < 8; c++)
			{
			float colorPos = saturate((time - gradient.colors[c-1].w) / (gradient.colors[c].w - gradient.colors[c-1].w)) * step(c, (float)gradient.colorsLength-1);
			color = lerp(color, gradient.colors[c].rgb, lerp(colorPos, step(0.01, colorPos), gradient.type));
			}
			#ifndef UNITY_COLORSPACE_GAMMA
			color = half3(GammaToLinearSpaceExact(color.r), GammaToLinearSpaceExact(color.g), GammaToLinearSpaceExact(color.b));
			#endif
			float alpha = gradient.alphas[0].x;
			UNITY_UNROLL
			for (int a = 1; a < 8; a++)
			{
			float alphaPos = saturate((time - gradient.alphas[a-1].y) / (gradient.alphas[a].y - gradient.alphas[a-1].y)) * step(a, (float)gradient.alphasLength-1);
			alpha = lerp(alpha, gradient.alphas[a].x, lerp(alphaPos, step(0.01, alphaPos), gradient.type));
			}
			return float4(color, alpha);
		}


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			Gradient gradient84 = NewGradient( 0, 6, 2, float4( 0, 1, 0.03245807, 0 ), float4( 0.9954751, 1, 0, 0.1617609 ), float4( 0.96415, 0.07323387, 0.08524191, 0.3470665 ), float4( 1, 0, 0.9291334, 0.5823606 ), float4( 0, 0.02423716, 1, 0.8382391 ), float4( 0.01415092, 1, 0.9894827, 1 ), 0, 0, float2( 1, 0 ), float2( 1, 1 ), 0, 0, 0, 0, 0, 0 );
			float4 transform79 = mul(unity_ObjectToWorld,float4( 0,0,0,1 ));
			float2 appendResult80 = (float2(transform79.x , transform79.z));
			float dotResult4_g3 = dot( appendResult80 , float2( 12.9898,78.233 ) );
			float lerpResult10_g3 = lerp( 0.0 , 1.0 , frac( ( sin( dotResult4_g3 ) * 43758.55 ) ));
			float clampResult82 = clamp( lerpResult10_g3 , 0.0 , 1.0 );
			float3 appendResult86 = (float3(SampleGradient( gradient84, clampResult82 ).r , SampleGradient( gradient84, clampResult82 ).g , SampleGradient( gradient84, clampResult82 ).b));
			float clampResult90 = clamp( clampResult82 , 0.9 , 1.0 );
			float3 desaturateInitialColor87 = appendResult86;
			float desaturateDot87 = dot( desaturateInitialColor87, float3( 0.299, 0.587, 0.114 ));
			float3 desaturateVar87 = lerp( desaturateInitialColor87, desaturateDot87.xxx, clampResult90 );
			float2 uv_GrassColor = i.uv_texcoord * _GrassColor_ST.xy + _GrassColor_ST.zw;
			float2 uv_GrassMask = i.uv_texcoord * _GrassMask_ST.xy + _GrassMask_ST.zw;
			float4 tex2DNode2 = tex2D( _GrassMask, uv_GrassMask );
			o.Albedo = ( ( float4( desaturateVar87 , 0.0 ) + ( _ColorTint * tex2D( _GrassColor, uv_GrassColor ) ) ) * tex2DNode2 ).rgb;
			o.Alpha = 1;
			clip( tex2DNode2.r - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
177;95;1672;737;1322.59;-22.71965;1.290416;False;True
Node;AmplifyShaderEditor.CommentaryNode;92;-1868.251,-973.2325;Inherit;False;1504.237;610.8277;Color Randomization over Worldspace Pos;8;81;84;85;91;86;87;89;93;;0.9909875,0.6179246,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;81;-1818.251,-678.2178;Inherit;False;648.8287;221;Random Float Depending on XY Seed;4;82;78;80;79;;1,1,1,1;0;0
Node;AmplifyShaderEditor.ObjectToWorldTransfNode;79;-1799.251,-624.2178;Inherit;False;1;0;FLOAT4;0,0,0,1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;80;-1615.338,-590.0541;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.FunctionNode;78;-1491.421,-590.3351;Inherit;False;Random Range;-1;;3;7b754edb8aebbfb4a9ace907af661cfc;0;3;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;82;-1317.959,-591.4374;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientNode;84;-1427.774,-843.3187;Inherit;False;0;6;2;0,1,0.03245807,0;0.9954751,1,0,0.1617609;0.96415,0.07323387,0.08524191,0.3470665;1,0,0.9291334,0.5823606;0,0.02423716,1,0.8382391;0.01415092,1,0.9894827,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.GradientSampleNode;85;-1121.139,-824.8467;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;91;-1024.845,-611.6064;Inherit;False;221;209;Do some pastel shits;1;90;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;8;-1057.168,-314.4596;Inherit;False;989.1379;640.9768;Colouring;9;3;5;2;62;63;6;1;65;88;;0.6433878,1,0.4858491,1;0;0
Node;AmplifyShaderEditor.TexturePropertyNode;3;-985.1788,-81.87501;Inherit;True;Property;_GrassColor;Grass Color;2;0;Create;True;0;0;False;0;False;61a0c7c8232c6bd4f9d20ea23fcefdc1;61a0c7c8232c6bd4f9d20ea23fcefdc1;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.ClampOpNode;90;-974.8455,-560.6065;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.9;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;86;-802.2232,-798.0945;Inherit;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.DesaturateOpNode;87;-700.1539,-611.0949;Inherit;True;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;62;-713.7468,-260.9251;Inherit;False;Property;_ColorTint;Color Tint;5;0;Create;True;0;0;False;0;False;1,1,1,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;5;-747.3868,-90.52383;Inherit;True;Property;_TextureSample1;Texture Sample 1;3;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;63;-466.7717,-182.2525;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TexturePropertyNode;1;-801.7648,126.4377;Inherit;True;Property;_GrassMask;Grass Mask;1;0;Create;True;0;0;False;0;False;db544e128c717d642ac7c64bd6567fa9;db544e128c717d642ac7c64bd6567fa9;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.WireNode;93;-400.3841,-452.4063;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CommentaryNode;61;-1852.942,363.1468;Inherit;False;1800.883;1053.754;Wind Motion;16;25;27;37;13;14;59;34;49;48;33;47;46;38;39;60;94;;1,0.6367924,0.6367924,1;0;0
Node;AmplifyShaderEditor.SamplerNode;2;-565.0242,122.5167;Inherit;True;Property;_TextureSample0;Texture Sample 0;1;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;88;-328.6789,-220.508;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;60;-826.5777,432.9415;Inherit;False;486.3589;279.7648;Height Multiplier;1;58;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;94;-1074.885,477.0496;Inherit;False;451;211;Normalement c V mais jsp pk ca pas marche;1;57;;1,1,1,1;0;0
Node;AmplifyShaderEditor.FunctionNode;59;-1308.971,1256.007;Inherit;False;Radial Shear;-1;;4;c6dc9fc7fa9b08c4d95138f2ae88b526;0;4;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.WireNode;65;-126.4337,273.3448;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GradientNode;89;-1437.136,-923.2324;Inherit;False;0;5;2;1,0,0,0;0.9947276,0.4775211,0.05180655,0.1911803;0.9889588,1,0.1084906,0.523537;0.5779616,1,0.1185067,0.9000076;0.2147436,1,0.1273585,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;-186.121,2.346538;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;39;-183.6633,568.4145;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.DynamicAppendNode;34;-349.8232,747.2464;Inherit;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;14;-1811.232,1108.656;Inherit;False;Property;_WindSpeed;WindSpeed;3;0;Create;True;0;0;False;0;False;1;0.7;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;58;-581.8097,495.4085;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;37;-1770.275,840.829;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexCoordVertexDataNode;57;-825.5757,534.9414;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleTimeNode;13;-1540.232,1112.656;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;27;-1366.706,1008.167;Inherit;True;3;0;FLOAT3;0,0,0;False;1;FLOAT;2.03;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BreakToComponentsNode;49;-725.7352,755.7091;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.NoiseGeneratorNode;25;-1104.938,989.3437;Inherit;True;Gradient;True;True;2;0;FLOAT2;-19.6,0;False;1;FLOAT;1.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;48;-478.287,915.6215;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;38;-847.2394,998.1417;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;-0.5;False;4;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;46;-947.5733,1215.85;Inherit;False;Property;_WindForce;Wind Force;4;0;Create;True;0;0;False;0;False;2;1.73;1;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;33;-724.1811,874.5266;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;47;-635.275,993.4167;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Custom/Grass;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Masked;0.86;True;True;0;False;TransparentCutout;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;5;False;0;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;80;0;79;1
WireConnection;80;1;79;3
WireConnection;78;1;80;0
WireConnection;82;0;78;0
WireConnection;85;0;84;0
WireConnection;85;1;82;0
WireConnection;90;0;82;0
WireConnection;86;0;85;1
WireConnection;86;1;85;2
WireConnection;86;2;85;3
WireConnection;87;0;86;0
WireConnection;87;1;90;0
WireConnection;5;0;3;0
WireConnection;5;7;3;1
WireConnection;63;0;62;0
WireConnection;63;1;5;0
WireConnection;93;0;87;0
WireConnection;2;0;1;0
WireConnection;2;7;1;1
WireConnection;88;0;93;0
WireConnection;88;1;63;0
WireConnection;65;0;2;0
WireConnection;6;0;88;0
WireConnection;6;1;2;0
WireConnection;39;0;58;0
WireConnection;39;1;34;0
WireConnection;34;0;48;0
WireConnection;34;1;49;1
WireConnection;34;2;49;2
WireConnection;58;2;57;1
WireConnection;13;0;14;0
WireConnection;27;0;37;0
WireConnection;27;2;13;0
WireConnection;49;0;37;0
WireConnection;25;0;27;0
WireConnection;48;0;33;0
WireConnection;48;1;47;0
WireConnection;38;0;25;0
WireConnection;33;0;37;0
WireConnection;47;0;38;0
WireConnection;47;1;46;0
WireConnection;0;0;6;0
WireConnection;0;10;65;0
ASEEND*/
//CHKSM=E8908CC921F761F9C91F99DDC11D552906E56B40