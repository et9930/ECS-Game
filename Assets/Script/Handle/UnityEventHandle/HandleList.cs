using System;
using System.Collections.Generic;

public static class HandleList
{
    public static Dictionary<string, Type> dictionary = new Dictionary<string, Type>()
    {
        { "Click", typeof(ClickHandle) },
        { "MouseInOut", typeof(MouseInOutHandle) },
    };
}