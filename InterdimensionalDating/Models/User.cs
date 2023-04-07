namespace InterdimensionalDating.Models;

// {
// "id":10,
// "name":"Alan Rails",
// "status":"Dead",
// "species":"Human","type":"Superhuman (Ghost trains summoner)",
// "gender":"Male",
// "origin":{"name":"unknown","url":""},
// "location":{"name":"Worldender's lair",
// "url":"https://rickandmortyapi.com/api/location/4"},
// "image":"https://rickandmortyapi.com/api/character/avatar/10.jpeg",
// "episode":["https://rickandmortyapi.com/api/episode/25"],
// "url":"https://rickandmortyapi.com/api/character/10",
// "created":"2017-11-04T20:19:09.017Z"}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string Species { get; set; }
    public string Type { get; set; }
    public string Gender { get; set; }
    public string Origin { get; set; }
    public string Image { get; set; }
}