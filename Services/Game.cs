using backend.Models;

namespace backend.Services;

public class GameMapService
{
    public GameMapService()
    {
    }
    public GameModel createMap(int level)
    {

        return new GameModel(level);
    }
}