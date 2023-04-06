using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Services;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MapController : ControllerBase
{
    private readonly UserService userService;

    public MapController(GameMapService _gameMapService, UserService _userService)
    {
        userService = _userService;
    }


    [HttpGet("{id:length(36)}")]
    public async Task<ActionResult<GameModel>> getMap(string id)
    {
        UserModel user = await userService.FindById(id);
        if (user.id == "")
        {
            return NotFound();
        }

        GameModel _mapModel;
        if (user.map != "" && user.time != "0")
        {
            _mapModel = new GameModel(user.time, user.map);

            return CreatedAtAction(nameof(getMap), _mapModel);
        }
        _mapModel = new GameModel(user.level);
        await userService.UpdateMap(_mapModel, user);


        return CreatedAtAction(nameof(getMap), _mapModel);
    }
    // [HttpGet("{id:length(24)}/{pos1}/{pos2}")]
    // public ActionResult<Boolean> submitMove(string id) {

    // }
}