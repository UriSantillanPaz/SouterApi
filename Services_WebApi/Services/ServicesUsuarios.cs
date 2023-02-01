using Services_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_WebApi.Services
{
    public class ServicesUsuarios
    {
        //1.Obtenemos la conexion a la base de datos
        private SouterDBEntities entities = new SouterDBEntities();
        public usuarios GetById(int id)
        {
            usuarios usuarios = null;
            try
            {
                usuarios = entities.usuarios.Where(p => p.id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return usuarios;
        }

        public bool DeleteById(int id)
        {
            bool respuesta = false;
            try
            {
                //1.lo primero qe debemos hacer es buscar la entidad a eliminar por id
                usuarios usuarios = entities.usuarios.Where(p => p.id == id).First();
                //2.una vez que tengamos la entidad es necesario eliminarla del contexto
                entities.usuarios.Remove(usuarios);
                //realizamos la eliminacion de forma fisica en la base de datos
                entities.SaveChanges();
                //regresamos la respuesta adecuada
                respuesta = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return respuesta;
        }

        public bool Insert(usuarios usuarios)
        {
            bool respuesta = false;
            try
            {
                //insertamos de forma logica la entidad categorias
                entities.usuarios.Add(usuarios);
                //insertamos de forma fisica la entidad en la base de datos
                entities.SaveChanges();
                respuesta = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return respuesta;
        }

        public bool Update(usuarios usuarios)
        {
            bool respuesta = false;
            try
            {
                //utilizamos la conexion para poder buscar la entidad a modificar , esto quiere decir que antes de todo buscamos la entidad de bd
                var entidadUsuarios = entities.usuarios.Where(p => p.id == usuarios.id).First();
                //ahora lo que haremos es modificar los valores viejos de la entidad por los valores nuevos
                entidadUsuarios.username = usuarios.username;
                entidadUsuarios.clave = usuarios.clave;
                //Se modifican las propiedades viejas por la nuevas  pero el id se deja tal y como esta
                //finalmente se actualiza la entidad en la base de datos
                entities.SaveChanges();
                respuesta = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return respuesta;
        }
    }
}
