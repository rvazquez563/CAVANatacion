using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAVANatacion.AccesoDatos.Entidades
{
    public class Presencialidad
    {
        public int PresencialidadId { get; set; }
        public int AlumnoId { get; set; }
        public DateTime Fecha { get; set; }
        public Alumno Alumno { get; set; }
    }
}
