
using System;

[Serializable]
public class RelegiAtributs
{
    RelegiAtributs()
    {
        close = EnumClouse.nofing;
        crest = EnumCrest.nofing;
        vapen = EnumVapen.nofing;

    }
    public EnumClouse close;
    public EnumCrest crest;
    public EnumVapen vapen;
}
