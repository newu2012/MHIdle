using Newtonsoft.Json;

namespace DataContext.Postgresql;

public static class EntitySeeding
{
    public static IEnumerable<T> Seeding<T>(string? fileToParse = null)
    {
        //  TODO find how set relative path in this
        var seedsFilePath = Path.Join("Seeds", $"{typeof(T).Name}.json");
        
        if (File.Exists(fileToParse ?? seedsFilePath))
        {
            var jsonText = File.ReadAllText(fileToParse ?? seedsFilePath);
            var classObjects = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonText);

            return classObjects ?? Array.Empty<T>();
        }

        return Array.Empty<T>();
    }
}