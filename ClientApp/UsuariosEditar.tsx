import { useState } from "react";

interface UsuariosEditarProps {
    id: string
}

const UsuariosEditar = ({id} : UsuariosEditarProps) => {
    const [idUsuario, setIdUsuario] = useState(id);
    const [nombre, setNombre] = useState("");
    const [correo, setCorreo] = useState("");
    const [password, setPassword] = useState("");

    const guardar = () => {
        const model = {
            "Nombre": nombre,
            "Correo": correo,
            "Password": password 
        }

        console.log(model);
    }


    return (
        <>
        <div className="container">
             <h1>Editar Usuario</h1>
        </div>
        <div className="container">
            <div className="row">
                <div className="col-12">
                    <div className="mb-3">
                        <label>Nombre</label>
                        <input type="text" className="form-control" onChange={(e) => setNombre(e.target.value)} />
                    </div>
                </div>
                <div className="col-12">
                    <div className="mb-3">
                        <label>Correo Electrónico</label>
                        <input type="email" className="form-control" onChange={(e) => setCorreo(e.target.value)} />
                    </div>
                </div>
                <div className="col-12">
                    <div className="mb-3">
                        <label>Contraseña</label>
                        <input type="text" className="form-control" onChange={(e) => setPassword(e.target.value)} />
                    </div>
                </div>
                <div className="col-12 d-flex gap-2 justify-content-end">
                    <button className="btn btn-primary">Guardar</button>
                    <a href="/usuarios" className="btn btn-secondary">Regresar</a> 
                </div>
            </div>
        </div>
        </>
    )
}

export default UsuariosEditar;