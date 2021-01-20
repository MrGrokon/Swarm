// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Unlit/Water"
{
	Properties
	{
		_BaseWater_Color("BaseWater_Color", Color) = (0.4229263,0.7389114,0.9056604,1)
		_TurbulenceSpeed("Turbulence Speed", Range( 0.1 , 5)) = 1.54
		_Turbulence_Color("Turbulence_Color", Color) = (0.8726415,1,0.9814351,1)
		_BaseScale("Base Scale", Range( 0 , 10)) = 10
		_DecalStrength("Decal Strength", Float) = 0.2
		_BaseOpacity("Base Opacity", Range( 0.2 , 1)) = 0.2
		_TurbulenceIntenssity("Turbulence Intenssity", Range( 0 , 3)) = 1.344581
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _DecalStrength;
		uniform float _BaseScale;
		uniform float _TurbulenceSpeed;
		uniform float _TurbulenceIntenssity;
		uniform float4 _BaseWater_Color;
		uniform float4 _Turbulence_Color;
		uniform float _BaseOpacity;


		float2 voronoihash4( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi4( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash4( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
					float d = 0.5 * dot( r, r );
			 		if( d<F1 ) {
			 			F2 = F1;
			 			F1 = d; mg = g; mr = r; id = o;
			 		} else if( d<F2 ) {
			 			F2 = d;
			 		}
			 	}
			}
			return F1;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_vertex3Pos = v.vertex.xyz;
			float3 break51 = ase_vertex3Pos;
			float mulTime10 = _Time.y * _TurbulenceSpeed;
			float time4 = mulTime10;
			float2 temp_output_1_0_g1 = v.texcoord.xy;
			float2 temp_output_11_0_g1 = ( temp_output_1_0_g1 - float2( 0.5,0.5 ) );
			float2 break18_g1 = temp_output_11_0_g1;
			float2 appendResult19_g1 = (float2(break18_g1.y , -break18_g1.x));
			float dotResult12_g1 = dot( temp_output_11_0_g1 , temp_output_11_0_g1 );
			float2 coords4 = ( temp_output_1_0_g1 + ( appendResult19_g1 * ( dotResult12_g1 * float2( 2,2 ) ) ) + float2( 0,0 ) ) * ( _BaseScale + ( _SinTime.z * 1.11 ) );
			float2 id4 = 0;
			float2 uv4 = 0;
			float fade4 = 0.5;
			float voroi4 = 0;
			float rest4 = 0;
			for( int it4 = 0; it4 <2; it4++ ){
			voroi4 += fade4 * voronoi4( coords4, time4, id4, uv4, 0 );
			rest4 += fade4;
			coords4 *= 2;
			fade4 *= 0.5;
			}//Voronoi4
			voroi4 /= rest4;
			float temp_output_14_0 = pow( ( voroi4 * _TurbulenceIntenssity ) , 1.97 );
			float3 appendResult50 = (float3(break51.x , (-1.0 + (( ase_vertex3Pos.y + ( _DecalStrength * temp_output_14_0 ) ) - 0.0) * (1.0 - -1.0) / (1.0 - 0.0)) , break51.z));
			v.vertex.xyz += appendResult50;
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Albedo = _BaseWater_Color.rgb;
			float mulTime10 = _Time.y * _TurbulenceSpeed;
			float time4 = mulTime10;
			float2 temp_output_1_0_g1 = i.uv_texcoord;
			float2 temp_output_11_0_g1 = ( temp_output_1_0_g1 - float2( 0.5,0.5 ) );
			float2 break18_g1 = temp_output_11_0_g1;
			float2 appendResult19_g1 = (float2(break18_g1.y , -break18_g1.x));
			float dotResult12_g1 = dot( temp_output_11_0_g1 , temp_output_11_0_g1 );
			float2 coords4 = ( temp_output_1_0_g1 + ( appendResult19_g1 * ( dotResult12_g1 * float2( 2,2 ) ) ) + float2( 0,0 ) ) * ( _BaseScale + ( _SinTime.z * 1.11 ) );
			float2 id4 = 0;
			float2 uv4 = 0;
			float fade4 = 0.5;
			float voroi4 = 0;
			float rest4 = 0;
			for( int it4 = 0; it4 <2; it4++ ){
			voroi4 += fade4 * voronoi4( coords4, time4, id4, uv4, 0 );
			rest4 += fade4;
			coords4 *= 2;
			fade4 *= 0.5;
			}//Voronoi4
			voroi4 /= rest4;
			float temp_output_14_0 = pow( ( voroi4 * _TurbulenceIntenssity ) , 1.97 );
			float clampResult85 = clamp( temp_output_14_0 , 0.0 , 1.0 );
			o.Emission = ( clampResult85 * _Turbulence_Color ).rgb;
			o.Alpha = (_BaseOpacity + (( temp_output_14_0 * 10.0 ) - 0.0) * (1.0 - _BaseOpacity) / (1.0 - 0.0));
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard alpha:fade keepalpha fullforwardshadows exclude_path:deferred vertex:vertexDataFunc 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				vertexDataFunc( v, customInputData );
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
233;73;1387;742;2098.29;589.7885;1.682941;True;True
Node;AmplifyShaderEditor.CommentaryNode;20;-2432.218,77.0051;Inherit;False;1387.403;503.752;Turbulence Occilation;12;13;4;10;55;19;17;18;56;15;16;14;90;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SinTimeNode;16;-2399.361,420.6266;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;15;-2414.619,275.7976;Inherit;False;Property;_TurbulenceSpeed;Turbulence Speed;1;0;Create;True;0;0;False;0;False;1.54;1.88;0.1;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-2238.62,387.7975;Inherit;False;Property;_BaseScale;Base Scale;3;0;Create;True;0;0;False;0;False;10;5.49;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;17;-2238.62,467.7974;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;1.11;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;56;-2350.619,131.7975;Inherit;False;Constant;_Vector3;Vector 3;4;0;Create;True;0;0;False;0;False;2,2;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;10;-2158.621,291.7976;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;55;-2169.621,140.7975;Inherit;False;Radial Shear;-1;;1;c6dc9fc7fa9b08c4d95138f2ae88b526;0;4;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;19;-2078.621,387.7975;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;4;-1910.401,188.6657;Inherit;True;0;0;1;0;2;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;2.61;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;90;-1936.076,491.5938;Inherit;False;Property;_TurbulenceIntenssity;Turbulence Intenssity;7;0;Create;True;0;0;False;0;False;1.344581;0;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;-1631.454,291.6487;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;1.05;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;35;-901.5489,588.7656;Inherit;False;973.2345;415.884;Wave Vertex Displacement;8;50;29;30;52;51;49;38;91;;1,0.8267176,0.3160377,1;0;0
Node;AmplifyShaderEditor.PowerNode;14;-1404.334,290.0052;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;1.97;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;29;-840.7012,798.7909;Inherit;False;Property;_DecalStrength;Decal Strength;4;0;Create;True;0;0;False;0;False;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;91;-878.0261,870.1359;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;38;-762.8671,629.6381;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;30;-645.2149,826.1084;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;49;-472.3195,783.4431;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;51;-538.3195,631.4431;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.CommentaryNode;60;-780.6552,274.1664;Inherit;False;847.1987;273.3342;Opacity Map;3;94;62;57;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;28;-453.6246,-279.0983;Inherit;False;493.1463;498.8436;Coloring;4;85;2;21;1;;0.3443396,1,0.9358258,1;0;0
Node;AmplifyShaderEditor.WireNode;96;-920.5381,202.2889;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;52;-306.213,780.9919;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;-1;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;2;-391.1431,47.72183;Inherit;False;Property;_Turbulence_Color;Turbulence_Color;2;0;Create;True;0;0;False;0;False;0.8726415,1,0.9814351,1;0.8726415,1,0.9814351,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;64;-1488.085,-343.3432;Inherit;False;547;173;Detect collision worldspace;2;68;76;;1,1,1,1;0;0
Node;AmplifyShaderEditor.DynamicAppendNode;50;-60.14807,633.6154;Inherit;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ClampOpNode;85;-305.6602,-76.38937;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;57;-497.821,443.8081;Inherit;False;Property;_BaseOpacity;Base Opacity;5;0;Create;True;0;0;False;0;False;0.2;0.2;0.2;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;94;-741.6053,321.4813;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.DepthFade;76;-1182.147,-286.0963;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;87;-914.9709,-286.2054;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;79;-668.6167,-78.26064;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;99;-1224.599,-139.0751;Inherit;True;2;0;FLOAT;0.05;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;68;-1477.148,-258.0963;Inherit;False;Property;_RiveOffset;Rive Offset;6;0;Create;True;0;0;False;0;False;0.2;0.2;0;100;0;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;53;90.54941,380.3004;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TFHCRemapNode;62;-197.8624,314.0816;Inherit;True;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;-89.89519,67.07187;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;1;-176.4519,-238.3098;Inherit;False;Property;_BaseWater_Color;BaseWater_Color;0;0;Create;True;0;0;False;0;False;0.4229263,0.7389114,0.9056604,1;0.3517711,0.6778366,0.8773585,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;86;-711.4098,-219.2825;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;3;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;161.8207,-2.523206;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Unlit/Water;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
Node;AmplifyShaderEditor.CommentaryNode;63;-1210.351,833.8875;Inherit;False;269;100;Remplacer par un gradient noize;0;;1,1,1,1;0;0
WireConnection;17;0;16;3
WireConnection;10;0;15;0
WireConnection;55;3;56;0
WireConnection;19;0;18;0
WireConnection;19;1;17;0
WireConnection;4;0;55;0
WireConnection;4;1;10;0
WireConnection;4;2;19;0
WireConnection;13;0;4;0
WireConnection;13;1;90;0
WireConnection;14;0;13;0
WireConnection;91;0;14;0
WireConnection;30;0;29;0
WireConnection;30;1;91;0
WireConnection;49;0;38;2
WireConnection;49;1;30;0
WireConnection;51;0;38;0
WireConnection;96;0;14;0
WireConnection;52;0;49;0
WireConnection;50;0;51;0
WireConnection;50;1;52;0
WireConnection;50;2;51;2
WireConnection;85;0;96;0
WireConnection;94;0;96;0
WireConnection;76;0;68;0
WireConnection;87;0;76;0
WireConnection;99;1;14;0
WireConnection;53;0;50;0
WireConnection;62;0;94;0
WireConnection;62;3;57;0
WireConnection;21;0;85;0
WireConnection;21;1;2;0
WireConnection;86;0;87;0
WireConnection;0;0;1;0
WireConnection;0;2;21;0
WireConnection;0;9;62;0
WireConnection;0;11;53;0
ASEEND*/
//CHKSM=98A86C1908CD856B052D8033882744363E38C883