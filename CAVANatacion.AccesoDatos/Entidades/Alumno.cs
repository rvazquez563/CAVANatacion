using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CAVANatacion.AccesoDatos.Entidades
{
    public class Alumno
    {
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool PagoMes { get; set; }
        public bool Apto { get; set; }
        public DateTime? FechaVencimientoApto { get; set; }
        public decimal MontoPagadoMes { get; set; } // Nuevo campo para el monto pagado en el mes

        public int PlanId { get; set; }
        public Plan Plan { get; set; }
        public DateTime? UltimoPago { get; set; } // Nueva propiedad para registrar el último pago
        public string ApellidoNombre => $"{Apellido}, {Nombre}";
        public ICollection<Presencialidad> Presencialidades { get; set; }
        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
    }
}
