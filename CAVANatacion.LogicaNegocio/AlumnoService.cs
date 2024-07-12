using CAVANatacion.AccesoDatos;
using CAVANatacion.AccesoDatos.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CAVANatacion.LogicaNegocio
{
    public class AlumnoService
    {
        private readonly PiletaContext _context;

        public AlumnoService(PiletaContext context)
        {
            _context = context;
        }

        public List<Alumno> ObtenerAlumnos()
        {
            return _context.Alumnos.Include(a => a.Plan).Include(b => b.Pagos).ToList();
        }

        public void AgregarAlumno(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            _context.SaveChanges();
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            _context.Alumnos.Update(alumno);
            _context.SaveChanges();
        }
    }
}
