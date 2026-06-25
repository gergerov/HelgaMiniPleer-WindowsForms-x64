using Pleer.Data;
using System.Text.Json;


namespace Pleer.Singleton;


public sealed class SingletonHPlaylist
{
    private static readonly string DataFilePath = Path.Combine(FMain.appFolderPath, "hplaylist.json");
    private static readonly Lazy<SingletonHPlaylist> lazy = 
        new Lazy<SingletonHPlaylist>(() => new SingletonHPlaylist());

    private SingletonHPlaylist()
    {
        HPlaylists = new Dictionary<string, HPlaylist>();
        LoadFromDisk();
    }

    public static SingletonHPlaylist Instance => lazy.Value;
    public Dictionary<string, HPlaylist> HPlaylists;


    public bool AddHPlaylist(HPlaylist playlist)
    {
        if (HPlaylists.ContainsKey(playlist.Name))
        {
            return false;
        }
        HPlaylists.Add(playlist.Name, playlist);
        SaveToDisk();
        return HPlaylists.ContainsKey(playlist.Name);
    }

    public bool Rename(HPlaylist playlist, string NewName)
    {
        if (playlist.Name == NewName)
        {
            return false;
        }

        if (HPlaylists.ContainsKey(NewName))
        {
            return false;
        }

        var res = HPlaylists.Remove(playlist.Name);
        if (res)
        {
            playlist.Name = NewName;
            HPlaylists.Add(NewName, playlist);
            SaveToDisk();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveHPlaylist(HPlaylist playlist)
    {
        var res = HPlaylists.Remove(playlist.Name);
        if (res)
        {
            SaveToDisk();
        }
        return res;
    }


    public void LoadFromDisk()
    {
        if (!File.Exists(DataFilePath))
        {
            return;
        }

        try
        {
            string jsonString = File.ReadAllText(DataFilePath);
            var loadedDict = JsonSerializer.Deserialize<Dictionary<string, HPlaylist>>(jsonString);

            if (loadedDict != null)
            {
                HPlaylists?.Clear();
                foreach (var item in loadedDict)
                {
                    HPlaylists?[item.Key] = item.Value;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            HPlaylists?.Clear();
        }
    }

    public void SaveToDisk()
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(HPlaylists, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataFilePath, jsonString);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
        }
    }
}
