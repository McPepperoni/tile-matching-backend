namespace backend.Models;

public class UserModel
{
    public string id { get; set; } = null!;
    public string time { get; set; } = null!;
    public string map { get; set; } = null!;
    public string name { get; set; } = null!;
    public int level { get; set; }

    public UserModel()
    {
        id = "";
        name = "";
        time = "";
        map = "";
        name = "";
        level = 0;
    }
    public UserModel(string _name)
    {
        id = Guid.NewGuid().ToString();
        name = _name;
        level = 0;
        map = "";
        time = "";
    }
    public UserModel(string _id, string _name, string _time, string _map, int _level)
    {
        id = _id;
        name = _name;
        time = _time;
        map = _map;
        name = _name;
        level = _level;
    }
}