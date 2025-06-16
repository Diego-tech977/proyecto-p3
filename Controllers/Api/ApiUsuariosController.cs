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
        var db = client.GetDatabase("Escuela_Giovanni_Diego");
        this.collection = db.GetCollection<Usuarios>("Usuarios");
    }

    [HttpGet]
    public IActionResult ListarUsuarios(string? texto)
    {
        var filter = FilterDefinition<Usuarios>.Empty;
        if (!string.IsNullOrWhiteSpace(texto))
        {
            var filterNombre = Builders<Usuarios>.Filter.Regex(u => u.Nombre, new BsonRegularExpression(texto, "i"));
            var filterCorreo = Builders<Usuarios>.Filter.Regex(u => u.Correo, new BsonRegularExpression(texto, "i"));
            filter = Builders<Usuarios>.Filter.Or(filterNombre, filterCorreo);
        }
        var list = this.collection.Find(filter).ToList();

        return Ok(list);
    }

    [HttpDelete ("{id}")]
    public IActionResult Delete(string id)
    {
        var filter = Builders<Usuarios>.Filter.Eq(x => x.Id, id);
        var item = this.collection.Find(filter).FirstOrDefault();
        if (item != null)
        {
            this.collection.DeleteOne(filter);
        }
        return NoContent();
    }

    [HttpPost]

    public IActionResult Create(UsuariosRequest model)
    {
        // 1. validar el modelo para que contenga datos 
        if(string.IsNullOrWhiteSpace(model.Correo))
        {
            return BadRequest("El correo es requerido");
        }

        if(string.IsNullOrWhiteSpace(model.Password))
        {
            return BadRequest("El password es requerido");
        }

        if(string.IsNullOrWhiteSpace(model.Nombre))
        {
            return BadRequest("El nombre es requerido");
        }

        /// Validar que el correo no exista
        var filter = Builders<Usuarios>.Filter.Eq(x => x.Correo, model.Correo);
        var item = this.collection.Find(filter).FirstOrDefault();
        if (item != null)
        {
            return BadRequest("El corre " + model.Correo + " ya existe en la base de datos");
        }

        Usuarios bd = new Usuarios();
        bd.Nombre = model.Nombre;
        bd.Correo = model.Correo;
        bd.Password = model.Password;

        this.collection.InsertOne(bd);
        return Ok();   
    }

    [HttpGet("{id}")]
    public IActionResult Read(string id)
    {
        var filter = Builders<Usuarios>.Filter.Eq(x => x.Id, id);
        var item = this.collection.Find(filter).FirstOrDefault();
        if (item == null)
        {
            return NotFound("No existe un usuario con el ID proporcionado");
        }

        return Ok(item);
    }

    [HttpPut("{id}")]

    public IActionResult Create(string id, UsuarioRequest model)
    {
        // 1. validar el modelo para que contenga datos 
        if(string.IsNullOrWhiteSpace(model.Correo))
        {
            return BadRequest("El correo es requerido");
        }

        if(string.IsNullOrWhiteSpace(model.Password))
        {
            return BadRequest("El password es requerido");
        }

        if(string.IsNullOrWhiteSpace(model.Nombre))
        {
            return BadRequest("El nombre es requerido");
        }

        /// Validar que el correo no exista
        var filter = Builders<Usuarios>.Filter.Eq(x => x.Correo, model.Correo);
        var item = this.collection.Find(filter).FirstOrDefault();
        if (item != null)
        {
            return BadRequest("El corre " + model.Correo + " ya existe en la base de datos");
        }

        Usuarios bd = new Usuarios();
        bd.Nombre = model.Nombre;
        bd.Correo = model.Correo;
        bd.Password = model.Password;

        this.collection.InsertOne(bd);
        return Ok();   
    }

}