using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

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
    
    [HttpGet("presentacion")]
    public IActionResult ObtenerPresentacion() {
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Escuela_Giovanni_Diego");
        var collection = db.GetCollection<Equipo>("Equipo");

        var list = collection.Find(FilterDefinition<Equipo>.Empty).ToList();
        return Ok(list);
    }
   

}