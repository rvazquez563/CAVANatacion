using CAVANatacion.AccesoDatos;
using CAVANatacion.LogicaNegocio;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for AlumnosView.xaml
    /// </summary>
    public partial class AlumnosView : UserControl
    {
        private AlumnoService _alumnoService;
        private PlanService _planService;
        private PiletaContext _context;
        public AlumnosView()
        {
            InitializeComponent();
            _context = new PiletaContext();
            _alumnoService = new AlumnoService(_context);
            _planService = new PlanService(_context);
            CargarAlumnos();
        }

        private void btnAgregarAlumno_Click(object sender, RoutedEventArgs e)
        {
            var agregarAlumnoWindow = new AgregarAlumnoWindow(_alumnoService, _planService);
            agregarAlumnoWindow.ShowDialog();// Aquí deberías abrir un nuevo formulario para agregar un alumno
            CargarAlumnos();
        }
        private void CargarAlumnos()
        {
            dataGridAlumnos.ItemsSource = _alumnoService.ObtenerAlumnos();
        }
    }
}
