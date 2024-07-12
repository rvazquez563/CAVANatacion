using CAVANatacion.AccesoDatos;
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
    /// Interaction logic for PagosView.xaml
    /// </summary>
    public partial class PagosView : UserControl
    {
        private PiletaContext _context;
        public PagosView()
        {
            InitializeComponent();
            _context = new PiletaContext();
        }

        private void BtnAgregarPago_Click(object sender, RoutedEventArgs e)
        {
            var agregarPagoWindow = new RegistrarPagoWindow(_context);
            if (agregarPagoWindow.ShowDialog() == true)
            {
                CargarPagosDelDia(); // Recargar la lista de pagos después de agregar uno nuevo
                //CargarAlumnos();
            }
        }

        private void BtnFiltrarPagos_Click(object sender, RoutedEventArgs e)
        {
            if (dpFiltroFecha.SelectedDate.HasValue)
            {
                var fecha = dpFiltroFecha.SelectedDate.Value;
                var pagos = _context.Pagos
                    .Include(p => p.Alumno)
                    .Where(p => p.FechaPago.Date == fecha.Date)
                    .Select(p => new
                    {
                        p.Id,
                        AlumnoNombreCompleto = p.Alumno.Nombre + " " + p.Alumno.Apellido,
                        p.FechaPago,
                        p.Monto
                    })
                    .ToList();
                dgPagos.ItemsSource = pagos;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fecha para filtrar.");
            }
        }

        private void CargarPagosDelDia()
        {
            var pagosDelDia = _context.Pagos
                .Include(p => p.Alumno)
                .Where(p => p.FechaPago.Date == DateTime.Now.Date)
                .Select(p => new
                {
                    p.Id,
                    AlumnoNombreCompleto = p.Alumno.Nombre + " " + p.Alumno.Apellido,
                    p.FechaPago,
                    p.Monto
                })
                .ToList();
            dgPagos.ItemsSource = pagosDelDia;
        }

        private void BtnPagosDelDia_Click(object sender, RoutedEventArgs e)
        {
            CargarPagosDelDia();
        }
    }
}
