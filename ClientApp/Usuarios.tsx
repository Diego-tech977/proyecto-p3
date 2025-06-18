import { useEffect, useState } from "react";

type Usuarios = {
    "Id": string,
    "Nombre": string,
    "Password": string,
    "Correo": string,
}
const Usuarios = () => {
    // Datos
    const [registros, setRegistros] = useState<Usuarios[]>([]);
    const [texto, setTexto] = useState("");

    const listarRegistros = async () => {
        let url = "/api/usuarios";

        if(texto) {
            url += "?texto=" + texto;
        }

        const resp = await fetch(url);
        if  (resp.ok){
            const datos = await resp.json();
            setRegistros(datos); 
        }
    }

    useEffect(()=>{
        listarRegistros();
    }, []);

    const buscar = () => {
        listarRegistros();
    }

    const eliminar = async (item: Usuarios) => {
        if(!confirm("¿Desea eliminar el usuario " + item.Nombre + "?")){
            return;
        }

        const resp = await fetch("/api/usuarios/" + item.Id, {
            method: "DELETE"
        });

        if(resp.ok){
            listarRegistros();
        }
        else {
            const error = await resp.text();
            console.log(error);
            alert("Ocurrio un error al eliminar el registro");
        }
    }

    // Vista
    return (
        <>
        <div className="container">
            <h1>Usuarios</h1>
        </div>
        <div className="container">
            <div className="card">
                 <div className="card-header"></div>
                 <div className ="card-body">
                     <div className="row">
                        <div className="col-12">
                            <div className="mb-3">
                                <label>Búsqueda de Usuarios</label>
                                <input type="text" className="form-control" 
                                    placeholder="Introduce el nombre o el correo"
                                    onChange={(e) => setTexto(e.target.value)}/>
                            </div>
                        </div>
                        <div className="col-12">
                            <button className="btn btn-primary" onClick={buscar}>Buscar</button>
                        </div>
                     </div>
                 </div>
              </div>
          </div>

          <div className="container">
              <div className="container">
                  <div className="card-header d-flex justify-content-between align-items-center">
                       Usuarios existentes
                       <a href="/usuarios/editar" className="btn btn-primary">Nuevo</a>
                  </div>
                  <div className="card-body">
                      <table className="table table-striped">
                           <thead>
                                <tr>
                                    <th>No.</th>
                                    <th>Nombre</th>
                                    <th>Correo</th>
                                    <th>Password</th>
                                    <th></th>
                                </tr>
                            </thead>
                            {
                                registros.length === 0 &&
                                <tbody>
                                    <tr>
                                        <td colSpan={5}>No hay registros para mostrar</td>
                                    </tr>
                                </tbody>
                            }
                            {
                                registros.length > 0 &&
                                <tbody>
                                    {
                                        registros.map((item, index) =>
                                        <tr>
                                            <td>{index + 1}</td>
                                            <td>{item.Nombre}</td>
                                            <td>{item.Correo}</td>
                                            <td>{item.Password}</td>
                                            <td className="d-flex gap-2">
                                                <a className="btn btn-primary" href={"/usuarios/editar/" + item.Id}>Editar</a>
                                                <button className="btn btn-danger" onClick={()=> eliminar(item)}>Eliminar</button>
                                            </td>
                                        </tr>
                                        )
                                    } 
                                </tbody>
                            }
                        </table>
                    </div>
                </div>
             </div>
         </>
    )
}

export default Usuarios;


