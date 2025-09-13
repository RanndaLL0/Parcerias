

using Microsoft.AspNetCore.Mvc;

public class ParceriaController : BaseController
{
    private readonly ParceriaService _parceriaService;
    public ParceriaController(ParceriaService parceriaService)
    {
        this._parceriaService = parceriaService;
    }

    [HttpPost]
    public ActionResult save(ParceriaRequestDto dto)
    {
        try
        {
            this._parceriaService.save(dto);
            return Ok("Parceria Salva");
        }
        catch (Exception error){
            return BadRequest("Erro ao registrar parceria: " + error.Message);
        }
    }

}