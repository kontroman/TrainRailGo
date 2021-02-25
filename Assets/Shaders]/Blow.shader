Shader "Custom/Atmosphere" {
    Properties{
        _Color("Color", Color) = (1,1,1,1)
        _Size("Atmosphere Size Multiplier", Range(0,16)) = 4
        _Rim("Fade Power", Range(0,8)) = 4
    }
        SubShader{
            Tags { "RenderType" = "Transparent" }
            LOD 200

            Cull Front

            CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert fullforwardshadows alpha:fade
        #pragma vertex vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0


        struct Input {
            float3 viewDir;
        };

        half _Size;
        half _Rim;
        fixed4 _Color;

        void vert(inout appdata_full v) {
            v.vertex.xyz += v.vertex.xyz * _Size / 10;
            v.normal *= -1;
        }

        void surf(Input IN, inout SurfaceOutput o) {
            half rim = saturate(dot(normalize(IN.viewDir), normalize(o.Normal)));

            // Albedo comes from a texture tinted by color
            fixed4 c = _Color;
            o.Emission = c.rgb;
            o.Alpha = lerp(0, 1, pow(rim, _Rim));
        }
        ENDCG
    }
        FallBack "Diffuse"
}