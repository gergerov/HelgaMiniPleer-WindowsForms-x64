using Pleer.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pleer.Data;

public class HAudio
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Order { get; set; }

    public HAudio(string name, string path, string order)
    {
        Name = name;
        Path = path;
        Order = order;
    }

    public bool IsExists()
    {
        if (System.IO.Path.Exists(Path))
        {
            return true;
        }
        else
        {
            SingletonHAudio.Instance.LoadFromDirs();
            SingletonHAudio.Instance.OHAudios = SingletonHAudio.Instance.ToSortedList();
            MessageBox.Show($"Аудиофайл {Path} не обнаружен!");
            return false;
        }
    }
}
