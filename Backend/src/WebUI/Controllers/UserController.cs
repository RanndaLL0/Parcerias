
using Microsoft.AspNetCore.Mvc;

public class UserController : BaseController
{
    public readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public ActionResult save([FromBody] UserRequestDto user)
    {
        try
        {
            _userService.Save(user);
            return Ok("Usuario Salvo!");
        }
        catch (Exception error)
        {
            return BadRequest("Erro ao salvar o usuario: " + error.Message);
        }
    }
}