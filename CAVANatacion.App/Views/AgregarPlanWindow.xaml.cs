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
////    /// Interaction logic for AgregarPlanWindow.xaml
////    /// </summary>
////    public partial class AgregarPlanWindow : Window
////    {
////        public AgregarPlanWindow()
////        {
////            InitializeComponent();
////        }
////    }
////}
//using System;
//using System.Windows;

//namespace CAVANatacion.App.Views
//{
//    public partial class AgregarPlanWindow : Window
//    {
//        public List<string> Categorias { get; set; }

//        public AgregarPlanWindow()
//        {
//            InitializeComponent();
//            // Inicializa la lista de categorías y agrega las categorías deseadas
//            Categorias = new List<string> { "Adultos", "Menores", "Jubilados" };

//            // Establece el contexto de datos de la ventana como la ventana misma
//            DataContext = this;
//        }

//        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
//        {
//            // Aquí puedes agregar la lógica para guardar el nuevo plan en la base de datos
//            // y cerrar la ventana
//            MessageBox.Show("Plan agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
//            Close();
//        }

//        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
//        {
//            // Simplemente cierra la ventana sin guardar ningún cambio
//            Close();
//        }
//    }
//}

using CAVANatacion.AccesoDatos.Entidades;
//using CAVANatacion.Entidades;
using CAVANatacion.LogicaNegocio;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CAVANatacion.App.Views
{
    public partial class AgregarPlanWindow : Window
    {
        public List<string> Categorias { get; set; }
        private readonly PlanService _planService;

        public AgregarPlanWindow(PlanService planService)
        {
            InitializeComponent();
            Categorias = new List<string> { "Adultos", "Menores", "Jubilados" };
            DataContext = this;
            _planService = planService;
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los valores del formulario
            // Obtener los valores del formulario
            var descripcion = DescripcionTextBox.Text;
            var diasAlaSemana = int.Parse(DiasAlaSemanaTextBox.Text);
            var tarifa = decimal.Parse(TarifaTextBox.Text);
            var categoria = CategoriaComboBox.SelectedItem as string;
            // Crear un nuevo plan
            var plan = new Plan
            {
                Descripcion = descripcion,
                DiasSemana = diasAlaSemana,
                Tarifa = tarifa,
                Categoria = categoria
            };

            // Guardar el plan utilizando el servicio
            _planService.AgregarPlan(plan);

            // Cerrar la ventana
            this.Close();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar la ventana sin guardar
            this.Close();
        }
    }
}

