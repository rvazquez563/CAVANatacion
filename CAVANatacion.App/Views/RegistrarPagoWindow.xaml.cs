
using System;
using System.Linq;
using System.Windows;
using System.Windows.Interop;
using CAVANatacion.AccesoDatos;
using CAVANatacion.AccesoDatos.Entidades;

namespace CAVANatacion.App.Views
{
    public partial class RegistrarPagoWindow : Window
    {
        private readonly PiletaContext _context;

        public RegistrarPagoWindow(PiletaContext context)
        {
            InitializeComponent();
            _context = context;
            CargarAlumnos();
        }

        private void CargarAlumnos()
        {
            var alumnos = _context.Alumnos.Where( a => !a.PagoMes ).ToList();
            cmbAlumnos.ItemsSource = alumnos;
            cmbAlumnos.DisplayMemberPath = "ApellidoNombre"; // Assuming NombreCompleto is a property that concatenates Nombre and Apellido
            cmbAlumnos.SelectedValuePath = "AlumnoId";
            var planes = _context.Planes.ToList();
            cmbPlan.ItemsSource = planes;
            cmbPlan.DisplayMemberPath = "Descripcion"; // Assuming NombreCompleto is a property that concatenates Nombre and Apellido
            cmbPlan.SelectedValuePath = "PlanId";
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAlumnos.SelectedItem == null || string.IsNullOrEmpty(txtMonto.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            var pago = new Pago
            {
                AlumnoId = (int)cmbAlumnos.SelectedValue,
                FechaPago = DateTime.Now,
                Monto = decimal.Parse(txtMonto.Text)
            };

            _context.Pagos.Add(pago);

            // Actualizar el último pago del alumno y el estado de PagoMes
            var alumno = _context.Alumnos.Find(pago.AlumnoId);
            alumno.MontoPagadoMes += pago.Monto;
            if (alumno.MontoPagadoMes >= alumno.Plan.Tarifa)
            {
                alumno.PagoMes = true;
                alumno.PagoMes = pago.FechaPago.Month == DateTime.Now.Month && pago.FechaPago.Year == DateTime.Now.Year;
            }
            alumno.PlanId = (int)cmbAlumnos.SelectedValue;
           // alumno.UltimoPago = pago.FechaPago;
           

            _context.SaveChanges();

            DialogResult = true;
            Close();
            //var alumno = cmbAlumnos.SelectedItem as Alumno;
            //if (alumno != null && DateTime.TryParse(dpFechaPago.Text, out var fechaPago) && decimal.TryParse(txtMonto.Text, out var monto))
            //{
            //    var pago = new Pago
            //    {
            //        AlumnoId = alumno.AlumnoId,
            //        FechaPago = fechaPago,
            //        Monto = monto
            //    };

            //    _context.Pagos.Add(pago);
            //    _context.SaveChanges();
            //    MessageBox.Show("Pago registrado con éxito.");
            //    Close();
            //}
            //else
            //{
            //    MessageBox.Show("Por favor, complete todos los campos correctamente.");
            //}
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmbAlumnos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var alumno = _context.Alumnos.SingleOrDefault(a => a.AlumnoId == (int)cmbAlumnos.SelectedValue);
            if (alumno != null)
            {
                cmbPlan.SelectedValue = alumno.PlanId;
            }
                    
                
        }

        private void cmbPlan_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var plan = _context.Planes.SingleOrDefault(a => a.PlanId == (int)cmbPlan.SelectedValue);
            if (plan != null)
            {
                txtMonto.Text = plan.Tarifa.ToString();
            }
        }
    }
}
