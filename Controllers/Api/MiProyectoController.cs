using Microsoft.AspNetCore.Mvc;

[Route("api/mi_proyecto")]
public class NombreIntegranteController : ControllerBase {

    [HttpGet("Integrantes")]
    public IActionResult ObtenerIntegrantes(){
        var integrantes = new MiProyecto{
        NombreIntegrante1 = "Giovanni Salazar Gonzalez",
        NombreIntegrante2 = "Diego Alejandro Ramirez Frias"

        };
        return Ok(integrantes);
    }
    
   

}