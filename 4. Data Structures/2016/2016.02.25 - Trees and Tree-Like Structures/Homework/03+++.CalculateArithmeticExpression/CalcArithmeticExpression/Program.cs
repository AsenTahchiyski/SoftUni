namespace CalcArithmeticExpression
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Threading;

    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string expression = Console.ReadLine();
            string[] parametersArray = Regex.Split(expression, "\\s+");
            List<string> parameters = new List<string>();
            SplitExpression(parametersArray, parameters);

            Queue<string> outputQueue = new Queue<string>();
            Stack<string> operatorsStack = new Stack<string>();

            // Shunting Yard algorythm (Edsger Dijkstra) - transforms the expression into Reversed Polish Notation
            foreach (string parameter in parameters)
            {
                if (string.IsNullOrEmpty(parameter))
                {
                    continue;
                }

                if (char.IsDigit(parameter[parameter.Length - 1]))
                {
                    outputQueue.Enqueue(parameter);
                }
                else if(parameter == "(")
                {
                    operatorsStack.Push(parameter);
                }
                else if (parameter == ")")
                {
                    while (operatorsStack.Peek() != "(")
                    {
                        outputQueue.Enqueue(operatorsStack.Pop());
                    }

                    operatorsStack.Pop(); // discard the opening bracket
                }
                else // token is operator
                {
                    while (operatorsStack.Count > 0 && GetOperatorPrecedence(operatorsStack.Peek()) < GetOperatorPrecedence(parameter))
                    {
                        outputQueue.Enqueue(operatorsStack.Pop());
                    }

                    operatorsStack.Push(parameter);
                }
            }

            while (operatorsStack.Count > 0)
            {
                outputQueue.Enqueue(operatorsStack.Pop());
            }

            // Queue now contains the expression in Reversed Polish Notation

            Stack<string> reversePolishStack = new Stack<string>();

            do
            {
                if (string.IsNullOrWhiteSpace(outputQueue.Peek()))
                {
                    continue;
                }

                string token = outputQueue.Dequeue();
                if (char.IsDigit(token[token.Length - 1]))
                {
                    reversePolishStack.Push(token);
                }
                else
                {
                    if (reversePolishStack.Count < 2)
                    {
                        throw new ArgumentException("Error, not enough tokens to perform the operation!");
                    }

                    if (token.Length != 1)
                    {
                        throw new ArgumentException("Invalid operator!");
                    }

                    double firstOperand = double.Parse(reversePolishStack.Pop());
                    double secondOperand = double.Parse(reversePolishStack.Pop());
                    double result = PerformOperation(token, firstOperand, secondOperand);
                    reversePolishStack.Push(result.ToString());
                }
            } while (reversePolishStack.Count > 0 && outputQueue.Count > 0);

            Console.WriteLine(reversePolishStack.Pop());
        }

        private static void SplitExpression(string[] parametersArray, List<string> parameters)
        {
            foreach (string s in parametersArray)
            {
                if (s.Contains("("))
                {
                    parameters.Add("(");
                    string remainder = s.Substring(1);

                    if (remainder.Contains(")"))
                    {
                        parameters.Add(remainder.Substring(0, remainder.Length - 1));
                        parameters.Add(")");
                    }
                    else
                    {
                        parameters.Add(remainder);
                    }
                }
                else if (s.Contains(")"))
                {
                    parameters.Add(s.Substring(0, s.Length - 1));
                    parameters.Add(")");
                }
                else
                {
                    if (s.Length > 1 && (s.Contains("+") || s.Contains("-") || s.Contains("*") || s.Contains("/")))
                    {
                        var subExpressionToFix = s
                            .Replace("+", " + ")
                            .Replace("-", " - ")
                            .Replace("*", " * ")
                            .Replace("/", " / ");
                        string[] subexpressionParameters = Regex.Split(subExpressionToFix, "\\s+");
                        foreach (string parameter in subexpressionParameters)
                        {
                            parameters.Add(parameter);
                        }
                    }
                    else
                    {
                        parameters.Add(s);
                    }
                }
            }
        }

        private static int GetOperatorPrecedence(string op)
        {
            switch (op)
            {
                case "+": 
                case "-":
                    return 4;
                case "*":
                case "/":
                    return 3;
                default:
                    return 9;
            }
        }

        private static double PerformOperation(string op, double firstOperand, double secondOperand)
        {
            switch (op)
            {
                case "+":
                    return secondOperand + firstOperand;
                case "-":
                    return secondOperand - firstOperand;
                case "*":
                    return secondOperand*firstOperand;
                case "/": return secondOperand / firstOperand;
                default:
                    return 0;
            }
        }
    }
}
