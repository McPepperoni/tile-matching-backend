using backend.Contexts;
using backend.Utils;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class UserService
{
    private readonly dbContext context = new dbContext();
    private readonly GameUtils gameUtils = new GameUtils();
    public UserService()
    {

    }

    public async Task<UserModel> CreateUser(string name)
    {
        UserModel user = new UserModel(name);
        try
        {
            await context.User.AddAsync(user);
            context.SaveChanges();
        }
        catch (System.Exception)
        {
            throw;
        }
        return user;
    }
    public async Task<UserModel> FindById(string id)
    {
        UserModel user;
        try
        {
            user = await context.User.FindAsync(id) ?? new UserModel();
        }
        catch (System.Exception)
        {
            throw;
        }
        return user;
    }

    public async Task<List<UserModel>> GetAll()
    {
        List<UserModel> users;
        try
        {
            users = await context.User.ToListAsync();
        }
        catch (System.Exception)
        {
            throw;
        }

        return users;
    }

    public async Task<List<List<int>>> UpdateMap(GameModel game, UserModel user)
    {
        user.map = gameUtils.MapToString(game.map);
        user.time = $"{game.timeLeft}/{game.time}";
        await context.SaveChangesAsync();

        return game.map;
    }

    public async Task<string[]> DelAll()
    {
        string[] ids;
        try
        {
            ids = await context.User.Select(u => u.id).ToArrayAsync();
        }
        catch (System.Exception)
        {
            throw;
        }

        await context.User.Where(u => ids.Contains(u.id)).ExecuteDeleteAsync();

        return ids;
    }

    public async Task<string> DelOne(string id)
    {
        UserModel user;
        try
        {
            user = (await context.User.FindAsync(id)) ?? new UserModel();
        }
        catch (System.Exception)
        {
            throw;
        }

        await context.User.Where(u => u.id == user.id).ExecuteDeleteAsync();

        return user.id;
    }
}