using CAVANatacion.AccesoDatos;
using CAVANatacion.AccesoDatos.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace CAVANatacion.LogicaNegocio
{
    public class PlanService
    {
        private readonly PiletaContext _context;

        public PlanService(PiletaContext context)
        {
            _context = context;
        }

        public List<Plan> ObtenerPlanes()
        {
            return _context.Planes.ToList();
        }

        public void AgregarPlan(Plan plan)
        {
            _context.Planes.Add(plan);
            _context.SaveChanges();
        }

        public void ActualizarPlan(Plan plan)
        {
            _context.Planes.Update(plan);
            _context.SaveChanges();
        }
    }
}
