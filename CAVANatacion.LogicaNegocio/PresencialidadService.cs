using CAVANatacion.AccesoDatos;
using CAVANatacion.AccesoDatos.Entidades;
using System;
using System.Linq;

namespace CAVANatacion.LogicaNegocio
{
    public class PresencialidadService
    {
        private readonly PiletaContext _context;

        public PresencialidadService(PiletaContext context)
        {
            _context = context;
        }

        public void RegistrarPresencialidad(int alumnoId, DateTime fecha)
        {
            var alumno = _context.Alumnos.Find(alumnoId);
            if (alumno == null) throw new Exception("Alumno no encontrado");

            var plan = _context.Planes.Find(alumno.PlanId);
            if (plan == null) throw new Exception("Plan no encontrado");

            var asistenciasEstaSemana = _context.Presencialidades
                                                .Where(p => p.AlumnoId == alumnoId &&
                                                            p.Fecha >= DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek) &&
                                                            p.Fecha <= DateTime.Now)
                                                .Count();

            if (asistenciasEstaSemana >= plan.DiasSemana)
            {
                throw new Exception("El alumno ha alcanzado el límite de asistencias esta semana.");
            }

            var presencialidad = new Presencialidad
            {
                AlumnoId = alumnoId,
                Fecha = fecha
            };
            _context.Presencialidades.Add(presencialidad);
            _context.SaveChanges();
        }

        public bool VerificarPresencialidad(int alumnoId, DateTime fecha)
        {
            return _context.Presencialidades.Any(p => p.AlumnoId == alumnoId && p.Fecha.Date == fecha.Date);
        }
    }
}
