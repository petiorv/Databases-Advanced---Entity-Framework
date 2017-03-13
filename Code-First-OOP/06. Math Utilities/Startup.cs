namespace _06.Math_Utilities
{
    using System;

    class Startup
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            while (command != "End")
            {
                var commandArgs = command.Split(' ');
                var methodName = commandArgs[0];
                double firstNumber = double.Parse(commandArgs[1]);
                double secondNumber = double.Parse(commandArgs[2]);

                string result = string.Empty;
                switch (commandArgs[0])
                {
                    case "Sum":
                        result = $"{MathUtil.Sum(firstNumber, secondNumber):F2}";
                        break;
                    case "Multiply":
                        result = $"{MathUtil.Multiply(firstNumber, secondNumber):F2}";
                        break;
                    case "Subtract":
                        result = $"{MathUtil.Subtract(firstNumber, secondNumber):F2}";
                        break;
                    case "Divide":
                        result = $"{MathUtil.Divide(firstNumber, secondNumber):F2}";
                        break;
                    case "Percentage":
                        result = $"{MathUtil.Percentage(firstNumber, secondNumber):F2}";
                        break;
                }

                Console.WriteLine(result);

                command = Console.ReadLine();
            }

        }
    }
}
