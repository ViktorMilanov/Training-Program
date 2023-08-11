using System;
using System.Collections.Generic;

public class ShuntingYardCalculator
{
    // Operator precedence dictionary
    private static readonly Dictionary<char, int> Precedence = new Dictionary<char, int>
    {
        { '+', 1 },
        { '-', 1 },
        { '*', 2 },
        { '/', 2 },
        { '^', 3 }
    };

    // Method to convert infix notation to postfix notation using the Shunting Yard algorithm
    public static Queue<string> InfixToPostfix(string infix)
    {
        Queue<string> outputQueue = new Queue<string>();
        Stack<char> operatorStack = new Stack<char>();

        foreach (char token in infix)
        {
            if (char.IsDigit(token))
            {
                outputQueue.Enqueue(token.ToString());
            }
            else if (token == '(')
            {
                operatorStack.Push(token);
            }
            else if (token == ')')
            {
                while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
                {
                    outputQueue.Enqueue(operatorStack.Pop().ToString());
                }

                operatorStack.Pop(); // Discard the '('
            }
            else if (IsOperator(token))
            {
                while (operatorStack.Count > 0 && IsOperator(operatorStack.Peek()) && Precedence[token] <= Precedence[operatorStack.Peek()])
                {
                    outputQueue.Enqueue(operatorStack.Pop().ToString());
                }

                operatorStack.Push(token);
            }
        }

        while (operatorStack.Count > 0)
        {
            outputQueue.Enqueue(operatorStack.Pop().ToString());
        }

        return outputQueue;
    }

    // Method to evaluate a postfix expression and calculate the result
    public static double EvaluatePostfix(Queue<string> postfixQueue)
    {
        Stack<double> operandStack = new Stack<double>();

        while (postfixQueue.Count > 0)
        {
            string token = postfixQueue.Dequeue();

            if (double.TryParse(token, out double operand))
            {
                operandStack.Push(operand);
            }
            else if (IsOperator(token[0]))
            {
                double operand2 = operandStack.Pop();
                double operand1 = operandStack.Pop();

                double result = PerformOperation(operand1, operand2, token[0]);
                operandStack.Push(result);
            }
        }

        return operandStack.Pop();
    }

    // Helper method to check if a character is an operator
    private static bool IsOperator(char ch)
    {
        return Precedence.ContainsKey(ch);
    }

    // Helper method to perform arithmetic operations
    private static double PerformOperation(double operand1, double operand2, char op)
    {
        switch (op)
        {
            case '+': return operand1 + operand2;
            case '-': return operand1 - operand2;
            case '*': return operand1 * operand2;
            case '/': return operand1 / operand2;
            case '^': return Math.Pow(operand1, operand2);
            default: throw new ArgumentException("Invalid operator");
        }
    }

    public static void Main()
    {
        Console.WriteLine("Enter a math expression in infix notation:");
        string infixExpression = Console.ReadLine();

        Queue<string> postfixExpression = InfixToPostfix(infixExpression);

        Console.WriteLine("Postfix Notation: " + string.Join(" ", postfixExpression));

        double result = EvaluatePostfix(postfixExpression);
        Console.WriteLine("Result: " + result);
    }
}
