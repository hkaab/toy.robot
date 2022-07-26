using ToyRobot.Interfaces;
using Microsoft.Extensions.Logging;
using ToyRobot.Builder;
using ToyRobot.Simulator.Extensions;

namespace ToyRobot.Simulator
{
    internal class EntryPoint
    {
        private readonly ILogger<EntryPoint> _logger;
        private readonly IRobot _robot;
        public EntryPoint(IRobot robot, ILogger<EntryPoint> logger)
        {
            _logger = logger;
            _robot = robot;
        }
        private static string GetOperation()
        {
            Console.Write(" > ");
            return Console.ReadLine()!;
        }

        public void Run()
        {
            while (true)
            {
                try
                {

                    var operation = GetOperation().Trim();

                    if (string.IsNullOrEmpty(operation))
                        continue;
                    if (operation.ToLower() == "exit" || operation.ToLower() == "quit" || operation.ToLower() == "stop" || operation.ToLower() == "off")
                        break;

                    var command = operation.IndexOf(" ") > 0 ? operation[..operation.IndexOf(" ")].FirstCharToUpper() : operation.FirstCharToUpper();
                    var commandArg = operation.IndexOf(" ") > 0 ? operation[operation.IndexOf(" ")..].Replace(" ", "") : null;

#pragma warning disable CS8602 
                    _ = typeof(Robot).GetMethod(command)
                                     .Invoke(_robot, commandArg != null ? new string[] { commandArg } : null);
#pragma warning restore CS8602 
                }
                catch (Exception e)
                {
                    if (e.InnerException is ArgumentException)
                        Console.WriteLine(e.InnerException.Message);
                    else
                        Console.WriteLine("Command is not well formed");
                    _logger.LogError(e, e.Message);
                }
            }
        }
    }
}

