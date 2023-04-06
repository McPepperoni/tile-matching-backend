using backend.Utils;
using System.Text.Json;

namespace backend.Models;

public class GameModel
{
    public int width { get; set; }
    public int height { get; set; }
    public int count { get; set; }
    public int time { get; set; }
    public int timeLeft { get; set; }
    public List<List<int>> map { get; set; } = new List<List<int>>();
    private Random random = new Random();
    private GameUtils utils = new GameUtils();

    public GameModel(int level)
    {
        if (level > 2)
        {

        }
        else
        {
            count = 8;
            width = 16;
            height = 8;
            time = 300000;
            timeLeft = 300000;
        }

        map = utils.generateMap(count, width, height);
    }
    public GameModel(string _time, string _map)
    {
        var tempTime = Array.ConvertAll(_time.Split('/'), int.Parse);
        map = utils.StringToMap(_map);
        height = map.Count;
        width = map[0].Count;
        time = tempTime[1];
        timeLeft = tempTime[0];
    }

    public GameModel(List<List<int>> _map)
    {
        map = _map;
    }

    public bool SubmitMove(int[] pos1, int[] pos2)
    {
        if (map[pos1[0]][pos1[1]] != map[pos2[0]][pos2[1]])
        {
            return false;
        }

        map[pos1[0]][pos1[1]] = -1;
        map[pos2[0]][pos2[1]] = -1;

        return true;
    }
}