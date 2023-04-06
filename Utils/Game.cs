namespace backend.Utils;

public class GameUtils
{
    private readonly Random random = new Random();

    public GameUtils() { }
    public List<List<int>> generateMap(int count, int width, int height)
    {
        List<List<int>> res = new List<List<int>>();
        int max_count = width * height / count;

        Dictionary<int, int> item = new Dictionary<int, int> { };
        for (int i = 0; i < count; i++)
        {
            item.Add(i, max_count);
        }

        for (int i = 0; i < height; i++)
        {
            List<int> row = new List<int> { };
            for (int j = 0; j < width; j++)
            {
                int index = random.Next(item.Count);

                var e = item.ElementAt(index);
                row.Add(e.Key);
                item[e.Key] -= 1;
                if (item[e.Key] == 0)
                {
                    item.Remove(e.Key);
                }
            }
            res.Add(row);
        }

        return res;
    }

    public string MapToString(List<List<int>> map)
    {
        List<string> stringList = new List<string>();
        for (var i = 0; i < map.Count; i++)
        {
            string temp = string.Join(",", map[i].ToArray());
            stringList.Add(temp);
        }

        return string.Join(" ", stringList.ToArray());
    }

    public List<List<int>> StringToMap(string map)
    {
        var strLst = map.Split(' ').ToList();
        List<List<int>> res = new List<List<int>>();
        for (var i = 0; i < strLst.Count; i++)
        {
            res.Add(Array.ConvertAll(strLst[i].Split(','), int.Parse).ToList());
        }

        return res;
    }
}