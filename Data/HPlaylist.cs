using System.Text.Json.Serialization;

namespace Pleer.Data;


public class HPlaylist
{
    [JsonInclude] public string Name { get; set; }
    [JsonInclude] public Dictionary<string, HAudio> HAudios;
    [JsonIgnore] private SortedList<string, HAudio>? OHAudios;

    [JsonConstructor]
    public HPlaylist(string Name, Dictionary<string, HAudio> HAudios)
    {
        this.Name = Name;
        this.HAudios = HAudios;
        this.OHAudios = ToSortedList();
    }

    public void ReSort()
    {
        this.OHAudios = ToSortedList();
    }

    public SortedList<string, HAudio> ToSortedList()
    {
        var sl = new SortedList<string, HAudio>();
        if (HAudios != null)
        {
            foreach (var i in HAudios.Values)
            {
                sl.Add(i.Order, i);
            }

            return sl;
        }
        return sl;
    }
}
