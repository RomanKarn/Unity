Shader "SnoySledUpdate"
{
  Properties
    {
        _DrawBrush ("Brush",2D)= "white" {}
        _SceilSled ("Brush",float)= 0.05
        _SkeilNois ("Brush",float)= 15
    }

    SubShader
    {
        Lighting Off
        Blend One Zero
        
        Pass
        {
            CGPROGRAM
            #include "UnityCustomRenderTexture.cginc"
            #pragma vertex CustomRenderTextureVertexShader
            #pragma fragment frag
            #pragma target 4.6
            
            sampler2D _DrawBrush;
            float4 _DrawPosition;
            float _DrawAngle;
            float _ReastorAmouth;

            float _SceilSled;
            float _SkeilNois;

            float randomLocal(float x)
            {
                float s =sin(x);
                return frac(s * 65124.6234125);
            }

             float random(float2 p)
            {
                float d = dot(p, float2(11.52346,54.6341));
                float s = sin(d);
                return frac(s * 65124.6234125);
            }

            float noise(float2 uv)
            {
                float2 id = floor(uv);
                float2 f = frac(uv);

                float a =random(id);
                float b =random(id+ float2(1.0,0.0));      
                float c =random(id+ float2(0.0,1.0));
                float d =random(id+ float2(1.0,1.0));

                float2 u = f * f *(3.0-2.0 *f);

                float x1 = lerp(a,b,u.x);
                float x2 = lerp(c,d,u.x);
                return lerp(x1,x2,u.y);
            }

            float4 frag(v2f_customrendertexture IN) : COLOR
            {
                float4 previousColor = tex2D(_SelfTexture2D, IN.localTexcoord.xy);
                float2 pos = IN.localTexcoord.xy - _DrawPosition;

                float2x2 rot = float2x2(cos(_DrawAngle), -sin(_DrawAngle), sin(_DrawAngle), cos(_DrawAngle));
                
                pos =mul(rot,pos);
                pos/=_SceilSled;
                pos+=float2(0.5,0.5);
                float4 drawColor =tex2D(_DrawBrush, pos); 
                
                float2 uv = IN.localTexcoord.xy * _SkeilNois;
                float col =noise(uv);
                float idx =floor(uv.x);

                float gvx =frac(uv.x);
                float rnd1 = randomLocal(idx);
                float rnd2 = randomLocal(idx + 1);
                float colEnd =lerp(rnd1,rnd2,gvx);

                if(IN.localTexcoord.y<0.001)
                {
                    return colEnd;
                }
                if(IN.localTexcoord.y>0.999)
                {
                    return colEnd;
                }
                if( IN.localTexcoord.y >= _DrawPosition.y+0.2)    
                {
                    return fixed4(col,col,col,1);
                }
                 if((IN.localTexcoord.y+0.01 <= _DrawPosition.y)&&(_DrawPosition.y<0.8))    
                {
                    return fixed4(col,col,col,1);
                }
                return min(previousColor,drawColor);
            }
            ENDCG
        }
    }
}
