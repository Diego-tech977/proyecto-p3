using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("api/usuarios")]
public class ApiUsuariosController : ControllerBase

{
    // Metodos para hacer las operaciones CRUD
    // C = Create
    // R = Read
    // U = Update
    // D = Delete

    private readonly IMongoCollection<Usuarios> collection;
    public ApiUsuariosController()
    {
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var database = client.GetDatabase("Escuela_Giovanni_Diego");
        this.collection = database.GetCollection<Usuarios>("Usuarios");
    }
   
    [HttpGet]
    public IActionResult ListarUsuarios(string? texto)
    {
        var filter = FilterDefinition<Usuarios>.Empty;
        if (!string.IsNullOrWhiteSpace(texto))
        {
            var filterNombre = Builders<Usuarios>.Filter.Regex(u => u.Nombre, new BsonRegularExpression(texto, "i"));
            var filterCorreo = Builders<Usuarios>.Filter.Regex(u => u.Nombre, new BsonRegularExpression(texto, "i"));
             filter = Builder< 
        }

        var list = this.collection.Find(filter).ToList();

        return Ok(list);

    }
}
