#define UNITY_UV_STARTS_AT_TOP 1
#define UNITY_REVERSED_Z 1
#define UNITY_GATHER_SUPPORTED (SHADER_TARGET >= 50)
#define UNITY_CAN_READ_POSITION_IN_FRAGMENT_PROGRAM 1
#define INTRINSIC_MINMAX3
#define Min3 min3
#define Max3 max3

#define TEXTURE2D_SAMPLER2D(textureName, samplerName) Texture2D textureName; SamplerState samplerName
#define TEXTURE3D_SAMPLER3D(textureName, samplerName) Texture3D textureName; SamplerState samplerName
#define TEXTURE2D_ARRAY_SAMPLER2D(textureName, samplerName) Texture2DArray textureName; SamplerState samplerName

#define TEXTURE2D(textureName) Texture2D textureName
#define SAMPLER2D(samplerName) SamplerState samplerName
#define TEXTURE2D_ARRAY(textureName) Texture2DArray textureName

#define TEXTURE3D(textureName) Texture3D textureName
#define SAMPLER3D(samplerName) SamplerState samplerName

#define TEXTURE2D_ARGS(textureName, samplerName) Texture2D textureName, SamplerState samplerName
#define TEXTURE2D_PARAM(textureName, samplerName) textureName, samplerName

#define TEXTURE3D_ARGS(textureName, samplerName) Texture3D textureName, SamplerState samplerName
#define TEXTURE3D_PARAM(textureName, samplerName) textureName, samplerName

#define TEXTURE2D_ARRAY_ARGS(textureName, samplerName) Texture2DArray textureName, SamplerState samplerName
#define TEXTURE2D_ARRAY_PARAM(textureName, samplerName) textureName, samplerName

#define SAMPLE_TEXTURE2D(textureName, samplerName, coord2) textureName.Sample(samplerName, coord2)
#define SAMPLE_TEXTURE2D_LOD(textureName, samplerName, coord2, lod) textureName.SampleLevel(samplerName, coord2, lod)
#define SAMPLE_TEXTURE2D_LOD_OFF(textureName, samplerName, coord2, lod, offset) textureName.SampleLevel(samplerName, coord2, lod, offset)
#define SAMPLE_TEXTURE2D_ARRAY(textureName, samplerName, coord2, index) textureName.Sample(samplerName, float3(coord2, index))
#define SAMPLE_TEXTURE2D_ARRAY_LOD(textureName, samplerName, coord2, index, lod) textureName.SampleLevel(samplerName, float3(coord2, index), lod)
#define SAMPLE_TEXTURE2D_ARRAY_LOD_OFF(textureName, samplerName, coord2, index, lod, offset) textureName.SampleLevel(samplerName, float3(coord2, index), lod, offset)

#define SAMPLE_TEXTURE3D(textureName, samplerName, coord3) textureName.Sample(samplerName, coord3)

#define LOAD_TEXTURE2D(textureName, texelSize, icoord2) textureName.Load(int3(icoord2, 0))
#define LOAD_TEXTURE2D_LOD(textureName, texelSize, icoord2) textureName.Load(int3(icoord2, lod))

#define GATHER_TEXTURE2D(textureName, samplerName, coord2) textureName.Gather(samplerName, coord2)
#define GATHER_RED_TEXTURE2D(textureName, samplerName, coord2) textureName.GatherRed(samplerName, coord2)
#define GATHER_GREEN_TEXTURE2D(textureName, samplerName, coord2) textureName.GatherGreen(samplerName, coord2)
#define GATHER_BLUE_TEXTURE2D(textureName, samplerName, coord2) textureName.GatherBlue(samplerName, coord2)
#define GATHER_ALPHA_TEXTURE2D(textureName, samplerName, coord2) textureName.GatherAlpha(samplerName, coord2)

