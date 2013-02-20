using System;
using System.Linq;
using mips_syntax.utils;
using mips_syntax.Entities;

namespace mips_syntax
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var exitFlag = false;
            var validator = new MipsValidator();
            while (!exitFlag)
            {
                Console.Write("Please enter a MIPS statement: ");
                var input = Console.ReadLine();
                
                var arguments = new Line(input);
                var operands = arguments.Instruction.ParseInstruction();
                var status = validator.IsSyntaxValid(operands);
                //Check syntax
                if (status.Success.Equals(true))
                {
                    var stat = validator.HasValidParams(operands);
                    //Check parameters
                    if (stat.Success.Equals(true))
                    {
                        Console.WriteLine(string.Format("'{0}' is a valid mips instruction ", arguments.Instruction));
                    }
                    else
                    {
                        foreach (var reason in stat.Reasons)
                        {
                            Console.WriteLine(reason);
                        }
                    }
                }
                else
                {
                    foreach (var reason in status.Reasons)
                    {
                        Console.WriteLine(reason);
                    }
                }
                Console.WriteLine("Enter esc key to quit, any other key to continue ");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    exitFlag = true;
                }
            }
        }
    }
}