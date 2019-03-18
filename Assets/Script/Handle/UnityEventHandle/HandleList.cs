using System;
using System.Collections.Generic;

public static class HandleList
{
    public static Dictionary<string, Type> dictionary = new Dictionary<string, Type>()
    {
        { "Click", typeof(UIClickHandle) },
        { "MouseInOut", typeof(UIMouseInOutHandle) },
    };
}