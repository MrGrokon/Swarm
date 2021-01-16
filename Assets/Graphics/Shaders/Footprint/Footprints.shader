// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Custom/Footprints"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Footprint_Mask("Footprint_Mask", 2D) = "white" {}
		_Active_Tint("Active_Tint", Color) = (0.4261292,1,0.3726415,1)
		_Active_Multiplier("Active_Multiplier", Range( 1 , 3)) = 1
		_Inactive_Tint("Inactive_Tint", Color) = (0.4716981,0.4716981,0.4716981,0.5803922)
		[Toggle]_IsActive("IsActive", Float) = 1
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
			float3 worldPos;
			float3 worldNormal;
			float2 uv_texcoord;
		};

		uniform float _IsActive;
		uniform float4 _Inactive_Tint;
		uniform float4 _Active_Tint;
		uniform float _Active_Multiplier;
		uniform sampler2D _Footprint_Mask;
		uniform float4 _Footprint_Mask_ST;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Emission = (( _IsActive )?( ( _Active_Tint * _Active_Multiplier ) ):( _Inactive_Tint )).rgb;
			float3 ase_worldPos = i.worldPos;
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 ase_worldNormal = i.worldNormal;
			float2 uv_Footprint_Mask = i.uv_texcoord * _Footprint_Mask_ST.xy + _Footprint_Mask_ST.zw;
			float4 tex2DNode4 = tex2D( _Footprint_Mask, uv_Footprint_Mask );
			float fresnelNdotV37 = dot( ase_worldNormal, ase_worldViewDir );
			float fresnelNode37 = ( 0.0 + tex2DNode4.a * pow( 1.0 - fresnelNdotV37, 5.0 ) );
			o.Alpha = fresnelNode37;
			clip( tex2DNode4.a - _Cutoff );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
-1687;73;1387;698;1008.186;163.7011;1.083424;True;True
Node;AmplifyShaderEditor.CommentaryNode;33;-1185.213,-450.0028;Inherit;False;671.1006;568.6964;Colors Chooser;5;27;24;26;23;22;;0.7410775,1,0.7122642,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;8;-1066.399,188.0163;Inherit;False;593.9999;258.6;Create a mask from the print PNJ;2;2;4;;1,1,1,1;0;0
Node;AmplifyShaderEditor.ColorNode;22;-1105.992,-150.8038;Inherit;False;Property;_Active_Tint;Active_Tint;2;0;Create;True;0;0;False;0;False;0.4261292,1,0.3726415,1;0.4261292,1,0.3726415,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;23;-1166.72,29.83878;Inherit;False;Property;_Active_Multiplier;Active_Multiplier;3;0;Create;True;0;0;False;0;False;1;1.3;1;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;2;-1014.552,241.1385;Inherit;True;Property;_Footprint_Mask;Footprint_Mask;1;0;Create;True;0;0;False;0;False;ff3b3466de8ccfb4b95275f0fd8dc703;31684d05d5b65774db4afadfa6b0b927;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.ColorNode;26;-1100.198,-397.8621;Inherit;False;Property;_Inactive_Tint;Inactive_Tint;4;0;Create;True;0;0;False;0;False;0.4716981,0.4716981,0.4716981,0.5803922;0.4716981,0.4716981,0.4716981,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;24;-877.9443,-67.72983;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;4;-772.79,242.2044;Inherit;True;Property;_TextureSample0;Texture Sample 0;1;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ToggleSwitchNode;27;-709.5131,-240.2784;Inherit;False;Property;_IsActive;IsActive;5;0;Create;True;0;0;False;0;False;1;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.FresnelNode;37;-400.9895,-114.6029;Inherit;True;Standard;WorldNormal;ViewDir;False;False;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;31;50.1084,-235.7665;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Custom/Footprints;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Transparent;;Geometry;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;1.6;0,0,0,0;VertexScale;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;24;0;22;0
WireConnection;24;1;23;0
WireConnection;4;0;2;0
WireConnection;27;0;26;0
WireConnection;27;1;24;0
WireConnection;37;2;4;4
WireConnection;31;2;27;0
WireConnection;31;9;37;0
WireConnection;31;10;4;4
ASEEND*/
//CHKSM=3BCCB19D33CDB1A28DB7FDE7CDDE06BF937CAC01