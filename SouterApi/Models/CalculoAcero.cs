using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouterApi.Models
{
    public class CalculoAceroSM
    {
        public int id { get; set; }
        public Nullable<int> codigo { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> codigoAcero { get; set; }
        public string tipoAcero { get; set; }
        public Nullable<int> calidadAcero { get; set; }
        public Nullable<double> kgsMetro { get; set; }
        public Nullable<double> longBarra { get; set; }
        public Nullable<double> pesoTramo { get; set; }
        public Nullable<double> longTocho { get; set; }
        public Nullable<double> tochosTramo { get; set; }
        public Nullable<int> tochosBarra { get; set; }
        public Nullable<int> piezasTocho { get; set; }
        public Nullable<int> piezasBarra { get; set; }
        public Nullable<double> pesoTramo2 { get; set; }
        public Nullable<double> pesoTocho { get; set; }
        public Nullable<double> pesoSTD { get; set; }
        public Nullable<int> idUsuario { get; set; }
    }
}