////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;
////using System.Windows;
////using System.Windows.Controls;
////using System.Windows.Data;
////using System.Windows.Documents;
////using System.Windows.Input;
////using System.Windows.Media;
////using System.Windows.Media.Imaging;
////using System.Windows.Shapes;

////namespace CAVANatacion.App.Views
////{
////    /// <summary>
////    /// Interaction logic for AgregarAlumnoWindow.xaml
////    /// </summary>
////    public partial class AgregarAlumnoWindow : Window
////    {
////        public AgregarAlumnoWindow()
////        {
////            InitializeComponent();
////        }
////    }
////}
//using CAVANatacion.AccesoDatos.Entidades;
//using CAVANatacion.LogicaNegocio;
//using System;
//using System.Windows;

//namespace CAVANatacion.App.Views
//{
//    public partial class AgregarAlumnoWindow : Window
//    {
//        public List<string> Categorias { get; set; }

//        public void AgregarPlanWindow()
//        {
//            InitializeComponent();

//            // Inicializa la lista de categorías y agrega las categorías deseadas
//            Categorias = new List<string> { "Adultos", "Menores", "Jubilados" };

//            // Establece el contexto de datos de la ventana como la ventana misma
//            DataContext = this;
//        }

//        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
//        {
//            // Aquí puedes agregar la lógica para guardar el nuevo alumno en la base de datos
//            // y cerrar la ventana
//            MessageBox.Show("Alumno agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
//            Close();
//        }

//        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
//        {
//            // Simplemente cierra la ventana sin guardar ningún cambio
//            Close();
//        }
//    }
//}
using System;
using System.Windows;
using CAVANatacion.AccesoDatos.Entidades;
using CAVANatacion.LogicaNegocio;
using Microsoft.EntityFrameworkCore;

namespace CAVANatacion.App.Views
{
    public partial class AgregarAlumnoWindow : Window
    {
        private readonly AlumnoService _alumnoService;
        private readonly PlanService _planService;
        private Alumno _alumno;

        public AgregarAlumnoWindow(AlumnoService alumnoService, PlanService planService,Alumno alumno = null)
        {
            InitializeComponent();
            _alumnoService = alumnoService;
            _planService = planService;

            // Cargar planes en el ComboBox
            cbPlan.ItemsSource = _planService.ObtenerPlanes();
            _alumno = alumno ?? new Alumno();

            if (alumno != null)
            {
                CargarAlumno();
            }
        }

        private void CargarAlumno()
        {
            txtNombre.Text = _alumno.Nombre;
            txtApellido.Text = _alumno.Apellido;
            txtDocumento.Text = _alumno.Documento;
            txtEmail.Text = _alumno.Email;
            //dpFechaIngreso.SelectedDate = _alumno.FechaIngreso;
            cbPlan.SelectedValue = _alumno.PlanId;
            //chkPagoMes.IsChecked = _alumno.PagoMes;
            chkApto.IsChecked = _alumno.Apto;
            dpFechaVencimientoApto.SelectedDate = _alumno.FechaVencimientoApto;
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            var nuevoAlumno = new Alumno
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Documento = txtDocumento.Text,
                Email = txtEmail.Text,
                FechaIngreso =  DateTime.Now,
                PagoMes=false,
                UltimoPago=null,
                Apto = chkApto.IsChecked ?? false,
                FechaVencimientoApto = dpFechaVencimientoApto.SelectedDate,
                
                PlanId = ((Plan)cbPlan.SelectedItem).PlanId
            };

            
            this.Close();
            if (nuevoAlumno.AlumnoId == 0)
            {
                _alumnoService.AgregarAlumno(nuevoAlumno);
            }
            else
            {
                _alumnoService.ActualizarAlumno(nuevoAlumno);
            }

           
            //DialogResult = true;
            Close();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = false;
            this.Close();
        }
    }
}


