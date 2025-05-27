using Microsoft.AspNetCore.Mvc;

[Route("api/integrante")]
public class NombreIntegranteController : ControllerBase {

    [HttpGet("Giovanni")]
    public IActionResult Integrantes (){
        returm Ok();
    }


    [HttpGet("Diego")]
    public IActionResult Integrantes (){
        returm Ok();
}

}