using Services_WebApi.Models;
using Services_WebApi.Services;
using SouterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SouterApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class usuariosController : ApiController
    {
        private SouterDBEntities entities = new SouterDBEntities();

        public IHttpActionResult Get()
        {
            try
            {
                //esta es una consulta select * from usuarios, es decir regresamos todos los usuarios que fueron guardados en la tabla usuarios
                List<usuarios> usuarios = entities.usuarios.ToList();
                //antes de regresar la secuencia de los datos es necesario mapear los valores a la nueva clase
                List<UsuariosSM> usuariosSM = usuarios.Select(p => new UsuariosSM { id = p.id, username = p.username, clave = p.clave }).ToList();
                return Ok(usuariosSM);
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
                return BadRequest("La petición de consultar los usuarios no se pudo ejecutar");
            }
        }
        public IHttpActionResult GetById(int id)
        {
            try
            {
                ServicesUsuarios services = new ServicesUsuarios();
                //esta clase regresa una categoria buscada por id, pero es necesario cambiarla a el objeto de tipo UsuriosSM
                usuarios usuarios = services.GetById(id);

                //aqui hacemos la conversion de los datos
                UsuariosSM usuariosSM = new UsuariosSM();
                usuariosSM.id = usuarios.id;
                usuariosSM.username = usuarios.username;
                usuariosSM.clave = usuarios.clave;
                return Ok(usuariosSM);
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
                return BadRequest("La petición de consultar por ID de usuarios no se pudo ejecutar");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteById(int id)
        {
            try
            {
                //ahora creamos el objeto que se encargara de hacer la eliminación de los datos
                ServicesUsuarios services = new ServicesUsuarios();
                //mandamos a eliminar la entidad de la base de datos (La mandamos a volar jajaja)
                services.DeleteById(id);
                //regresamos la respuesta si todo funciona de manera adecuada
                return Ok();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
                //En caso de que no funcione mien le avisamos que no se pudo
                return BadRequest("No se pudo completar la solicitud de eliminar el usuario por ID");
            }
        }

        [HttpPost]
        public IHttpActionResult Insert(UsuariosSM usuariosSM)
        {
            try
            {
                //creamos la entidad de la base de datos
                usuarios usuarios = new usuarios();
                //llenamos la entidad con los datos que vienen en la entidad usuariosSM
                //La entidad categoriasSM sera una entidad que se llena desde la aplicacion cliente
                usuarios.id = usuariosSM.id;
                usuarios.username = usuariosSM.username;
                usuarios.clave = usuariosSM.clave;

                //creamos el objeto de tipo services para poder realizar el CRUD
                ServicesUsuarios services = new ServicesUsuarios();
                //mandamos la entidad para que se inserte
                services.Insert(usuarios);
                return Ok();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
                return BadRequest("No se pudo insertar el usuario :c");
            }
        }

        [HttpPut]
        public IHttpActionResult Update(UsuariosSM usuariosSM)
        {
            try
            {
                ServicesUsuarios services = new ServicesUsuarios();
                //iniciliazamos los valores de la entidad que esta acoplada a la base de datos, es decir esta clase es al EntityFramework
                var usuarios = new usuarios()
                {
                    id = usuariosSM.id,
                    username = usuariosSM.username,
                    clave = usuariosSM.clave
                };
                services.Update(usuarios);
                return Ok();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
                return BadRequest("No se pudo actualizar el registro :c");
            }
        }
    }
}
