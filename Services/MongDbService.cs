using MongoAPIEx.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoAPIEx.DTOs;

namespace MongoAPIEx.Services;

public class MongDbService
{
    private readonly IMongoCollection<Playlist> _playListCollection;

    public MongDbService(IOptions<MongoDbSettings> mongodbSettings)
    {
        MongoClient client = new MongoClient(mongodbSettings.Value.ConnectionURL);
        IMongoDatabase database = client.GetDatabase(mongodbSettings.Value.DatabaseName);
        _playListCollection = database.GetCollection<Playlist>(mongodbSettings.Value.CollectionName);
    }

    public async Task<List<Playlist>> GetAsync()
    {
        return await _playListCollection.Find(new BsonDocument()).ToListAsync();
    }
    
    public async Task CreateAsync(PlaylistDTO playlist)
    {
        Playlist _playList = new Playlist()
        {
            username = playlist.username,
            movieId = playlist.movieId
        };

        await _playListCollection.InsertOneAsync(_playList);

        return;
    }

    public async Task UpdateAsync(string id, string movieId)
    {
        FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);

        UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("movieId", movieId);

        await _playListCollection.UpdateOneAsync(filter,update);

        return;
    }

    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);

        await _playListCollection.DeleteOneAsync(filter);
    }

}