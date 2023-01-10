namespace MongoAPIEx.DTOs;

public class PlaylistDTO
{
    public string username { get; set; } = null!;
    public List<string> movieId { get; set; } = null!;

}