// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Custom/Skybox"
{
	Properties
	{
		_MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		_StarsMask("Stars Mask", 2D) = "white" {}
		_StarColor("Star Color", Color) = (1,0.9647437,0.5801887,1)
		_Background_Color("Background_Color", Color) = (0.3820755,0.7969425,1,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}

	}
	
	SubShader
	{
		Tags { "RenderType"="Opaque" }
	LOD 100
		Cull Off

		
		Pass
		{
			CGPROGRAM
			
			#pragma target 3.0 
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			

			struct appdata
			{
				float4 vertex : POSITION;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
				
			};

			uniform sampler2D _MainTex;
			uniform fixed4 _Color;
			uniform sampler2D _StarsMask;
			uniform float4 _StarsMask_ST;
			uniform float4 _StarColor;
			uniform float4 _Background_Color;

			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.texcoord.xy = v.texcoord.xy;
				o.texcoord.zw = v.texcoord1.xy;
				
				// ase common template code
				
				
				v.vertex.xyz +=  float3(0,0,0) ;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			fixed4 frag (v2f i ) : SV_Target
			{
				fixed4 myColorVar;
				// ase common template code
				float2 uv_StarsMask = i.texcoord.xy * _StarsMask_ST.xy + _StarsMask_ST.zw;
				float4 tex2DNode5 = tex2D( _StarsMask, uv_StarsMask );
				float3 appendResult7 = (float3(tex2DNode5.r , tex2DNode5.g , tex2DNode5.b));
				float4 clampResult11 = clamp( ( ( float4( appendResult7 , 0.0 ) * _StarColor ) + _Background_Color ) , float4( 0,0,0,0 ) , float4( 1,1,1,0 ) );
				
				
				myColorVar = clampResult11;
				return myColorVar;
			}
			ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=18500
231;73;1296;742;689.1089;451.6852;1;True;True
Node;AmplifyShaderEditor.TexturePropertyNode;2;-908.1667,-335.8692;Inherit;True;Property;_StarsMask;Stars Mask;0;0;Create;True;0;0;False;0;False;55c081a14d5ef0044b0b0710145a433f;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SamplerNode;5;-653.1667,-336.8692;Inherit;True;Property;_TextureSample0;Texture Sample 0;2;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;7;-344.8558,-306.1367;Inherit;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;3;-566.7669,-140.7694;Inherit;False;Property;_StarColor;Star Color;1;0;Create;True;0;0;False;0;False;1,0.9647437,0.5801887,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;9;-253.0149,-79.9386;Inherit;False;Property;_Background_Color;Background_Color;2;0;Create;True;0;0;False;0;False;0.3820755,0.7969425,1,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;-189.3558,-222.4373;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;10;-24.99561,-175.3749;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ClampOpNode;11;138.0044,-145.3749;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,1,1,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1;348,-151;Float;False;True;-1;2;ASEMaterialInspector;100;3;Custom/Skybox;6e114a916ca3e4b4bb51972669d463bf;True;SubShader 0 Pass 0;0;0;SubShader 0 Pass 0;2;False;False;False;False;False;False;False;False;False;True;2;False;-1;False;False;False;False;False;False;False;False;True;1;RenderType=Opaque=RenderType;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;0;;0;0;Standard;0;0;1;True;False;;False;0
WireConnection;5;0;2;0
WireConnection;5;7;2;1
WireConnection;7;0;5;1
WireConnection;7;1;5;2
WireConnection;7;2;5;3
WireConnection;6;0;7;0
WireConnection;6;1;3;0
WireConnection;10;0;6;0
WireConnection;10;1;9;0
WireConnection;11;0;10;0
WireConnection;1;0;11;0
ASEEND*/
//CHKSM=BB10FDDB4C4E5B575A0D2DDDA78A66DCA208C098