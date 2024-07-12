
using System.Configuration;
using System.Data;
using System.Windows;

namespace CAVANatacion.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

}
//using CAVANatacion.App.Views;
////using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using System.Configuration;
//using System.Data;
//using System.Windows;
//using CAVANatacion.AccesoDatos;
//using CAVANatacion.LogicaNegocio;
//using Microsoft.EntityFrameworkCore;

//namespace CAVANatacion.App
//{
//    /// <summary>
//    /// Interaction logic for App.xaml
//    /// </summary>
//    public partial class App : Application
//    {
//        //private readonly IHost _host;

//        //public App()
//        //{
//        //    _host = Host.CreateDefaultBuilder()
//        //        .ConfigureServices((context, services) =>
//        //        {
//        //            services.AddDbContext<PiletaContext>(options =>
//        //                options.UseSqlServer("Server=RODRIGO\\SQLEXPRESS;Database=CAVANatacion;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"));

//        //            services.AddTransient<PlanService>();

//        //            // Registrar las ventanas
//        //            services.AddTransient<AgregarPlanWindow>();
//        //        })
//        //        .Build();
//        //}

//        //protected override async void OnStartup(StartupEventArgs e)
//        //{
//        //    await _host.StartAsync();

//        //    var agregarPlanWindow = _host.Services.GetRequiredService<AgregarPlanWindow>();
//        //    agregarPlanWindow.Show();

//        //    base.OnStartup(e);
//        //}

//        //protected override async void OnExit(ExitEventArgs e)
//        //{
//        //    await _host.StopAsync();
//        //    base.OnExit(e);
//        //}
//    }

//    }