#define GATHER_TEXTURE2D_OFF(textureName, samplerName, coord2, offset) textureName.Gather(samplerName, coord2, offset)
#define GATHER_RED_TEXTURE2D_OFF(textureName, samplerName, coord2, offset) textureName.GatherRed(samplerName, coord2, offset)
#define GATHER_GREEN_TEXTURE2D_OFF(textureName, samplerName, coord2, offset) textureName.GatherGreen(samplerName, coord2, offset)
#define GATHER_BLUE_TEXTURE2D_OFF(textureName, samplerName, coord2, offset) textureName.GatherBlue(samplerName, coord2, offset)
#define GATHER_ALPHA_TEXTURE2D_OFF(textureName, samplerName, coord2, offset) textureName.GatherAlpha(samplerName, coord2, offset)

#define GATHER_TEXTURE2D_ARRAY(textureName, samplerName, coord2, index) textureName.Gather(samplerName, float3(coord2, index))
#define GATHER_RED_TEXTURE2D_ARRAY(textureName, samplerName, coord2, index) textureName.GatherRed(samplerName, float3(coord2, index))
#define GATHER_GREEN_TEXTURE2D_ARRAY(textureName, samplerName, coord2, index) textureName.GatherGreen(samplerName, float3(coord2, index))
#define GATHER_BLUE_TEXTURE2D_ARRAY(textureName, samplerName, coord2, index) textureName.GatherBlue(samplerName, float3(coord2, index))
#define GATHER_ALPHA_TEXTURE2D_ARRAY(textureName, samplerName, coord2) textureName.GatherAlpha(samplerName, float3(coord2, index))

#define GATHER_TEXTURE2D_ARRAY_OFF(textureName, samplerName, coord2, index, offset) textureName.Gather(samplerName, float3(coord2, index), offset)
#define GATHER_RED_TEXTURE2D_ARRAY_OFF(textureName, samplerName, coord2, index, offset) textureName.GatherRed(samplerName, float3(coord2, index), offset)
#define GATHER_GREEN_TEXTURE2D_ARRAY_OFF(textureName, samplerName, coord2, index, offset) textureName.GatherGreen(samplerName, float3(coord2, index), offset)
#define GATHER_BLUE_TEXTURE2D_ARRAY_OFF(textureName, samplerName, coord2, index, offset) textureName.GatherBlue(samplerName, float3(coord2, index), offset)
#define GATHER_ALPHA_TEXTURE2D_ARRAY_OFF(textureName, samplerName, coord2, offset) textureName.GatherAlpha(samplerName, float3(coord2, index), offset)

#define SAMPLE_DEPTH_TEXTURE(textureName, samplerName, coord2) SAMPLE_TEXTURE2D(textureName, samplerName, coord2).r
#define SAMPLE_DEPTH_TEXTURE_LOD(textureName, samplerName, coord2, lod) SAMPLE_TEXTURE2D_LOD(textureName, samplerName, coord2, lod).r
#define SAMPLE_DEPTH_TEXTURE_ARRAY(textureName, samplerName, coord2, index) SAMPLE_TEXTURE2D_ARRAY(textureName, samplerName, coord2, index).r
#define SAMPLE_DEPTH_TEXTURE_ARRAY_LOD(textureName, samplerName, coord2, index, lod) SAMPLE_TEXTURE2D_ARRAY_LOD(textureName, samplerName, coord2, index, lod).r

#define UNITY_BRANCH    [branch]
#define UNITY_FLATTEN   [flatten]
#define UNITY_UNROLL    [unroll]
#define UNITY_LOOP      [loop]
#define UNITY_FASTOPT   [fastopt]

#define CBUFFER_START(name) ConstantBuffer name {
#define CBUFFER_END };

#if UNITY_GATHER_SUPPORTED
    #define FXAA_HLSL_5 1
    #define SMAA_HLSL_4_1 1
#else
    #define FXAA_HLSL_4 1
    #define SMAA_HLSL_4 1
#endif
