
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class AnexoController : BaseController
{

    public AnexoService _anexoService { get; set; }

    public AnexoController(AnexoService anexoService)
    {
        this._anexoService = anexoService;
    }


    [HttpPost]
    [Authorize (Roles ="ADMINISTRADOR")]
    public ActionResult registryAnexo([FromBody] AnexoRequestDto dto)
    {
        try
        {
            _anexoService.registryAnexo(dto);
            return Ok("Sucesso ao cadastrar Anexo!");
        }
        catch (Exception error)
        {
            if (error.StackTrace.Contains("registryAnexo"))
            {
                return BadRequest("Erro ao cadastrar Anexo, por favor tente novamente");
            }
            if (error.StackTrace.Contains("saveAnexo"))
            {
                return BadRequest("Erro ao cadastrar Anexo: " + error.Message);
            }
        }
        return BadRequest("");
    }

}