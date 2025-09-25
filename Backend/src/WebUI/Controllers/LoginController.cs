using Microsoft.AspNetCore.Mvc;

public class LoginController : BaseController
{

    private readonly LoginService _loginService;

    public LoginController(LoginService loginService)
    {
        this._loginService = loginService;
    }

    [HttpGet]
    public async Task<ActionResult> Auth(LoginDto dto)
    {
        try
        {
            UserResponseDto response = await _loginService.getUser(dto);
            
            if (response is null)
                return BadRequest("Usuario não existe, verifique suas credenciais");

            var token = TokenService.GenerateToken(response);

            return Ok(new
            {
                user = response,
                token
            });
        }
        catch (Exception ex)
        {
            if (ex.StackTrace?.Contains("getUser") is not false)
                return BadRequest("Erro ao consultar usuario! " + ex.Message);
        }
        return BadRequest("Erro ao consultar usuario!");
    } 
}