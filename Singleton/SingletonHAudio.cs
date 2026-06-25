using Pleer.Data;
using System.Text.Json;


namespace Pleer.Singleton;

public sealed class SingletonHAudio
{

    private static readonly string DataFilePath = Path.Combine(FMain.appFolderPath, "haudios.json");
    private static readonly Lazy<SingletonHAudio> lazy = new Lazy<SingletonHAudio>(() => new SingletonHAudio());
    private readonly Random _random = new();

    private SingletonHAudio()
    {
        HAudios = new Dictionary<string, HAudio>();
        LoadFromDirs();
        OHAudios = ToSortedList();
    }

    public static SingletonHAudio Instance => lazy.Value;
    public Dictionary<string, HAudio> HAudios;
    public SortedList<string, HAudio> OHAudios;

    public void Update()
    {
        HAudios.Clear();
        HAudios.Clear();
        LoadFromDirs();
        OHAudios = ToSortedList();
    }

    public HAudio? GetNext(HAudio audio)
    {
        if (OHAudios.Count <= 0)
        {
            return null;
        }

        var keys = OHAudios.Keys;
        int idx = OHAudios.Keys.IndexOf(audio.Path);
        
        if (idx >= OHAudios.Count - 1)
        {
            var next = keys[0];
            return OHAudios[next];
        }

        else
        {
            var next = keys[idx+1];
            return OHAudios[next];
        }
    }

    public HAudio? GetPrev(HAudio audio)
    {
        if (OHAudios.Count == 0)
        {
            return null;
        }

        var keys = OHAudios.Keys;
        int idx = OHAudios.Keys.IndexOf(audio.Path);

        if (idx == 0)
        {
            var next = keys[OHAudios.Count - 1];
            return OHAudios[next];
        }
        else
        {
            var next = keys[idx - 1];
            return OHAudios[next];
        }
    }

    public HAudio? GetRand()
    {
        if (OHAudios.Count == 0)
        {
            return null;
        }
        var i = _random.Next(0, OHAudios.Count);
        return OHAudios[OHAudios.Keys[i]];
    }

    public bool AddHAudio(HAudio audio)
    {
        if (HAudios.ContainsKey(audio.Name))
        {
            return false;
        }

        HAudios.Add(audio.Name, audio);
        OHAudios.Add(audio.Order, audio);
        SaveToDisk();
        return HAudios.ContainsKey(audio.Name);
    }

    public bool RemoveHAudio(HAudio audio)
    {
        var res = HAudios.Remove(audio.Name);
        if (res)
        {
            OHAudios.Remove(audio.Order);
            SaveToDisk();
        }
        return res;
    }

    public void LoadFromDirs()
    {
        HAudios.Clear();

        var exes = HAudioExtension.Exes();
        foreach (var dir in SingletonHDir.Instance.HDirs.Values)
        {
            if (!Directory.Exists(dir.Path))
            {
                continue; 
            }

            foreach (var e in exes)
            {
                
                var files = Directory.EnumerateFiles(dir.Path, "*" + e).ToList();
                foreach (var f in files)
                {
                    if (!HAudios.ContainsKey(Path.GetFileName(f)))
                    {
                        var audio = new HAudio(Path.GetFileName(f), f, f);
                        HAudios.Add(audio.Path, audio);
                    }
                }
            }
        }
        SaveToDisk();
    }

    public SortedList<string, HAudio> ToSortedList()
    {
        var sl = new SortedList<string, HAudio>();
        foreach (var i in HAudios.Values)
        {
            sl.Add(i.Order, i);
        }

        return sl;
    }

    private void LoadFromDisk()
    {
        if (!File.Exists(DataFilePath))
        {
            return;
        }

        try
        {
            string jsonString = File.ReadAllText(DataFilePath);
            var loadedDict = JsonSerializer.Deserialize<Dictionary<string, HAudio>>(jsonString);

            if (loadedDict != null)
            {
                HAudios?.Clear();
                foreach (var item in loadedDict)
                {
                    HAudios?[item.Key] = item.Value;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            HAudios?.Clear();
        }
    }
    private void SaveToDisk()
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(HAudios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataFilePath, jsonString);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
        }
    }
}
