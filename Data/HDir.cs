using System;
using System.Collections.Generic;
using System.Text;

namespace Pleer.Data;

public class HDir
{
    public string Name { get; set; }
    public string Path { get; set; }

    public HDir(string name, string path)
    {
        Name = name;
        Path = path;
    }
}
