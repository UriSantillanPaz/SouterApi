using Services_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_WebApi.Services
{
    public class ServicesCalculoAcero
    {
        //1.Obtenemos la conexion a la base de datos
        private SouterDBEntities entities = new SouterDBEntities();
        public calculoAcero GetById(int id)
        {
            calculoAcero calculoAcero = null;
            try
            {
                calculoAcero = entities.calculoAcero.Where(p => p.id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return calculoAcero;
        }

        public bool DeleteById(int id)
        {
            bool respuesta = false;
            try
            {
                //1.lo primero qe debemos hacer es buscar la entidad a eliminar por id
                calculoAcero calculoAcero = entities.calculoAcero.Where(p => p.id == id).First();
                //2.una vez que tengamos la entidad es necesario eliminarla del contexto
                entities.calculoAcero.Remove(calculoAcero);
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

        public bool Insert(calculoAcero calculoAcero)
        {
            bool respuesta = false;
            try
            {
                //insertamos de forma logica la entidad categorias
                entities.calculoAcero.Add(calculoAcero);
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

        public bool Update(calculoAcero calculoAcero)
        {
            bool respuesta = false;
            try
            {
                //utilizamos la conexion para poder buscar la entidad a modificar , esto quiere decir que antes de todo buscamos la entidad de bd
                var entidadCalculoAcero = entities.calculoAcero.Where(p => p.id == calculoAcero.id).First();
                //ahora lo que haremos es modificar los valores viejos de la entidad por los valores nuevos
                entidadCalculoAcero.codigo = calculoAcero.codigo;
                entidadCalculoAcero.descripcion = calculoAcero.descripcion;
                entidadCalculoAcero.codigoAcero = calculoAcero.codigoAcero;
                entidadCalculoAcero.tipoAcero = calculoAcero.tipoAcero;
                entidadCalculoAcero.calidadAcero = calculoAcero.calidadAcero;
                entidadCalculoAcero.kgsMetro = calculoAcero.kgsMetro;
                entidadCalculoAcero.longBarra = calculoAcero.longBarra;
                entidadCalculoAcero.pesoTramo = calculoAcero.pesoTramo;
                entidadCalculoAcero.longTocho = calculoAcero.longTocho;
                entidadCalculoAcero.tochosTramo = calculoAcero.tochosTramo;
                entidadCalculoAcero.tochosBarra = calculoAcero.tochosBarra;
                entidadCalculoAcero.piezasTocho = calculoAcero.piezasTocho;
                entidadCalculoAcero.piezasBarra = calculoAcero.piezasBarra;
                entidadCalculoAcero.pesoTramo2 = calculoAcero.pesoTramo2;
                entidadCalculoAcero.pesoTocho = calculoAcero.pesoTocho;
                entidadCalculoAcero.pesoSTD = calculoAcero.pesoSTD;
                entidadCalculoAcero.fecha = calculoAcero.fecha;
                entidadCalculoAcero.piezasCortar = calculoAcero.piezasCortar;
                entidadCalculoAcero.noBarras = calculoAcero.noBarras;
                entidadCalculoAcero.colada = calculoAcero.colada;
                //No agregamos la llave foranea (idUsuario) del usuario por que es algo que no va a poder modificar
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
