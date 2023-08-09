#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;
Texture2D DistortionTexture;
float Magnitude;
float Time;

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
    float4 pos = input.Position;
	
    float2 offset = (input.TextureCoordinates.x + Time, input.TextureCoordinates.y + Time);
    float2 disp = tex2D(DistortionTextureSampler, offset).xy;
    disp = ((disp * 2.0f) - 1.0f) * Magnitude;	
    return tex2D(SpriteTextureSampler, (input.TextureCoordinates + disp)) * input.Color;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};