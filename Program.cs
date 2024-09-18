using System;

namespace ScientificCalculator
{
    class Program
    {
        static double currentResult = 0;
        static double memoryResult = 0;

        static void Main(string[] args)
        {
            

            while (true)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine(" +-----------------------------------------------------+ ");
                Console.WriteLine(" |               Scientific Calculator                 | ");
                Console.WriteLine(" +-----------------------------------------------------+ ");
                Console.WriteLine(" |               Basic Calculation                     | ");
                Console.WriteLine(" +-----------------------------------------------------+ ");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(" |           | 7 | 8 | 9  |  / (Divide)    |           | ");
                Console.WriteLine(" |           | 4 | 5 | 6  |  * (Multiply)  |           | ");
                Console.WriteLine(" |           | 1 | 2 | 3  |  - (Subtract)  |           | ");        
                Console.WriteLine(" |           | 0 | . | 00 |  + (Addition)  |           | ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +-----------------------------------------------------+ ");
                Console.WriteLine(" |               Scientific Calculation                | ");
                Console.WriteLine(" +-----------------------------------------------------+ ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(" |      | sin  | cos  | tan  |  cot  |  exp     |      | ");
                Console.WriteLine(" |      | isin | icos | itan |  log  |  sqrt    |      | ");
                Console.WriteLine(" |      | fact | mod  | pow  |  cbrt |  quad    |      | ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +-----------------------------------------------------+ ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(" |      | Memory recall (mr) | Memory Store (ms)|      | ");
                Console.WriteLine(" |      | Exit (exit) | Resume Calculation (resume)    | ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +-----------------------------------------------------+ ");
                Console.ResetColor();
                Console.Write("Enter Operation :- ");
                

                string operation = Console.ReadLine();
                Console.ResetColor();

                if (operation.ToLower() == "exit")
                {
                    break;
                }

             

                if (operation.ToLower() == "resume")
                {
                    if (currentResult == 0)
                    {
                        Console.WriteLine("No previous result to resume.");
                    }
                    else
                    {
                        Console.WriteLine($"Resuming with previous result: {currentResult}");
                        PerformOperation(operation, currentResult);
                    }
                    continue;
                }

                if (operation.ToLower() == "mr")
                {
                    if (memoryResult == 0)
                    {
                        Console.WriteLine("No memory result to recall.");
                    }
                    else
                    {
                        Console.WriteLine($"Recalling memory result: {memoryResult}");
                        currentResult = memoryResult;
                    }
                    continue;
                }

                if (operation.ToLower() == "ms")
                {
                    memoryResult = currentResult;
                    Console.WriteLine("Memory result stored.");
                    continue;
                }

                

                if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
                {
                    Console.ResetColor();
                    Console.Write("Enter first number: ");
                    double num1 = GetDoubleFromUser();
                    Console.Write("Enter second number: ");
                    double num2 = GetDoubleFromUser();
                    PerformBinaryOperation(operation, num1, num2);
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("Enter number: ");
                    double num1 = GetDoubleFromUser();
                    PerformUnaryOperation(operation, num1);
                }
            }
        }

        static double GetDoubleFromUser()
        {
            while (true)
            {
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Write("Invalid input. Please enter a valid number: ");
                }
            }
        }

        static void PerformBinaryOperation(string operation, double num1, double num2)
        {
            Console.ResetColor();
            try
            {
                switch (operation)
                {
                    case "+":
                        currentResult = num1 + num2;
                        Console.Write("Addition is ");
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    case "-":
                        currentResult = num1 - num2;
                        Console.Write("Subtraction is ");
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    case "*":
                        currentResult = num1 * num2;
                        Console.Write("Multiplication is ");
                        Console.WriteLine($"Result: {currentResult}");
                        break;

                    case "/":
                        if (num2 != 0)
                        {
                            currentResult = num1 / num2;
                            Console.Write("Division is");
                            Console.WriteLine($"Result: {currentResult}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Division by zero!");
                        }
                        break;


                    default:
                        { Console.WriteLine("Error: Invalid operation!"); }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void PerformUnaryOperation(string operation, double num)
        {
            Console.ResetColor();
            try
            {
                switch (operation)
                {
                    case "log":
                        currentResult = Math.Log(num);
                        Console.Write("Logrithm is ");
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    case "pow":
                        Console.Write("Enter power: ");
                        double power = GetDoubleFromUser();
                        currentResult = Math.Pow(num, power);
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    case "fact":
                        if (num >= 0 && num % 1 == 0)
                        {
                            double factorial = 1;
                            for (int i = 1; i <= num; i++)
                            {
                                factorial *= i;
                            }
                            currentResult = factorial;
                            Console.Write("Factorial is ");
                            Console.WriteLine($"Result: {currentResult}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Factorial is not defined for negative numbers or non-integer values!");
                        }
                        break;
                    case "sqrt":
                        if (num >= 0)
                        {
                            currentResult = Math.Sqrt(num);
                            Console.Write("Square root is ");
                            Console.WriteLine($"Result: {currentResult}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Square root is not defined for negative numbers!");
                        }
                        break;
                    case "sin":
                        currentResult = Math.Sin(num);
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    case "cos":
                        currentResult = Math.Cos(num);
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    case "tan":
                        currentResult = Math.Tan(num);
                        Console.WriteLine($"Result: {currentResult}");
                        break;

                    case "cot":
                        currentResult = 1/Math.Tan(num);
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    case "exp":
                        currentResult = Math.Exp(num);
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    case "mod":
                        Console.Write("Enter modulus: ");
                        double modulus = GetDoubleFromUser();
                        if (modulus != 0)
                        {
                            currentResult = num % modulus;
                            Console.WriteLine($"Result: {currentResult}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Modulus cannot be zero!");
                        }
                        break;
                    case "isin":
                        currentResult = Math.Asin(num);
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    case "icos":
                        currentResult = Math.Acos(num);
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    case "itan":
                        currentResult = Math.Atan(num);
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    case "cbrt":
                        currentResult = Math.Pow(num, 1.0 / 3.0);
                        Console.WriteLine($"Result: {currentResult}");
                        break;
                    default:
                        Console.WriteLine("Error: Invalid operation!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void PerformOperation(string operation, double num)
        {
            Console.ResetColor();
            Console.Write("Enter next operation (+, -, *, /, log, pow, fact, sqrt, sin, cos, tan, exp, mod): ");
            string nextOperation = Console.ReadLine();

            if (nextOperation == "+" || nextOperation == "-" || nextOperation == "*" || nextOperation == "/")
            {
                Console.Write("Enter next number: ");
                double nextNum = GetDoubleFromUser();
                PerformBinaryOperation(nextOperation, num, nextNum);
            }
            else
            {
                PerformUnaryOperation(nextOperation, num);
            }
        }
    }
}