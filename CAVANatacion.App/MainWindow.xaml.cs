//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace CAVANatacion.App
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        public MainWindow()
//        {
//            InitializeComponent();
//        }
//    }
//}
using CAVANatacion.AccesoDatos;
using CAVANatacion.App.Views;
using CAVANatacion.LogicaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace CAVANatacion.App
{
    public partial class MainWindow : Window
    {
        private AlumnoService _alumnoService;
        private PlanService _planService;
        private PresencialidadService _presencialidadService;
        private PiletaContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new PiletaContext();
            _alumnoService = new AlumnoService(_context);
            _planService = new PlanService(_context);
            _presencialidadService = new PresencialidadService(_context);

            
        }

        private void CargarAlumnos()
        {
            //dataGridAlumnos.ItemsSource = _alumnoService.ObtenerAlumnos();
        }  
        private void RegistrarPresencialidad_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    string documento = txtDocumento.Text;
            //    var alumno = _alumnoService.ObtenerAlumnos().FirstOrDefault(a => a.Documento == documento);
            //    if (alumno == null)
            //    {
            //        MessageBox.Show("Alumno no encontrado");
            //        return;
            //    }

            //    _presencialidadService.RegistrarPresencialidad(alumno.AlumnoId, DateTime.Now);
            //    MessageBox.Show("Presencialidad registrada correctamente");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error: {ex.Message}");
            //}
        }


       

        private void miPagos_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new PagosView();
        }

        private void miPresencialidad_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new PresencialidadView();
        }

        private void miAlumnos_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new AlumnosView();
        }

        private void miPlanes_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new PlanesView();
        }

        private void miNuevoAlumno_Click(object sender, RoutedEventArgs e)
        {
            var agregarAlumnoWindow = new AgregarAlumnoWindow(_alumnoService, _planService);
            agregarAlumnoWindow.ShowDialog();// Aquí deberías abrir un nuevo formulario para agregar un alumno
        }

        private void miNuevoPago_Click(object sender, RoutedEventArgs e)
        {

        }

        private void miAsistencias_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
