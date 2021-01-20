// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Custom/Footprints"
{
	Properties
	{
		_Footprint_Mask("Footprint_Mask", 2D) = "white" {}
		_Active_Tint("Active_Tint", Color) = (0.4261292,1,0.3726415,1)
		_Active_Multiplier("Active_Multiplier", Range( 1 , 3)) = 1
		_Inactive_Tint("Inactive_Tint", Color) = (0.4716981,0.4716981,0.4716981,0.5803922)
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		ACTIV("Activeness", Color) = (0,0,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha noshadow exclude_path:deferred 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float4 _Inactive_Tint;
		uniform float4 _Active_Tint;
		uniform float _Active_Multiplier;
		uniform float4 ACTIV;
		uniform sampler2D _Footprint_Mask;
		uniform float4 _Footprint_Mask_ST;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 lerpResult40 = lerp( _Inactive_Tint , ( _Active_Tint * _Active_Multiplier ) , ACTIV);
			o.Emission = lerpResult40.rgb;
			o.Alpha = 1;
			float2 uv_Footprint_Mask = i.uv_texcoord * _Footprint_Mask_ST.xy + _Footprint_Mask_ST.zw;
			clip( tex2D( _Footprint_Mask, uv_Footprint_Mask ).a - _Cutoff );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
0;40;1920;1013;1712.652;701.145;1;True;True
Node;AmplifyShaderEditor.CommentaryNode;33;-1274.813,-550.7027;Inherit;False;815.9407;566.9365;Colors Chooser;6;26;23;22;24;40;41;;0.7410775,1,0.7122642,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;8;-1049.155,51.9781;Inherit;False;593.9999;258.6;Create a mask from the print PNJ;2;2;4;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;23;-1260,-175;Inherit;False;Property;_Active_Multiplier;Active_Multiplier;2;0;Create;True;0;0;False;0;False;1;3;1;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;22;-1196,-351;Inherit;False;Property;_Active_Tint;Active_Tint;1;0;Create;True;0;0;False;0;False;0.4261292,1,0.3726415,1;0.4261292,1,0.3726415,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexturePropertyNode;2;-997.3079,105.1003;Inherit;True;Property;_Footprint_Mask;Footprint_Mask;0;0;Create;True;0;0;False;0;False;None;b615e3cef8f7f5c428791d9ba54ec7c9;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.ColorNode;26;-979,-509;Inherit;False;Property;_Inactive_Tint;Inactive_Tint;3;0;Create;True;0;0;False;0;False;0.4716981,0.4716981,0.4716981,0.5803922;0.3396226,0.256597,0.1073336,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;24;-935.9199,-338.2801;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;41;-959.7643,-173.9304;Inherit;False;Property;ACTIV;Activeness;5;0;Create;False;0;0;False;0;False;0,0,0,0;1,0,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;40;-700,-415;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;4;-755.5458,106.1662;Inherit;True;Property;_TextureSample0;Texture Sample 0;1;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;45;-362.652,-839.145;Inherit;False;Constant;_Color0;Color 0;6;0;Create;True;0;0;False;0;False;1,0,0,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;47;-317.652,-505.145;Inherit;False;Constant;_Float0;Float 0;6;0;Create;True;0;0;False;0;False;50;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;46;-154.652,-636.145;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;31;50.1084,-235.7665;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Custom/Footprints;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Transparent;;Geometry;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;1.6;0,0,0,0;VertexScale;True;False;Cylindrical;False;Relative;0;;4;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;24;0;22;0
WireConnection;24;1;23;0
WireConnection;40;0;26;0
WireConnection;40;1;24;0
WireConnection;40;2;41;0
WireConnection;4;0;2;0
WireConnection;46;0;45;0
WireConnection;46;1;47;0
WireConnection;31;2;40;0
WireConnection;31;10;4;4
ASEEND*/
//CHKSM=8BEF795B0369AE55DB2B59133A48A135D8124C26