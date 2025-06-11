using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase

{
    // Metodos para hacer las operaciones CRUD
    // C = Create
    // R = Read
    // U = Update
    // D = Delete

    private readonly IMongoCollection<Usuarios> collection;
    public UsuariosController()
    {
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var database = client.GetDatabase("Escuela_Giovanni_Diego");
        this.collection = database.GetCollection<Usuarios>("Usuarios");
    }
   
    [HttpGet]
    public IActionResult ListarUsuarios()
    {
        var filter = FilterDefinition<Usuarios>.Empty;
        var list = this.collection.Find(filter).ToList();
        return Ok(list);

    }
}
