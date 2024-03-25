using CSProjeDemo2.Entities;
using CSProjeDemo2.Entities.Base;
using Newtonsoft.Json;

namespace CSProjeDemo2;

public class ReadDocument
{
    public static List<Manager> GetManagerList(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var list = JsonConvert.DeserializeObject<List<Manager>>(json);
        return list.Where(x => x.Title == "Yonetici").ToList();
    }

    public static List<Officer> GetOfficerList(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var list = JsonConvert.DeserializeObject<List<Officer>>(json);
        return list.Where(x => x.Title == "Memur").ToList();
    }
}