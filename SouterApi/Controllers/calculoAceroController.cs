using Services_WebApi.Models;
using SouterApi.Models;
using System;
using System.Collections.Generic;
using Services_WebApi.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SouterApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class calculoAceroController : ApiController
    {
        //3.establecemos la cadena de conexion
        private SouterDBEntities entities = new SouterDBEntities();
        //1.vamos a hacer el primer metodo para la tabla calculoAcero
        //2.La ruta de consumo seria api/calculoAcero
        public IHttpActionResult Get()
        {
            try
            {
                //esta es una consulta select * from usuarios, es decir regresamos todos los usuarios que fueron guardados en la tabla usuarios
                List<calculoAcero> calculoAcero = entities.calculoAcero.ToList();
                //antes de regresar la secuencia de los datos es necesario mapear los valores a la nueva clase
                List<CalculoAceroSM> calculoAceroSM = calculoAcero.Select(p => new CalculoAceroSM
                {
                    id = p.id,
                    codigo = p.codigo,
                    descripcion = p.descripcion,
                    codigoAcero = p.codigoAcero,
                    tipoAcero = p.tipoAcero,
                    calidadAcero = p.calidadAcero,
                    kgsMetro = p.kgsMetro,
                    longBarra = p.longBarra,
                    pesoTramo = p.pesoTramo,
                    longTocho = p.longTocho,
                    tochosTramo = p.tochosTramo,
                    tochosBarra = p.tochosBarra,
                    piezasTocho = p.piezasTocho,
                    piezasBarra = p.piezasBarra,
                    pesoTramo2 = p.pesoTramo2,
                    pesoTocho = p.pesoTocho,
                    pesoSTD = p.pesoSTD,
                    idUsuario = p.idUsuario,
                    fecha = p.fecha,
                    piezasCortar = p.piezasCortar,
                    noBarras = p.noBarras
                }).ToList();
                return Ok(calculoAceroSM);
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
                return BadRequest("La peticion no se pudo completar");
            }
        }

        public IHttpActionResult GetById(int id)
        {
            try
            {
                ServicesCalculoAcero services = new ServicesCalculoAcero();
                //esta clase regresa una categoria buscada por id, pero es necesario cambiarla a el objeto de tipo CalculoAceroSM
                calculoAcero calculoAcero = services.GetById(id);

                //aqui hacemos la conversion de los datos
                CalculoAceroSM CalculoAceroSM = new CalculoAceroSM();
                CalculoAceroSM.id = calculoAcero.id;
                CalculoAceroSM.codigo = calculoAcero.codigo;
                CalculoAceroSM.descripcion = calculoAcero.descripcion;
                CalculoAceroSM.codigoAcero = calculoAcero.codigoAcero;
                CalculoAceroSM.tipoAcero = calculoAcero.tipoAcero;
                CalculoAceroSM.calidadAcero = calculoAcero.calidadAcero;
                CalculoAceroSM.kgsMetro = calculoAcero.kgsMetro;
                CalculoAceroSM.longBarra = calculoAcero.longBarra;
                CalculoAceroSM.pesoTramo = calculoAcero.pesoTramo;
                CalculoAceroSM.longTocho = calculoAcero.longTocho;
                CalculoAceroSM.tochosTramo = calculoAcero.tochosTramo;
                CalculoAceroSM.tochosBarra = calculoAcero.tochosBarra;
                CalculoAceroSM.piezasTocho = calculoAcero.piezasTocho;
                CalculoAceroSM.piezasBarra = calculoAcero.piezasBarra;
                CalculoAceroSM.pesoTramo2 = calculoAcero.pesoTramo2;
                CalculoAceroSM.pesoTocho = calculoAcero.pesoTocho;
                CalculoAceroSM.pesoSTD = calculoAcero.pesoSTD;
                CalculoAceroSM.idUsuario = calculoAcero.idUsuario;
                CalculoAceroSM.fecha = calculoAcero.fecha;
                CalculoAceroSM.piezasCortar = calculoAcero.piezasCortar;
                CalculoAceroSM.noBarras = calculoAcero.noBarras;
                return Ok(CalculoAceroSM);
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
                return BadRequest("La petición no se pudo ejecutar");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteById(int id)
        {
            try
            {
                //ahora creamos el objeto que se encargara de hacer la eliminación de los datos
                ServicesCalculoAcero services = new ServicesCalculoAcero();
                //mandamos a eliminar la entidad de la base de datos (La mandamos a volar jajaja)
                services.DeleteById(id);
                //regresamos la respuesta si todo funciona de manera adecuada
                return Ok();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
                //En caso de que no funcione mien le avisamos que no se pudo
                return BadRequest("No se pudo completar la solicitud de eliminar");
            }
        }

        [HttpPost]
        public IHttpActionResult Insert(CalculoAceroSM calculoAceroSM)
        {
            try
            {
                //creamos la entidad de la base de datos
                calculoAcero calculoAcero = new calculoAcero();
                //llenamos la entidad con los datos que vienen en la entidad usuariosSM
                //La entidad categoriasSM sera una entidad que se llena desde la aplicacion cliente
                calculoAcero.id = calculoAceroSM.id;
                calculoAcero.codigo = calculoAceroSM.codigo;
                calculoAcero.descripcion = calculoAceroSM.descripcion;
                calculoAcero.codigoAcero = calculoAceroSM.codigoAcero;
                calculoAcero.tipoAcero = calculoAceroSM.tipoAcero;
                calculoAcero.calidadAcero = calculoAceroSM.calidadAcero;
                calculoAcero.kgsMetro = calculoAceroSM.kgsMetro;
                calculoAcero.longBarra = calculoAceroSM.longBarra;
                calculoAcero.pesoTramo = calculoAceroSM.pesoTramo;
                calculoAcero.longTocho = calculoAceroSM.longTocho;
                calculoAcero.tochosTramo = calculoAceroSM.tochosTramo;
                calculoAcero.tochosBarra = calculoAceroSM.tochosBarra;
                calculoAcero.piezasTocho = calculoAceroSM.piezasTocho;
                calculoAcero.piezasBarra = calculoAceroSM.piezasBarra;
                calculoAcero.pesoTramo2 = calculoAceroSM.pesoTramo2;
                calculoAcero.pesoTocho = calculoAceroSM.pesoTocho;
                calculoAcero.pesoSTD = calculoAceroSM.pesoSTD;
                calculoAcero.idUsuario = calculoAceroSM.idUsuario;
                calculoAcero.fecha = calculoAceroSM.fecha;
                calculoAcero.piezasCortar = calculoAceroSM.piezasCortar;
                calculoAcero.noBarras = calculoAceroSM.noBarras;
                //creamos el objeto de tipo services para poder realizar el CRUD
                ServicesCalculoAcero services = new ServicesCalculoAcero();
                //mandamos la entidad para que se inserte
                services.Insert(calculoAcero);
                return Ok();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
                return BadRequest("No se pudo completar la peticion");
            }
        }

        [HttpPut]
        public IHttpActionResult Update(CalculoAceroSM calculoAceroSM)
        {
            try
            {
                ServicesCalculoAcero services = new ServicesCalculoAcero();
                //iniciliazamos los valores de la entidad que esta acoplada a la base de datos, es decir esta clase es al EntityFramework
                var calculoAcero = new calculoAcero()
                {
                    id = calculoAceroSM.id,
                    codigo = calculoAceroSM.codigo,
                    descripcion = calculoAceroSM.descripcion,
                    codigoAcero = calculoAceroSM.codigoAcero,
                    tipoAcero = calculoAceroSM.tipoAcero,
                    calidadAcero = calculoAceroSM.calidadAcero,
                    kgsMetro = calculoAceroSM.kgsMetro,
                    longBarra = calculoAceroSM.longBarra,
                    pesoTramo = calculoAceroSM.pesoTramo,
                    longTocho = calculoAceroSM.longTocho,
                    tochosTramo = calculoAceroSM.tochosTramo,
                    tochosBarra = calculoAceroSM.tochosBarra,
                    piezasTocho = calculoAceroSM.piezasTocho,
                    piezasBarra = calculoAceroSM.piezasBarra,
                    pesoTramo2 = calculoAceroSM.pesoTramo2,
                    pesoTocho = calculoAceroSM.pesoTocho,
                    pesoSTD = calculoAceroSM.pesoSTD,
                    idUsuario = calculoAceroSM.idUsuario,
                    fecha = calculoAceroSM.fecha,
                    piezasCortar = calculoAceroSM.piezasCortar,
                    noBarras = calculoAceroSM.noBarras
                };
                services.Update(calculoAcero);
                return Ok();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
                return BadRequest("No se pudo completar la peticion");
            }
        }
    }
}
