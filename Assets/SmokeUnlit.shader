#warning Upgrade NOTE: unity_Scale shader variable was removed; replaced '_WorldSpaceCameraPos.w' with '1.0'

Shader "Custom/SmokeUnlit"
{
    Properties
    {
        _TopColor ("Top Color", Color) = (1,0.5,0,1) // Orange
        _BottomColor ("Bottom Color", Color) = (1,0,0,1) // Red
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
LOD100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            fixed4_TopColor;
            fixed4 _BottomColor;

struct appdata
{
    float4 vertex : POSITION;
    float3 normal : NORMAL;
};

struct v2f
{
    float2 uv : TEXCOORD0;
    float4 vertex : SV_POSITION;
};

v2f vert(appdata v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
                // Interpolate the y position of the vertex relative to the object bounds
    float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
    float3 objectScale = float3(1.0, 1.0, 1.0) / 1.0;
    o.uv.y = saturate((worldPos.y + objectScale.y * 0.5) / objectScale.y);
    return o;
}

fixed4 frag(v2f i) : SV_Target
{
                // Linearly interpolate between the top and bottom colors based on the y coordinate
    return lerp(_BottomColor, _TopColor, i.uv.y);
}
            ENDCG
        }
    }
}
