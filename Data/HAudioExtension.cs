using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pleer.Data;

public class HAudioExtension
{
    public enum Format
    {
        mp3,
        wav,
        aiff,
        ogg,
    }

    public static List<string> Exes()
    {
        var result = new List<string>();
        string[] names = Enum.GetNames(typeof(Format));
        foreach (var name in names)
        {
            var r = "." + name.ToLower();
            result.Add(r);
        }
        return result;
    }
}
