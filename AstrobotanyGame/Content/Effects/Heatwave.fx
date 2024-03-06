#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

uniform Texture2D SpriteTexture;
uniform Texture2D DistortionTexture;
uniform float1 Time;
uniform float1 Magnitude;
uniform float1 Scale;
uniform float2 Offset;

sampler2D SpriteTextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};
sampler2D DistortionTextureSampler = sampler_state
{
    Texture = <DistortionTexture>;
};


struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR
{
    float2 pos = float2((input.TextureCoordinates.x + Offset.x) * Scale + Time,
						(input.TextureCoordinates.y + Offset.y) * Scale);
	
    float2 disp = ((tex2D(DistortionTextureSampler, pos).xy * 2.0f) - 1.0f) * Magnitude;
	
    return tex2D(SpriteTextureSampler, (input.TextureCoordinates + disp)) * input.Color;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};