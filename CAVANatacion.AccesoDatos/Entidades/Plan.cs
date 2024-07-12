using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAVANatacion.AccesoDatos.Entidades
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string Descripcion { get; set; }
        public int DiasSemana { get; set; }
        public decimal Tarifa { get; set; }
        public string Categoria { get; set; }  // "Adulto", "Menor", "Jubilado"
        public ICollection<Alumno> Alumnos { get; set; }
    }
}
