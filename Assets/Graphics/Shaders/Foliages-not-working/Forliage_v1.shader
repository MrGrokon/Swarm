// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Custom/Foliage_v1"
{
	Properties
	{
		_Base_Texture("Base_Texture", 2D) = "white" {}
		_Tint("Tint", Color) = (1,1,1,0)
		_TimeMultiplier("TimeMultiplier", Range( 0 , 1)) = 0
		_Axis_Motion("Axis_Motion", Vector) = (0.8,0.3,0.8,0)
		_Overall_Noise_Scaling("Overall_Noise_Scaling", Range( 1 , 10)) = 2.8
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float3 worldPos;
			float2 uv_texcoord;
		};

		uniform float _TimeMultiplier;
		uniform float3 _Axis_Motion;
		uniform float _Overall_Noise_Scaling;
		uniform float4 _Tint;
		uniform sampler2D _Base_Texture;
		uniform float4 _Base_Texture_ST;


		float2 UnityGradientNoiseDir( float2 p )
		{
			p = fmod(p , 289);
			float x = fmod((34 * p.x + 1) * p.x , 289) + p.y;
			x = fmod( (34 * x + 1) * x , 289);
			x = frac( x / 41 ) * 2 - 1;
			return normalize( float2(x - floor(x + 0.5 ), abs( x ) - 0.5 ) );
		}
		
		float UnityGradientNoise( float2 UV, float Scale )
		{
			float2 p = UV * Scale;
			float2 ip = floor( p );
			float2 fp = frac( p );
			float d00 = dot( UnityGradientNoiseDir( ip ), fp );
			float d01 = dot( UnityGradientNoiseDir( ip + float2( 0, 1 ) ), fp - float2( 0, 1 ) );
			float d10 = dot( UnityGradientNoiseDir( ip + float2( 1, 0 ) ), fp - float2( 1, 0 ) );
			float d11 = dot( UnityGradientNoiseDir( ip + float2( 1, 1 ) ), fp - float2( 1, 1 ) );
			fp = fp * fp * fp * ( fp * ( fp * 6 - 15 ) + 10 );
			return lerp( lerp( d00, d01, fp.y ), lerp( d10, d11, fp.y ), fp.x ) + 0.5;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_vertex3Pos = v.vertex.xyz;
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float3 objToWorld90 = mul( unity_ObjectToWorld, float4( ase_worldPos, 1 ) ).xyz;
			float2 appendResult86 = (float2(objToWorld90.x , objToWorld90.z));
			float mulTime96 = _Time.y * 0.31;
			float gradientNoise82 = UnityGradientNoise((appendResult86*1.0 + mulTime96),_Overall_Noise_Scaling);
			float temp_output_92_0 = pow( gradientNoise82 , 1.93 );
			float clampResult98 = clamp( temp_output_92_0 , 0.1 , temp_output_92_0 );
			v.vertex.xyz += ( ase_vertex3Pos + ( ( ase_vertex3Pos.y * ( _TimeMultiplier * _SinTime.w ) ) * ( _Axis_Motion * clampResult98 ) ) );
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Base_Texture = i.uv_texcoord * _Base_Texture_ST.xy + _Base_Texture_ST.zw;
			o.Albedo = ( _Tint * tex2D( _Base_Texture, uv_Base_Texture ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
231;73;1296;742;431.4419;597.5631;1;True;True
Node;AmplifyShaderEditor.WorldPosInputsNode;91;-1644.83,916.7655;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TransformPositionNode;90;-1446.158,906.454;Inherit;False;Object;World;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DynamicAppendNode;86;-1234.335,930.4275;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleTimeNode;96;-1368.197,1064.209;Inherit;False;1;0;FLOAT;0.31;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;93;-1110.467,1057.629;Inherit;False;Property;_Overall_Noise_Scaling;Overall_Noise_Scaling;4;0;Create;True;0;0;False;0;False;2.8;1;1;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;95;-1071.422,921.5602;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;82;-828.4349,943.2236;Inherit;True;Gradient;False;True;2;0;FLOAT2;0,0;False;1;FLOAT;5.28;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;92;-593.9792,948.1753;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;1.93;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;18;-549.083,372.0079;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SinTimeNode;19;-581.0174,663.6295;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;8;-717.5649,583.1483;Inherit;False;Property;_TimeMultiplier;TimeMultiplier;2;0;Create;True;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;98;-333.8294,936.2343;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.1;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;54;-367.3936,695.2769;Inherit;False;Property;_Axis_Motion;Axis_Motion;3;0;Create;True;0;0;False;0;False;0.8,0.3,0.8;1,0.3,1;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;77;-370.6316,590.6017;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;79;-302.473,504.1682;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;84;-131.4116,708.9448;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;20;-205.4387,569.0619;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;2;-476.279,58.55529;Inherit;True;Property;_Base_Texture;Base_Texture;0;0;Create;True;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;81;-44.64499,568.5856;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;3;-161.7983,-123.5;Inherit;False;Property;_Tint;Tint;1;0;Create;True;0;0;False;0;False;1,1,1,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-222.8216,58.49912;Inherit;True;Property;_TextureSample0;Texture Sample 0;0;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NoiseGeneratorNode;100;-6.408691,-405.631;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;22;165.5422,370.3025;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;93.30184,8.246861;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.WorldPosInputsNode;101;-205.9294,-394.8203;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;308.5772,84.90864;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Custom/Foliage_v1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
Node;AmplifyShaderEditor.CommentaryNode;32;-737.6789,527.7896;Inherit;False;837.3665;318.4132;Create an offset position depending on the Y posiition of my vertex;0;;0.9716981,0.8532158,0.4445977,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;5;-499.5549,-168.3045;Inherit;False;727.2025;425.5102;Texturing;0;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;99;-1667.021,863.2969;Inherit;False;1481.186;310.7017;Randomisation du mouvement;0;;1,1,1,1;0;0
WireConnection;90;0;91;0
WireConnection;86;0;90;1
WireConnection;86;1;90;3
WireConnection;95;0;86;0
WireConnection;95;2;96;0
WireConnection;82;0;95;0
WireConnection;82;1;93;0
WireConnection;92;0;82;0
WireConnection;98;0;92;0
WireConnection;98;2;92;0
WireConnection;77;0;8;0
WireConnection;77;1;19;4
WireConnection;79;0;18;2
WireConnection;84;0;54;0
WireConnection;84;1;98;0
WireConnection;20;0;79;0
WireConnection;20;1;77;0
WireConnection;81;0;20;0
WireConnection;81;1;84;0
WireConnection;1;0;2;0
WireConnection;100;0;101;0
WireConnection;22;0;18;0
WireConnection;22;1;81;0
WireConnection;4;0;3;0
WireConnection;4;1;1;0
WireConnection;0;0;4;0
WireConnection;0;11;22;0
ASEEND*/
//CHKSM=F3E68B817E06720CE48881BF4B9ACEC9001676F4