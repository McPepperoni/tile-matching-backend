using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Services;

namespace backend.Controllers;

[ApiController]
[Route("/api/[Controller]")]
public class UserController : ControllerBase
{
    private readonly UserService userService;

    public UserController(UserService _userService)
    {
        userService = _userService;
    }


    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> getAllUser() => await userService.GetAll();

    [HttpGet("{id:length(36)}")]
    public async Task<ActionResult<UserModel>> getOne(string id) => await userService.FindById(id);
    [HttpPost("create/{name}")]
    public async Task<ActionResult<UserModel>> createUser(string name)
    {
        UserModel user = await userService.CreateUser(name);

        return CreatedAtAction(nameof(createUser), new { id = user.id }, user);
    }

    [HttpDelete("delete")]
    public async Task<ActionResult<string[]>> delAllUser() => await userService.DelAll();

    [HttpDelete("delete/{id:length(36)}")]
    public async Task<ActionResult<string>> delOneUser(string id) => await userService.DelOne(id);
}