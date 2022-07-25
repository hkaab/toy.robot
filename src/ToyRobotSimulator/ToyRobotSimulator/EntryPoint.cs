using Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                    var operation = GetOperation();

                    if (string.IsNullOrEmpty(operation))
                        continue;
                    if (operation.ToLower() == "exit" || operation.ToLower() == "quit")
                        break;

                    var command = operation.IndexOf(" ") > 0 ? operation[..operation.IndexOf(" ")].FirstCharToUpper() : operation.FirstCharToUpper();
                    var commandArg = operation.IndexOf(" ") > 0 ? operation[operation.IndexOf(" ")..].Replace(" ", "") : null;

                    _ = typeof(Robot).GetMethod(command)
                                     .Invoke(_robot, commandArg != null ? new string[] { commandArg } : null);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Command is not well formed");
                    _logger.LogError(e, e.Message);
                }
            }
        }
    }
}

