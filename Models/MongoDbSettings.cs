namespace MongoAPIEx.Models;

public class MongoDbSettings
{
    public string ConnectionURL {get; set;} = null!;
    public string DatabaseName {get; set;} = null!;
    public string CollectionName {get; set;} = null!;
    
}