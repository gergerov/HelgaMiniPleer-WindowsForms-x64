using Pleer.Data;
using System.Text.Json;

namespace Pleer.Singleton;

public sealed class SingletonHDir
{
    private static readonly string DataFilePath = Path.Combine(FMain.appFolderPath, "hdirs.json");
    private static readonly Lazy<SingletonHDir> lazy = new Lazy<SingletonHDir>(() => new SingletonHDir());

    private SingletonHDir()
    {
        HDirs = new Dictionary<string, HDir>();
        LoadFromDisk();
    }

    public static SingletonHDir Instance => lazy.Value;
    public Dictionary<string, HDir> HDirs;


    public bool AddHDir(HDir dir)
    {
        if (HDirs.ContainsKey(dir.Name))
        {
            return false;
        }

        HDirs.Add(dir.Name, dir);
        SaveToDisk();
        return HDirs.ContainsKey(dir.Name);
    }


    public bool RemoveHDir(HDir dir)
    {
        var res = HDirs.Remove(dir.Name);
        SaveToDisk();
        return res;
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
            var loadedDict = JsonSerializer.Deserialize<Dictionary<string, HDir>>(jsonString);

            if (loadedDict != null)
            {
                HDirs?.Clear();
                foreach (var item in loadedDict)
                {
                    HDirs?[item.Key] = item.Value;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            HDirs?.Clear();
        }
    }

    private void SaveToDisk()
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(HDirs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataFilePath, jsonString);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
        }
    }
}
