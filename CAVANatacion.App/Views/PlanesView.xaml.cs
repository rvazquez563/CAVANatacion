using CAVANatacion.AccesoDatos;
using CAVANatacion.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CAVANatacion.App.Views
{
    /// <summary>
    /// Interaction logic for PlanesView.xaml
    /// </summary>
    public partial class PlanesView : UserControl
    {

        private AlumnoService _alumnoService;
        private PlanService _planService;
        private PresencialidadService _presencialidadService;
        private PiletaContext _context;

        public PlanesView()
        {
            InitializeComponent();
            _context = new PiletaContext();
            _alumnoService = new AlumnoService(_context);
            _planService = new PlanService(_context);
            _presencialidadService = new PresencialidadService(_context);

            CargarPlanes();
        }

        private void AgregarPlan_Click(object sender, RoutedEventArgs e)
        {
            var agregarPlan = new AgregarPlanWindow(_planService);
            agregarPlan.ShowDialog();// Aquí deberías abrir un nuevo formulario para agregar un plan
            CargarPlanes();
        }

        private void CargarPlanes()
        {
            dataGridPlanes.ItemsSource = _planService.ObtenerPlanes();
        }
    }
}
