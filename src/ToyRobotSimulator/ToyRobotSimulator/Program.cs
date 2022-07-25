using ToyRobot.Simulator;
using Microsoft.Extensions.DependencyInjection;

System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

var services = Startup.ConfigureServices();

var serviceProvider = services.BuildServiceProvider();

#pragma warning disable CS8602 
serviceProvider.GetService<EntryPoint>().Run();
#pragma warning restore CS8602

static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
{
    Console.WriteLine(((System.Exception)e.ExceptionObject).Message);
    Console.WriteLine("Press Enter to continue");
    Console.ReadLine();
    Environment.Exit(1);
}